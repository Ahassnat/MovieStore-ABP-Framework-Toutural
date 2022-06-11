using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Movies;
using System;
using System.Linq;
using System.Threading.Tasks;
using static MovieStore.Web.Pages.Movies.CreateMovieModalModel;

namespace MovieStore.Web.Pages.Movies
{
    public class EditMovieModalModel : MovieStorePageModel
    {
        private readonly IMovieAppService _movieAppService;
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateEditMovieViewModel Movie { get; set; }
        public SelectListItem[] Genres { get; set; }
        public SelectListItem[] Actors { get; set; }
        public EditMovieModalModel(IMovieAppService movieAppService)
        {
            _movieAppService = movieAppService;
        }
        public async Task OnGetAsync()
        {
            var movieDto = await _movieAppService.GetAsync(Id);
            Movie = ObjectMapper.Map<MovieDto, CreateEditMovieViewModel>(movieDto);

          
            var genreLookup = await _movieAppService.GetGenrsAsync();
            Genres = genreLookup.Items
            .Select(x => new SelectListItem(x.Name,
           x.Id.ToString()))
            .ToArray();

            //TODO: SelectMany LINQ statment to select many of actors 
            var actorLookup = await _movieAppService.GetActorsAsync();
            Actors = actorLookup.Items
            .Select(x => new SelectListItem(x.Name,
           x.Id.ToString()))
            .ToArray();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _movieAppService.UpdateAsync(Id,
            ObjectMapper.Map<CreateEditMovieViewModel,
           CreateUpdateMovieDto>(Movie)
            );
            return NoContent();
        }

        
    }
}
