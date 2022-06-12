using AutoMapper;
using MovieStore.Actors;
using MovieStore.Genres;
using MovieStore.Movies;
using static MovieStore.Web.Pages.Actors.CreateActorModalModel;
using static MovieStore.Web.Pages.Genres.CreateGenreModalModel;
using static MovieStore.Web.Pages.Movies.CreateMovieModalModel;

namespace MovieStore.Web;

public class MovieStoreWebAutoMapperProfile : Profile
{
    public MovieStoreWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CreateEditMovieViewModel,CreateUpdateMovieDto>();
        CreateMap<MovieDto, CreateEditMovieViewModel>();

        CreateMap<CreateEditGenreViewModel, CreateUpdateGenreDto>();
        CreateMap<GenreDto, CreateEditGenreViewModel>();

        CreateMap<CreateEditActorViewModel, CreateUpdateActorDto>();
        CreateMap<ActorDto, CreateEditActorViewModel>();

    }
}
