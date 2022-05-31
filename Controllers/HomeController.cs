using LearningProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                //return View(ModelVM);

            }
            //_context.Models.Add(ModelVM.Model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
