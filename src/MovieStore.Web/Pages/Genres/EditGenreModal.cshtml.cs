using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieStore.Genres;
using System;
using System.Threading.Tasks;
using static MovieStore.Web.Pages.Genres.CreateGenreModalModel;


namespace MovieStore.Web.Pages.Genres
{
    public class EditGenreModalModel : MovieStorePageModel
    {
        private readonly IGenreAppService _genreAppService;
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateEditGenreViewModel Genre { get; set; }
    
        public EditGenreModalModel(IGenreAppService genreAppService)
        {
            _genreAppService = genreAppService;
        }
        public async Task OnGetAsync()
        {
            var genreDto = await _genreAppService.GetAsync(Id);
            Genre = ObjectMapper.Map<GenreDto, CreateEditGenreViewModel>(genreDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _genreAppService.UpdateAsync(Id,
            ObjectMapper.Map<CreateEditGenreViewModel,
           CreateUpdateGenreDto>(Genre)
            );
            return NoContent();
        }


    }
}
