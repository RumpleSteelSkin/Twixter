using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwixterR.Domain.Entities;

namespace TwixterR.Persistence.Configurations;

public class PostConfiguration:IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);
        
        builder.HasIndex(p => p.IsArchived);
        
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}