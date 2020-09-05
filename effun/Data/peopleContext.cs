using effun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace effun.Data
{
    public class peopleContext : DbContext
    {
        public peopleContext(DbContextOptions<peopleContext> options) : base(options)
        {

        }
        public DbSet<person> Peopl { get; set; }
    }
}
