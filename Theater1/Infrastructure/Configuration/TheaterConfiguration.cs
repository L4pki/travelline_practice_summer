using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure( EntityTypeBuilder<Theater> builder )
    {
        builder.ToTable( nameof( Theater ) )
               .HasKey( t => t.Id );

        builder.Property( t => t.Name )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( t => t.Address )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( t => t.Phone )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( t => t.OpenSince )
               .IsRequired();

        builder.Property( t => t.StartTime )
               .IsRequired();

        builder.Property( t => t.EndTime )
               .IsRequired();

        builder.Property( t => t.About )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.HasMany( t => t.Plays )
               .WithOne( p => p.Theater )
               .HasForeignKey( p => p.IdTheater )
               .OnDelete( DeleteBehavior.Restrict );
    }
}
