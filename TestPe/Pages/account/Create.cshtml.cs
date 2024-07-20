using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataModel;

namespace TestPe.Pages.account
{
    public class CreateModel : PageModel
    {
        private readonly DataModel.OilPaintingArt2024DbContext _context;

        public CreateModel(DataModel.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SystemAccounts.Add(SystemAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
