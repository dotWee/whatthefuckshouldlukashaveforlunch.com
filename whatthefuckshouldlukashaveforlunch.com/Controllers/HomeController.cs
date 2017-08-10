using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using whatthefuckshouldlukashaveforlunch.com.Models;
using whatthefuckshouldlukashaveforlunch.com.Models.Helper;

namespace whatthefuckshouldlukashaveforlunch.com.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "What The Fuck Should Lukas Have For Lunch";
            ViewData["Year"] = Year.Value;

			Meal meal = new Meal(DateHelper.CurrentWeeknumber);
            ViewData["Food"] = meal.GetRandom().Name;

            return View();
        }
    }
}