using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> option) : base(option)
        {

        }

        public DbSet<UserCridential> UserCridentials { get; set; }
        public DbSet<Shop> Shops { get; set; }

    }
}
