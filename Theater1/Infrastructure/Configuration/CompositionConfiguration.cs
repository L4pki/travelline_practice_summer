using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure( EntityTypeBuilder<Composition> builder )
    {
        builder.ToTable( nameof( Composition ) )
               .HasKey( c => c.Id );

        builder.Property( c => c.Name )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( c => c.AboutComposition )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( c => c.AboutActor )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.HasOne( c => c.Author )
               .WithMany( a => a.Compositions )
               .HasForeignKey( a => a.IdAuthor )
               .OnDelete( DeleteBehavior.Restrict );
    }
}
