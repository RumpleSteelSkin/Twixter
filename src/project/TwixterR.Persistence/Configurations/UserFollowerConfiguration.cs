using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwixterR.Domain.Entities;

namespace TwixterR.Persistence.Configurations;

public class UserFollowerConfiguration:IEntityTypeConfiguration<UserFollower>
{
    public void Configure(EntityTypeBuilder<UserFollower> builder)
    {
        builder
            .HasOne(uf => uf.Follower)
            .WithMany(u => u.Followings)
            .HasForeignKey(uf => uf.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(uf => uf.Following)
            .WithMany(u => u.Followers)
            .HasForeignKey(uf => uf.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(uf => new { uf.FollowerId, uf.FollowingId })
            .IsUnique();
        
        builder.HasQueryFilter(uf => !uf.IsDeleted);
    }
}