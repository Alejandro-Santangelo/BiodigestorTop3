using Microsoft.EntityFrameworkCore;
using Biodigestor.Models;
using Biodigestor.Model;

namespace Biodigestor.Data
{
    public class BiodigestorContext : DbContext
    {
        public BiodigestorContext(DbContextOptions<BiodigestorContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Biodigestor.Models.Biodigestor> BiodigestorEntities { get; set; }
        public DbSet<Acumulador> Acumuladores { get; set; }
        public DbSet<SensorTemperatura> SensoresTemperatura { get; set; }
        public DbSet<SensorHumedad> SensoresHumedad { get; set; }
        public DbSet<SensorPresion> SensoresPresion { get; set; }
        public DbSet<ValvulaAgua> ValvulasAgua { get; set; }
        public DbSet<ValvulaPresion> ValvulasPresion { get; set; }
        public DbSet<Agitador> Agitadores { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Calentador> Calentadores { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.NumeroCliente);

            modelBuilder.Entity<Domicilio>()
                .HasKey(d => d.NumeroMedidor);

            modelBuilder.Entity<Factura>()
                .HasKey(f => f.NumeroFactura);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Facturas)
                .WithOne(f => f.Cliente)
                .HasForeignKey(f => f.NumeroCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domicilio>()
                .HasMany(d => d.Facturas)
                .WithOne(f => f.Domicilio)
                .HasForeignKey(f => f.NumeroMedidor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.Cliente)
                .WithMany(c => c.Domicilios)
                .HasForeignKey(d => d.NumeroCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .Property(f => f.ConsumoMensual)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.ConsumoTotal)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<SensorHumedad>()
                .HasKey(sh => sh.IdSensorHumedad);

            modelBuilder.Entity<SensorHumedad>()
                .Property(sh => sh.ValorLecturaH)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<SensorHumedad>()
                .HasOne<Biodigestor.Models.Biodigestor>()
                .WithMany()
                .HasForeignKey(sh => sh.IdBiodigestor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SensorPresion>()
                .HasKey(sp => sp.IdSensorPresion);

            modelBuilder.Entity<SensorPresion>()
                .Property(sp => sp.ValorLecturaP)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<SensorPresion>()
                .HasOne<Biodigestor.Models.Biodigestor>()
                .WithMany()
                .HasForeignKey(sp => sp.IdBiodigestor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SensorTemperatura>()
                .HasKey(st => st.IdValorLectura);

            modelBuilder.Entity<SensorTemperatura>()
                .Property(st => st.ValorLecturaT)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<SensorTemperatura>()
                .HasOne(s => s.Biodigestor)
                .WithMany(b => b.SensoresTemperatura)
                .HasForeignKey(s => s.IdBiodigestor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Biodigestor.Models.Biodigestor>()
                .HasKey(b => b.IdBiodigestor);

            modelBuilder.Entity<Agitador>()
                .HasKey(a => a.IdAgitador);

            modelBuilder.Entity<Alerta>()
                .HasKey(a => a.IdAlerta);

            modelBuilder.Entity<Alarma>()
                .HasKey(a => a.IdAlarma);

            modelBuilder.Entity<Calentador>()
                .HasKey(c => c.IdCalentador);

            modelBuilder.Entity<Acumulador>()
                .HasKey(a => a.IdAcumulador);

            modelBuilder.Entity<ValvulaAgua>()
                .HasKey(v => v.IdValvulaAgua);

            modelBuilder.Entity<ValvulaPresion>()
                .HasKey(v => v.IdValvulaPresion);
        }
    }
}
