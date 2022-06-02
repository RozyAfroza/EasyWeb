using LearningProject.VModels;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public interface ISettingsService
    {
        Task<VmShop> GetShops();
        Task<VmShop> AddOrEditShop(VmShop vmShop);
        Task<int> DeleteShop(int id);
        Task<VmUser> GetUsers();
    }
}
