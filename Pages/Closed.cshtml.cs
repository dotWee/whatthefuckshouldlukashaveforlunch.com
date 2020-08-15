using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WhatTheFuckShouldLukasHaveForLunch.Pages
{
    public class ClosedModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string Reason { get; set; } = null;

        public ClosedModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            Reason = _httpContextAccessor.HttpContext.Session.GetString("Reason");
            
            return Page();
        }
    }
}