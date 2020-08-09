using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WhatTheFuckShouldLukasHaveForLunch.Models;
using WhatTheFuckShouldLukasHaveForLunch.Helper;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public static string CurrentYear => DateTime.Today.Year.ToString();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGet()
        {
            var client = _clientFactory.CreateClient();

            MealModel meal = new MealModel(DateHelper.CurrentWeeknumber, client);
            var randomItem = await meal.GetRandomFoodAsync();
            if (randomItem != null)
            {
                ViewData["food"] = randomItem.Name;
                Console.WriteLine($"Index Page: Meal={meal.ToString()} ViewData[food]={randomItem.ToString()}");
                return Page();
            }
            else
            {
                return RedirectToPage("./Closed");
            }
        }
    }
}
