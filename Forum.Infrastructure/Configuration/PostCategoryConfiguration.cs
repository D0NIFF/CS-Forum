using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Infrastructure.Configuration;

public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategoryEntity>
{
    public void Configure(EntityTypeBuilder<PostCategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(u => u.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasMany(c => c.Posts)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

    }
}
