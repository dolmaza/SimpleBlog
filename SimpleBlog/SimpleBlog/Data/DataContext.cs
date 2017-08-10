using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data.Entities;

namespace SimpleBlog.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region User Configurations

            builder.Entity<User>()
                .HasIndex(u => u.UserName).IsUnique();
            base.OnModelCreating(builder);

            #endregion

            #region Category Configurations

            builder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentId);

            #endregion

        }

        public DbSet<Category> Categories { get; set; }
    }
}
