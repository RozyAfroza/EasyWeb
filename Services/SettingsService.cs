using LearningProject.Models;
using LearningProject.VModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Services
{
    public class SettingsService
    {
        private readonly TestDbContext _context;

        public SettingsService(TestDbContext context)
        {
            _context = context;
        }

        public async Task<VmShop> GetShops()
        {
            VmShop shop = new VmShop();
            shop.DataList = await _context.Shops
                .Where(q=>q.IsActive==true)
                .Select(s => new VmShop
                {
                    ID=s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Address = s.Address,
                    ShopNumber = s.ShopNumber,
                    Phone = s.Phone,
                }).ToListAsync();
            return shop;
          
        }

        public async Task<int> DeleteShop(int id)
        {
            int result = -1;
            if (id != 0)
            {
                var shop =await _context.Shops
                    .SingleOrDefaultAsync(q=>q.Id==id);

                shop.IsActive = false;
                 _context.Update(shop);
                result= await _context.SaveChangesAsync(); 
            }
            return result;
        }
    }
}
