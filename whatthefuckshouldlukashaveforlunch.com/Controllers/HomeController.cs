using Microsoft.AspNetCore.Mvc;
using whatthefuckshouldlukashaveforlunch.com.Models;
using whatthefuckshouldlukashaveforlunch.com.Models.Exceptions;
using whatthefuckshouldlukashaveforlunch.com.Models.Helper;

namespace whatthefuckshouldlukashaveforlunch.com.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "What The Fuck Should Lukas Have For Lunch";
            ViewData["Errorfree"] = true;
            ViewData["Year"] = Year.Value;

            try {
				Meal meal = new Meal(DateHelper.CurrentWeeknumber);
                ViewData["Message"] = "Lukas doesn't fucking want that";
				ViewData["Food"] = meal.RandomItem.Name;
			}
            catch
            {
                ViewData["Errorfree"] = false;
				ViewData["Message"] = "Click to refresh";

			}


            return View();
        }
    }
}