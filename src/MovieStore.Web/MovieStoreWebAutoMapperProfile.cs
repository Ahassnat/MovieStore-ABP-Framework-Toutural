using AutoMapper;
using MovieStore.Movies;
using static MovieStore.Web.Pages.Movies.CreateMovieModalModel;

namespace MovieStore.Web;

public class MovieStoreWebAutoMapperProfile : Profile
{
    public MovieStoreWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CreateEditMovieViewModel,CreateUpdateMovieDto>();
        CreateMap<MovieDto, CreateEditMovieViewModel>();

    }
}
