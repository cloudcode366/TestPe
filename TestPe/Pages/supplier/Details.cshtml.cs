﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataModel;

namespace TestPe.Pages.supplier
{
    public class DetailsModel : PageModel
    {
        private readonly DataModel.OilPaintingArt2024DbContext _context;

        public DetailsModel(DataModel.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        public SupplierCompany SupplierCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliercompany = await _context.SupplierCompanies.FirstOrDefaultAsync(m => m.SupplierId == id);
            if (suppliercompany == null)
            {
                return NotFound();
            }
            else
            {
                SupplierCompany = suppliercompany;
            }
            return Page();
        }
    }
}
