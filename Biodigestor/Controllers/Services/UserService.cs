using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Biodigestor.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Biodigestor.Data;

namespace Biodigestor.Controllers.Services
{
    public class UserService : IUserService
    {
        private readonly BiodigestorContext _context;

        public UserService(BiodigestorContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExists(string? username)
        {
            return await _context.AspNetUsers.AnyAsync(u => u.UserName == username);
        }

        public async Task CreateUser(ApplicationUser user, string password)
        {
            if (await UserExists(user.UserName))
            {
                throw new Exception("El nombre de usuario ya está en uso.");
            }

            user.PasswordHash = await HashPassword(password);
            _context.AspNetUsers.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                var message = innerException?.Message;
                var stackTrace = innerException?.StackTrace;

                throw new Exception($"Error al guardar el usuario: {message} - {stackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el usuario: {ex.Message}", ex);
            }
        }

        public async Task<ApplicationUser?> AuthenticateUser(string? username, string password)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.UserName == username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        private string GenerateHash(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        private bool VerifyPassword(string enteredPassword, string? storedPassword)
        {
            if (storedPassword == null)
            {
                throw new ArgumentNullException(nameof(storedPassword));
            }

            var parts = storedPassword.Split('.');
            var storedSalt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            var hashedEnteredPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: storedSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return storedHash == hashedEnteredPassword;
        }

        public async Task<string> HashPassword(string password)
        {
            return await Task.FromResult(GenerateHash(password));
        }
    }
} 






