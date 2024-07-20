using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModel;

namespace TestPe.Pages.supplier
{
    public class EditModel : PageModel
    {
        private readonly DataModel.OilPaintingArt2024DbContext _context;

        public EditModel(DataModel.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplierCompany SupplierCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliercompany =  await _context.SupplierCompanies.FirstOrDefaultAsync(m => m.SupplierId == id);
            if (suppliercompany == null)
            {
                return NotFound();
            }
            SupplierCompany = suppliercompany;
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

            _context.Attach(SupplierCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierCompanyExists(SupplierCompany.SupplierId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupplierCompanyExists(string id)
        {
            return _context.SupplierCompanies.Any(e => e.SupplierId == id);
        }
    }
}
