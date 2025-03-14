using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using UITraining.Models.Db;

namespace UITraining.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }

        //====================//
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.IdSupplier);

            base.OnModelCreating(modelBuilder);
        }
    }
}
