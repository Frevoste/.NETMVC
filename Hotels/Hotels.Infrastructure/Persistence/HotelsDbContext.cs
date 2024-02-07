using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Persistence
{
    public class HotelsDbContext : IdentityDbContext
    {
        public DbSet<Domain.Entities.Hotel> Hotel { get; set; }

        public HotelsDbContext(DbContextOptions<HotelsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Hotel>().OwnsOne(c => c.ContactDetails);
        }
    }
}
