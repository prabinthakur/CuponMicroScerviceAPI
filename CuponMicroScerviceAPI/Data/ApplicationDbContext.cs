using CuponMicroScerviceAPI.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace CuponMicroScerviceAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

         
        }

        public DbSet<Cupons> Cupons { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cupons>().HasData(new Cupons
            {
                CuponId = 1,
                CuponCode = "dsfasdfa",
                DiscountAmount = 10,
                MinAmount = 100
            });
        }
    }
}
