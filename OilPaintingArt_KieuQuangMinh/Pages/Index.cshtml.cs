using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Models;
using Services;

namespace OilPaintingArt_KieuQuangMinh.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SystemAccount SystemAccount { get; set; }

        public SystemAccountService _service;
        public IndexModel()
        {
            _service ??= new();
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            
            var account = _service.Login(SystemAccount.AccountEmail, SystemAccount.AccountPassword);
            if (account == null)
            {
                return Page();
            }
            HttpContext.Session.SetInt32("r", account.Role.Value);
            return RedirectToPage("./OilPaitingArtPages/Index");
        }
    }
}
