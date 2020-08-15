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
using WhatTheFuckShouldLukasHaveForLunch.Exceptions;
using Microsoft.AspNetCore.Http;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public static string CurrentYear => DateTime.Today.Year.ToString();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGet()
        {
            var client = _clientFactory.CreateClient();

            try
            {
                MealModel meal = new MealModel(DateHelper.CurrentWeeknumber, client);
                var randomItem = await meal.GetRandomFoodAsync();

                ViewData["food"] = randomItem.Name;
                Console.WriteLine($"Index Page: Meal={meal.ToString()} ViewData[food]={randomItem.ToString()}");

                return Page();
            }
            catch (MensaClosedException e)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Reason", e.Message);

                Console.WriteLine("Error: {0}", e);
                return RedirectToPage("./Closed");
            }
        }
    }
}
