using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwixterR.Domain.Entities;

namespace TwixterR.Persistence.Configurations;

public class UserBlockConfiguration:IEntityTypeConfiguration<UserBlock>
{
    public void Configure(EntityTypeBuilder<UserBlock> builder)
    {
        builder.HasKey(ub => new { ub.BlockerId, ub.BlockedId });

        builder.HasOne(ub => ub.Blocker)
            .WithMany(u => u.BlockedUsers)
            .HasForeignKey(ub => ub.BlockerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ub => ub.Blocked)
            .WithMany(u => u.BlockedByUsers)
            .HasForeignKey(ub => ub.BlockedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}