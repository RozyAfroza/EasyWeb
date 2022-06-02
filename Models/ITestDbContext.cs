using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace LearningProject.Models
{
    public interface ITestDbContext
    {

        DbSet<Shop> Shops { get; set; }
        DbSet<UserCredential> UserCredentials { get; set; }
        DbSet<UserPermission> UserPermissions { get; set; }

        IDbContextTransaction BeginTransaction();

        Task<int> SaveAsync(bool audit = true);
 

    }
}
