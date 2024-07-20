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
    public class IndexModel : PageModel
    {
        private readonly DataModel.OilPaintingArt2024DbContext _context;

        public IndexModel(DataModel.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        public IList<OilPaintingArt> OilPaintingArt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OilPaintingArt = await _context.OilPaintingArts
                .Include(o => o.Supplier).ToListAsync();
        }
    }
}
