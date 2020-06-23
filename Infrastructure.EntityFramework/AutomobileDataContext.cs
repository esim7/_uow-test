using System;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.EntityFramework
{
    public class AutomobileDataContext : DbContext
    {
        public DbSet<Automobile>Automobiles { get; set; }

        public AutomobileDataContext(DbContextOptions<AutomobileDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }


}
