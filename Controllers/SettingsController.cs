using LearningProject.Models;
using LearningProject.Services;
using LearningProject.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Controllers
{
    public class SettingsController : Controller
    {
        private HttpContext httpContext;
        private readonly TestDbContext _context;
        private readonly SettingsService _service;
        public SettingsController(TestDbContext context, SettingsService service)
        {
            _context = context;
            _service = service;
        }

        //public IActionResult ShopIndex()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> AddOrEditShop(int id=0)
        {
            if(id == 0)
            {
                return View();
            }
            else
            {
                var shop= await _context.Shops.FindAsync(id);
                if (shop == null)
                {
                    return NotFound();
                }
                else
                {
                  return  View(shop);
                }
            }
              
        }
        [HttpGet]
        public async Task<ActionResult> ShopIndex()
        {
            VmShop vmShop = new VmShop();
            vmShop = await Task.Run(() => _service.GetShops());
            return View(vmShop);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteShop(int id)
        {
             await Task.Run(() => _service.DeleteShop(id));
            return RedirectToAction(nameof(ShopIndex));
        }
    


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddOrEdit(int id, [Bind("ShopId,Name,Description,ShopNumber,Address,Phone")] Shop shop)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Insert
        //        if (id == 0)
        //        {
        //            shop.Created = DateTime.Now;
        //            shop.CreatedBy = "TestUser";
        //            _context.Add(shop);
        //            await _context.SaveChangesAsync();
        //        }
        //        //Update
        //        else
        //        {
        //            try
        //            {
        //                _context.Update(shop);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shops.ToList()) });
        //    }
        //    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", shop) });
        //}
    }
}
