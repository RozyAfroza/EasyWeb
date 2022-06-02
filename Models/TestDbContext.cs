using Easy.Common.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public class TestDbContext : DbContext
    {
        private readonly IUserProfileHandler _userProfileHandler;
        public TestDbContext(DbContextOptions<TestDbContext> option, IUserProfileHandler userProfileHandler) : base(option)
        {
            _userProfileHandler = userProfileHandler;
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public Task<int> SaveAsync( bool audit = true)
        {
            return base.SaveChangesAsync();
        }
     

        public IDbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }
    }
}
