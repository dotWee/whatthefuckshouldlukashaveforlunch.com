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
    public class AboutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("https://github.com/dotWee/whatthefuckshouldlukashaveforlunch.com");
        }
    }
}
