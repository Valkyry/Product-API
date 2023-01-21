using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Entities;
using SampleProject.Infrastructure.Configuration;
using SampleProject.Infrastructure.Identity.Model;

namespace SampleProject.Infrastructure
{
    public class EFContext : IdentityDbContext<ApplicationUser>
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
