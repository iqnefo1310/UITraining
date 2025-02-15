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
    }
}
