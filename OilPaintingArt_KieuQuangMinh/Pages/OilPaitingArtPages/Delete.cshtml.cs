using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;

namespace OilPaintingArt_KieuQuangMinh.Pages.OilPaitingArtPages
{
    public class DeleteModel : PageModel
    {
        private readonly OilPaintingArtService _service;

        public DeleteModel()
        {
            _service ??= new();
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetInt32("r") != 3)
            {
                return RedirectToPage("../Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = _service.GetOilPaintingArt(id.Value);

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            else
            {
                OilPaintingArt = oilpaintingart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
