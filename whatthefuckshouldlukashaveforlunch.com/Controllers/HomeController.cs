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

			var meal = new Meal(DateHelper.CurrentWeeknumber);
            ViewData["Food"] = meal.RandomItem.Name;

            return View();
        }
    }
}