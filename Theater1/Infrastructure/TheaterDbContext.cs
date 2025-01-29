using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class TheaterDbContext : DbContext
{
    public TheaterDbContext( DbContextOptions<TheaterDbContext> options )
        : base( options )
    {
    }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Composition> Compositions { get; set; }
    public DbSet<Play> Plays { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );

        optionsBuilder.UseSqlServer( "Server=localhost\\SQLEXPRESS;Database=Theater1;Trusted_Connection=True;TrustServerCertificate=True;" );
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new AuthorConfiguration() );
        modelBuilder.ApplyConfiguration( new CompositionConfiguration() );
        modelBuilder.ApplyConfiguration( new PlayConfiguration() );
        modelBuilder.ApplyConfiguration( new TheaterConfiguration() );
    }
}