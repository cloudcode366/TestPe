using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModel;

namespace TestPe.Pages.art
{
    public class DeleteModel : PageModel
    {
        private readonly DataModel.OilPaintingArt2024DbContext _context;

        public DeleteModel(DataModel.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = await _context.OilPaintingArts.FirstOrDefaultAsync(m => m.OilPaintingArtId == id);

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

            var oilpaintingart = await _context.OilPaintingArts.FindAsync(id);
            if (oilpaintingart != null)
            {
                OilPaintingArt = oilpaintingart;
                _context.OilPaintingArts.Remove(OilPaintingArt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
