﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WhatTheFuckShouldLukasHaveForLunch.Models;
using WhatTheFuckShouldLukasHaveForLunch.Helper;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        public static string CurrentYear => DateTime.Today.Year.ToString();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // ViewData["food"] = "Example food";
            // return Page();

            try {
				MealModel meal = new MealModel(DateHelper.CurrentWeeknumber);
				
                ViewData["food"] = meal.RandomItem.Name;
                return Page();
                
			} catch {

                return RedirectToPage("./Closed");
            }
        }
    }
}