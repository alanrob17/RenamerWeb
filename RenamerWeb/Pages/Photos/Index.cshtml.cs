using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RenamerWeb.Data;
using RenamerWeb.Models;

namespace RenamerWeb.Pages.Photos
{
    public class IndexModel : PageModel
    {
        private readonly RenamerWebContext _context;

        public IndexModel(RenamerWebContext context)
        {
            _context = context;
        }

        public IList<Photo> Photo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Photo != null)
            {
                Photo = await _context.Photo.ToListAsync();
            }
        }
    }
}
