using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwixterR.Domain.Entities;

namespace TwixterR.Persistence.Contexts;

public class BaseDbContext(DbContextOptions options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostMedia> PostMedias { get; set; }
    public DbSet<UserBlock> UserBlocks { get; set; }
    public DbSet<UserFollower> UserFollowers { get; set; }
}