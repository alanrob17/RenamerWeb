using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RenamerWeb.Data;
using RenamerWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //public SelectList Genres { get; set; }

        public SelectList Folders { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Photo != null)
            {
                // Use LINQ to get list of genres.
                var folderQuery = from p in _context.Photo
                                  select p.Folder;

                var photos = from p in _context.Photo
                             select p;

                Folders = new SelectList(await folderQuery.Distinct().ToListAsync());
                Photo = await photos.ToListAsync();
            }
        }

        //public IActionResult OnPost()
        //{
        //    // Use the SelectedFolder property to access the selected folder.
        //    string selectedFolder = SelectedFolder;

        //    // Your logic here...

        //    return Page();
        //}
    }
}
