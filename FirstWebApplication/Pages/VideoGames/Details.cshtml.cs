using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FirstWebApplication.Data;
using FirstWebApplication.Models;

namespace FirstWebApplication.Pages.VideoGames
{
    public class DetailsModel : PageModel
    {
        private readonly FirstWebApplication.Data.FirstWebApplicationContext _context;

        public DetailsModel(FirstWebApplication.Data.FirstWebApplicationContext context)
        {
            _context = context;
        }

        public VideoGame VideoGame { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VideoGame = await _context.VideoGame.FirstOrDefaultAsync(m => m.ID == id);

            if (VideoGame == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
