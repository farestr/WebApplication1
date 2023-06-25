using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { 
          
        }

        public DbSet<Cities> Cities { get; set;  }
        public DbSet<Customer> customer { get; set; }

    }
}
