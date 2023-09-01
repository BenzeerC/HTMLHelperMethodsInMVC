﻿using HTMLHelperMethodsInMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HTMLHelperMethodsInMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> cities = new List<string>() { "Pune", "Mumbai", "Nashik" };
            ViewData["cities"] = new SelectList(cities);
            ViewData["list"] = new MultiSelectList(cities);
            return View();
        }
        [HttpPost]

        public IActionResult Index(IFormCollection form ,ICollection<string> hobbies)
        {
            ViewBag.UserName = form ["username"];
            ViewBag.Gender = form["gender"];
            ViewBag.Hobbies = form["hobbies"];
            ViewBag.City = form["cities"];
            ViewBag.Comments = form["Comments"];

            return View("ShowInfo");
        }

        public IActionResult Privacy()
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