﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealingHandsMassage.Models;

namespace HealingHandsMassage.Controllers
{
    public class HomeController : Controller
    {
        CarouselContext carouselContext = new CarouselContext();

        public IActionResult Index()
        {
            CarouselItem carouselItem = new CarouselItem("Hello this is Jake");

            carouselContext.CarouselItems.Add(carouselItem);
            

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
