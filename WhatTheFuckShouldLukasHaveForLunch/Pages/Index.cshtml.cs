using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhatTheFuckShouldLukasHaveForLunch.Networks;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class IndexModel : PageModel
    {
        public string ItemName { get; private set; }

        public bool ShowClosedMessage { get; private set; } = false;

        public void OnGet()
        {
            var today = DateTime.Now.DayOfWeek;
            if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday) {
                ShowClosedMessage = true;
            }

            else {
                var menu = MensaProxy.GetMenu(today);
                var randomItem = menu.GetRandomItem();

                if (randomItem == null)
                {
                    ShowClosedMessage = true;
                }

                else
                {
                    ItemName = randomItem.name;
                }
            }
        }
    }
}
