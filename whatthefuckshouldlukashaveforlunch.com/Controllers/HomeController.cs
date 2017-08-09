using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using whatthefuckshouldlukashaveforlunch.com.Models;

namespace whatthefuckshouldlukashaveforlunch.com.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "What The Fuck Should Lukas Have For Lunch";
            ViewData["Year"] = Year.Value;
            
            return View();
        }
    }
}
