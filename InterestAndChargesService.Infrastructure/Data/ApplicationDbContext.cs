using InterestAndChargesService.Domain.Models;
using InterestAndChargesService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestAndChargesService.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<InterestAccrual> InterestAccruals { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InterestAccrual>()
                .Property(x => x.DailyInterestRate)
                .HasPrecision(18, 10);
        }
    }
}
