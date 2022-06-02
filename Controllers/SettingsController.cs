using Easy.Common.Enums;
using LearningProject.Models;
using LearningProject.Services;
using LearningProject.VModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Controllers
{
   // [Authorize(Roles = AuthorizeRoleCollection.Employee)]
    public class SettingsController : Controller
    {
        private HttpContext httpContext;
        private readonly TestDbContext _context;
        private readonly ISettingsService _service;
        public SettingsController(TestDbContext context, ISettingsService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult CreateShop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEditShop(VmShop vmShop)
        {
            await Task.Run(() => _service.AddOrEditShop(vmShop));
            return RedirectToAction(nameof(ShopIndex)); 
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

        [HttpGet]
        public async Task<ActionResult> UserIndex()
        {
            VmUser vmUser = new VmUser();
            vmUser = await Task.Run(() => _service.GetUsers());
            return View(vmUser);
          
        }

    }
}
