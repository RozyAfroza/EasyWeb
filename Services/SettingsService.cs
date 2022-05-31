using LearningProject.Models;
using LearningProject.VModels;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<VmShop> AddOrEditShop(VmShop vmShop)
        {
            var ObjectToSave = await _context.Shops
                .SingleOrDefaultAsync(q => q.Id == vmShop.ID);
            if(ObjectToSave == null)
            {
                ObjectToSave=  new Shop();
                ObjectToSave.Created = DateTime.Now;
                ObjectToSave.CreatedBy = "TestUser";
                ObjectToSave.IsActive = true;
                await _context.AddAsync(ObjectToSave);

            }
            else
            {
                ObjectToSave.Modified = DateTime.Now;
                ObjectToSave.ModifiedBy = "ModifiedBy";
            }

            ObjectToSave.Name = vmShop.Name;
            ObjectToSave.Description = vmShop.Description;
            ObjectToSave.Address = vmShop.Address;
            ObjectToSave.ShopNumber = vmShop.ShopNumber;
            ObjectToSave.Phone = vmShop.Phone;
            
           
            await _context.SaveChangesAsync();

            return vmShop;
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
