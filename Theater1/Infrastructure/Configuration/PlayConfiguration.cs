using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class PlayConfiguration : IEntityTypeConfiguration<Play>
{
    public void Configure( EntityTypeBuilder<Play> builder )
    {
        builder.ToTable( nameof( Play ) )
               .HasKey( p => p.Id );

        builder.Property( p => p.Name )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( p => p.TicketPrice )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( p => p.About )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( p => p.StartDate )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( p => p.EndDate )
                .HasMaxLength( 100 )
                .IsRequired();

        builder.HasOne( p => p.Theater )
               .WithMany( t => t.Plays )
               .HasForeignKey( t => t.IdTheater )
               .OnDelete( DeleteBehavior.Restrict );

        builder.HasOne( p => p.Composition )
               .WithMany( c => c.Plays )
               .HasForeignKey( c => c.IdComposition )
               .OnDelete( DeleteBehavior.Restrict );
    }
}