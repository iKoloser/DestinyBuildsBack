namespace DestinyBuildsBack.Data;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Models;

public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Build> Builds { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Subclase> Subclases { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<ArmaduraExotica> ArmadurasExoticas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Build>()
                .HasOne(b => b.Clase)
                .WithMany()
                .HasForeignKey(b => b.ClaseId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Build>()
                .HasOne(b => b.Subclase)
                .WithMany()
                .HasForeignKey(b => b.SubclaseId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Build>()
                .HasOne(b => b.ArmaPrincipal)
                .WithMany()
                .HasForeignKey(b => b.ArmaPrincipalId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Build>()
                .HasOne(b => b.ArmaSecundaria)
                .WithMany()
                .HasForeignKey(b => b.ArmaSecundariaId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Build>()
                .HasOne(b => b.ArmaTerciaria)
                .WithMany()
                .HasForeignKey(b => b.ArmaTerciariaId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Build>()
                .HasOne(b => b.ArmaduraExotica)
                .WithMany()
                .HasForeignKey(b => b.ArmaduraExoticaId)
                .OnDelete(DeleteBehavior.Restrict); // Evitamos el cascado

            modelBuilder.Entity<Subclase>()
                .HasOne(s => s.Clase)
                .WithMany()
                .HasForeignKey(s => s.ClaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArmaduraExotica>()
                .HasOne(a => a.Clase)
                .WithMany()
                .HasForeignKey(a => a.ClaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
