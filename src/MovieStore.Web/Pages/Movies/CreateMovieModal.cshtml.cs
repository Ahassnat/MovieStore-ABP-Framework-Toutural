using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Movies;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MovieStore.Web.Pages.Movies
{

    public class CreateMovieModalModel : MovieStorePageModel
    {
        private readonly IMovieAppService _movieAppService;

        [BindProperty]
        public CreateEditMovieViewModel Movie { get; set; }
        
        public SelectListItem[] Genres { get; set; }
        public CreateMovieModalModel(IMovieAppService movieAppService)
        {
            _movieAppService = movieAppService;
        }
        public async Task OnGetAsync()
        {
            Movie = new CreateEditMovieViewModel();

            var genreLookup =await _movieAppService.GetGenrsAsync();
            Genres = genreLookup.Items
            .Select(x => new SelectListItem(x.Name,
           x.Id.ToString()))
            .ToArray();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _movieAppService.CreateAsync(ObjectMapper.Map<CreateEditMovieViewModel, CreateUpdateMovieDto>(Movie));
            return NoContent();
        }

        public class CreateEditMovieViewModel
        {
            [SelectItems("Genres")]
            [DisplayName("Genre")]
            public Guid GenreId { get; set; }
            [Required]

            public string Title { get; set; }

            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }
            [Column(TypeName = "decimal(18, 2)")]
            public decimal Price { get; set; }
        }
    }
}
