using AutoMapper;
using MovieStore.Actors;
using MovieStore.Genres;
using MovieStore.Movies;

namespace MovieStore;

public class MovieStoreApplicationAutoMapperProfile : Profile
{
    public MovieStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Movie, MovieDto>();
        CreateMap<CreateUpdateMovieDto, Movie>();
        CreateMap<Genre, GenreLookupDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<CreateUpdateGenreDto, Genre>();


        CreateMap<Actor, ActorLookupDto>();
       
    }
}
