using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FirstWebApplication.Data;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstWebApplication.Pages.VideoGames
{
    public class IndexModel : PageModel
    {
        private readonly FirstWebApplication.Data.FirstWebApplicationContext _context;

        public IndexModel(FirstWebApplication.Data.FirstWebApplicationContext context)
        {
            _context = context;
        }

        public IList<VideoGame> VideoGame { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchGame { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameGenre { get; set; }
        public string Rating { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.VideoGame
                                            orderby m.Genre
                                            select m.Genre;

            var games = from g in _context.VideoGame
                        select g;
            if(!string.IsNullOrEmpty(SearchGame))
            {
                games = games.Where(value => value.Name.Contains(SearchGame));
            }

            if (!string.IsNullOrEmpty(GameGenre))
            {
                games = games.Where(value => value.Genre == GameGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            VideoGame = await games.ToListAsync();
        }
    }
}
