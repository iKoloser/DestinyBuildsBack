namespace DestinyBuildsBack.Data;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Models;

public class AppDbContext : DbContext   
{
    public DbSet<Build> Builds { get; set; }
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Subclase> Subclases { get; set; }
    public DbSet<Arma> Armas { get; set; }
    public DbSet<ArmaduraExotica> ArmadurasExoticas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subclase>()
            .HasOne(s => s.Clase)
            .WithMany()
            .HasForeignKey(s => s.ClaseId);

        modelBuilder.Entity<ArmaduraExotica>()
            .HasOne(a => a.Clase)
            .WithMany()
            .HasForeignKey(a => a.ClaseId);

        modelBuilder.Entity<Build>()
            .HasOne<Clase>()
            .WithMany()
            .HasForeignKey(b => b.ClaseId);

        modelBuilder.Entity<Build>()
            .HasOne<Subclase>()
            .WithMany()
            .HasForeignKey(b => b.SubclaseId);

        modelBuilder.Entity<Build>()
            .HasOne<Arma>()
            .WithMany()
            .HasForeignKey(b => b.ArmaPrincipalId);

        modelBuilder.Entity<Build>()
            .HasOne<Arma>()
            .WithMany()
            .HasForeignKey(b => b.ArmaSecundariaId);

        modelBuilder.Entity<Build>()
            .HasOne<Arma>()
            .WithMany()
            .HasForeignKey(b => b.ArmaTerciariaId);

        modelBuilder.Entity<Build>()
            .HasOne<ArmaduraExotica>()
            .WithMany()
            .HasForeignKey(b => b.ArmaduraExoticaId);
    }
}