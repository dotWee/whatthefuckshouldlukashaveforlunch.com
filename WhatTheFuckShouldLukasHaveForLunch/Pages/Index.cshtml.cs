using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhatTheFuckShouldLukasHaveForLunch.Models;
using WhatTheFuckShouldLukasHaveForLunch.Helper;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        public string PageTitle = "What The Fuck Should Lukas Have For Lunch";
        public string PageMessage = "Click to refresh";
        public string FoodName = "";

        public static string CurrentYear => DateTime.Today.Year.ToString();

        public IActionResult OnGet()
        {
            try {
				MealModel meal = new MealModel(DateHelper.CurrentWeeknumber);
                PageMessage = "Lukas doesn't fucking want that";
				FoodName = meal.RandomItem.Name;
                return Page();
                
			} catch {

                return RedirectToPage("./Closed");
            }
        }
    }
}
