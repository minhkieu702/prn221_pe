using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Repository.Common;
using Repository.Models;
using Services;
using static NuGet.Packaging.PackagingConstants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OilPaintingArt_KieuQuangMinh.Pages.OilPaitingArtPages
{
    public class IndexModel : PageModel
    {
        private readonly OilPaintingArtService _service;
        public IndexModel()
        {
            _service ??= new();
        }
        public string? StyleSearching { get; set; }
        public string? ArtistSearching { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public List<OilPaintingArt> ListOPA { get; set; }
        private readonly int pageSize = 2;
        public IActionResult OnGet(int newCurPage = 1, string style = @"", string artist = @"")
        {
            if (!(HttpContext.Session.GetInt32("r") == 2 || HttpContext.Session.GetInt32("r") == 3))
            {
                TempData["message"] = "You don't have enough permission. Please try another email.";
                return RedirectToPage("../Index");
            }
            try
            {
                CurrentPage = newCurPage;
                StyleSearching = style;
                ArtistSearching = artist;

                var list = _service.GetBySearching(StyleSearching, ArtistSearching);
                
                TotalPages = (int)Math.Ceiling(list.Count / (double)pageSize);
                ListOPA = list.Skip(
                (CurrentPage - 1) * pageSize)
                .Take(pageSize).ToList();
                return Page();
            }
            catch (Exception ez)
            {
                TempData["message"] = ez.Message;
                return Page();
            }
        }
    }
}
