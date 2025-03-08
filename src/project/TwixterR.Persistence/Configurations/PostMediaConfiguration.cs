using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwixterR.Domain.Entities;

namespace TwixterR.Persistence.Configurations;

public class PostMediaConfiguration:IEntityTypeConfiguration<PostMedia>
{
    public void Configure(EntityTypeBuilder<PostMedia> builder)
    {
        builder
            .HasOne(pm => pm.Post)
            .WithMany(p => p.Media)
            .HasForeignKey(pm => pm.PostId);
        
        builder.HasQueryFilter(pm => !pm.IsDeleted);
    }
}