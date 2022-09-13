using BloodManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodManagementSystem.DataAccess
{
    public class BloodDbContext : DbContext
    {
        public BloodDbContext(DbContextOptions<BloodDbContext> options) : base(options)
        {

        }
        public DbSet<SchoolModel> schoolModel { get; set; }
    }
}
