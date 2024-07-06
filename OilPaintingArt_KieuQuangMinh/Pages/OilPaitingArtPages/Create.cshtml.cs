using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Models;
using Services;

namespace OilPaintingArt_KieuQuangMinh.Pages.OilPaitingArtPages
{
    public class CreateModel : PageModel
    {
        private readonly SupplierCompanyService _sCService;
        private readonly OilPaintingArtService _ilPaintingArtService;
        public CreateModel()
        {
            _ilPaintingArtService ??= new();
            _sCService = new();
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("r") != 3 )
            {
                return RedirectToPage("../Index");
            }
            SupplierCompany = _sCService.GetAll();
            return Page();
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;
        public List<SupplierCompany> SupplierCompany { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
_ilPaintingArtService
            .Create(OilPaintingArt);

            return RedirectToPage("./Index");
        }
    }
}
