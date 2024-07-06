using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Services;

namespace OilPaintingArt_KieuQuangMinh.Pages.OilPaitingArtPages
{
    public class EditModel : PageModel
    {
        private readonly SupplierCompanyService _sCService;
        private readonly OilPaintingArtService _ilPaintingArtService;
        public EditModel()
        {
            _ilPaintingArtService ??= new();
            _sCService = new();
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;
        public List<SupplierCompany> SupplierCompany { get; set; }
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

            var oilpaintingart = _ilPaintingArtService.GetOilPaintingArt(id.Value);

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            OilPaintingArt = oilpaintingart;
            SupplierCompany = _sCService.GetAll();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _ilPaintingArtService.Update(OilPaintingArt);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
