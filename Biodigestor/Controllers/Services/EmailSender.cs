/*using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;

    public EmailSender(IConfiguration configuration)
    {
        _smtpServer = configuration["Smtp:Server"] ?? throw new ArgumentNullException("Smtp:Server");
        _smtpPort = int.Parse(configuration["Smtp:Port"] ?? throw new ArgumentNullException("Smtp:Port"));
        _smtpUser = configuration["Smtp:User"] ?? throw new ArgumentNullException("Smtp:User");
        _smtpPass = configuration["Smtp:Pass"] ?? throw new ArgumentNullException("Smtp:Pass");
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpUser),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        mailMessage.To.Add(email);

        using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
        {
            smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
*/
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Biodigestor.Controllers.Services // Asegúrate de usar el espacio de nombres correcto
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailSender(IConfiguration configuration)
        {
            _smtpServer = configuration["Smtp:Server"] ?? throw new ArgumentNullException("Smtp:Server");
            _smtpPort = int.Parse(configuration["Smtp:Port"] ?? throw new ArgumentNullException("Smtp:Port"));
            _smtpUser = configuration["Smtp:User"] ?? throw new ArgumentNullException("Smtp:User");
            _smtpPass = configuration["Smtp:Pass"] ?? throw new ArgumentNullException("Smtp:Pass");
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUser),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}





