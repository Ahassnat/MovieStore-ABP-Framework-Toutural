using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieStore.Genres;
using System.Threading.Tasks;

namespace MovieStore.Web.Pages.Genres
{
    public class CreateGenreModalModel : MovieStorePageModel
    {
        private readonly IGenreAppService _genreAppService;

        [BindProperty]
        public CreateEditGenreViewModel Genre { get; set; }

        public CreateGenreModalModel(IGenreAppService genreAppService)
        {
            _genreAppService = genreAppService;
        }
        public void OnGet()
        {
            Genre = new CreateEditGenreViewModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _genreAppService.CreateAsync(ObjectMapper.Map<CreateEditGenreViewModel, CreateUpdateGenreDto>(Genre));
            return NoContent();
        }

        public class CreateEditGenreViewModel
        {
           
            public string Name { get; set; }

           
        }
    }
}
