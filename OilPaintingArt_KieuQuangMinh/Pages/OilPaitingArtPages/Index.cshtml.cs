using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Common;
using Repository.Models;
using Services;
using static NuGet.Packaging.PackagingConstants;

namespace OilPaintingArt_KieuQuangMinh.Pages.OilPaitingArtPages
{
    public class IndexModel : PageModel
    {
        private readonly OilPaintingArtService _service;
        public IndexModel()
        {
            _service ??= new();
        }
        [BindProperty]
        public string Style { get; set; }
        [BindProperty]
        public string Artist { get; set; }
        public int TotalPages { get; set; }
        public PaginatedList<OilPaintingArt> OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? pageIndex, string searchStyle, string searchArtist, string style, string artist)
        {
            if (HttpContext.Session.GetInt32("r") != 2 && HttpContext.Session.GetInt32("r") != 3)
            {
                return RedirectToPage("../Index");
            }
            if (!searchStyle.IsNullOrEmpty() || !searchArtist.IsNullOrEmpty()) pageIndex = 1;
            else
            {
                searchStyle = style;
                searchArtist = artist;
            }
            Artist = searchArtist;
            Style = searchStyle;

            var result = _service.GetAll();
            if (!searchStyle.IsNullOrEmpty() || !searchArtist.IsNullOrEmpty()) result = _service.GetBySearching(Style, Artist);

            if (result.Count > 0)
            {
                int pageSize = 2;
                TotalPages = (int)Math.Ceiling(result.Count / (double)pageSize);
                OilPaintingArt = await PaginatedList<OilPaintingArt>.CreateAsync(result, pageIndex ?? 1, pageSize);
                return Page();
            }
            return NotFound();
        }
    }
}
