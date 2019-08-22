using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealingHandsMassage.Models;
using HealingHandsMassage.Data;
using Microsoft.AspNetCore.Authorization;

namespace HealingHandsMassage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["firstItem"] = _context.CarouselItems.FirstOrDefault().TextInJson;

            return View();
        }

        [HttpPost]
        public ActionResult CreateCarouselItem(CarouselItem item)
        {
            CarouselHelper.AddAndSave(item, _context);
            return null;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
