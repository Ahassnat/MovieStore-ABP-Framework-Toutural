using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Actors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace MovieStore.Web.Pages.Actors
{
    public class CreateActorModalModel : MovieStorePageModel
    {
        [BindProperty]
        public CreateEditActorViewModel Actor { get; set; }

        //public SelectListItem[] Movies { get; set; }
        private readonly IActorAppService _actorAppService;

        public CreateActorModalModel(IActorAppService actorAppService)
        {
            _actorAppService = actorAppService;
        }
        public  void OnGet()
        {
            Actor = new CreateEditActorViewModel();
           // var actorLookup = await _actorAppService.GetMoviesAsync();
           // Movies = actorLookup.Items
           // .Select(x => new SelectListItem(x.Name,
           //x.Id.ToString()))
           // .ToArray();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var actor = ObjectMapper.Map<CreateEditActorViewModel, CreateUpdateActorDto>(Actor);
             await _actorAppService.CreateAsync(actor);
            return NoContent();
        }

       public class CreateEditActorViewModel
        {
            //[SelectItems("Movies")]
            //[DisplayName("Movie")]
            //public Guid MovieId { get; set; }
            public string ActorName { get; set; }

            public string ActorPicture { get; set; }
        }
    }
}
