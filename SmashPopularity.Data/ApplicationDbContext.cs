using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmashPopularity.Data.Models;

namespace SmashPopularity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Forum> Forums { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostReply> PostReplies { get; set; }
    }
}
