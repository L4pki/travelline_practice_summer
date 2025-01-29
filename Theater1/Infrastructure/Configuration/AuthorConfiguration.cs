using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure( EntityTypeBuilder<Author> builder )
    {
        builder.ToTable( nameof( Author ) )
               .HasKey( a => a.Id );

        builder.Property( a => a.Name )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( a => a.DateOfBorth )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.HasMany( a => a.Compositions )
               .WithOne( c => c.Author )
               .HasForeignKey( c => c.IdAuthor )
               .OnDelete( DeleteBehavior.Restrict );
    }
}
