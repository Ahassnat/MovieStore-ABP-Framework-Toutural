using Microsoft.AspNetCore.Authorization;
using MovieStore.Actors;
using MovieStore.Genres;
using MovieStore.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MovieStore.Movies
{
    [Authorize(MovieStorePermissions.Movies.Default)]
    public class MovieAppService : MovieStoreAppService, IMovieAppService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IRepository<Genre, Guid> _genreRepository;
        private readonly IRepository<Actor, Guid> _actorRepository;

        // private readonly MovieManager _movieManager;

        public MovieAppService(IMovieRepository movieRepository,
                               IRepository<Genre,Guid> genreRepository,
                               IRepository<Actor, Guid> actorRepository
                               /*MovieManager movieManager*/)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            //_movieManager = movieManager;
        }
        [Authorize(MovieStorePermissions.Movies.Create)]

        public async Task CreateAsync(CreateUpdateMovieDto input)
        {
            var existingMovie = await _movieRepository.FindByTitle(input.Title);
            if (existingMovie != null)
            {
                throw new MovieAlreadyExistsException(input.Title);
            }
            await _movieRepository.InsertAsync( ObjectMapper.Map<CreateUpdateMovieDto, Movie>(input));
        }
        
        public async Task<MovieDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Movie, MovieDto>(
 await _movieRepository.GetAsync(id)
 );
        }
        [Authorize(MovieStorePermissions.Movies.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateMovieDto input)
        {
            var existingMovie = await _movieRepository.FindByTitle(input.Title);
            if (existingMovie != null)
            {
                throw new MovieAlreadyExistsException(input.Title);
            }


            var movie = await _movieRepository.GetAsync(id);
            ObjectMapper.Map(input, movie);
        }

        public async Task<ListResultDto<GenreLookupDto>> GetGenrsAsync()
        {
            var genres = await _genreRepository.GetListAsync();
            return new ListResultDto<GenreLookupDto>(
            ObjectMapper
            .Map<List<Genre>, List<GenreLookupDto>>
           (genres)
            );
        }

        public async Task<PagedResultDto<MovieDto>> GetListAsync(MovieSearchFilterDto input)
        {
            var queryable = await _movieRepository
 .WithDetailsAsync(x => x.Genre);
            //TODO Add Actor to query
            //var queryable = await _movieRepository
            //.WithDetailsAsync(); // => Mapping to list of genre and actors from DbContext Module


            queryable = queryable.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Title.ToLower().Contains(input.Filter.ToLower()))
               // .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Genre.Name.ToLower().Contains(input.Filter.ToLower()))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting.IsNullOrEmpty() ? "id" : input.Sorting);

         
            

            var movies = await
           AsyncExecuter.ToListAsync(queryable);
            var count = await _movieRepository.GetCountAsync();
            return new PagedResultDto<MovieDto>(
            count,
            ObjectMapper.Map<List<Movie>, List<MovieDto>>
           (movies)
            );
        }

        [Authorize(MovieStorePermissions.Movies.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        
        public async Task<PagedResultDto<MovieDto>> GetListFiltterAsync(MovieSearchFilterDto input)
        {
            var queryable = await _movieRepository.GetQueryableAsync();
            var query = queryable.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Title.ToLower()
                .Contains(input.Filter.ToLower()))
                .OrderBy(input.Sorting ?? nameof(Movie.Title).ToLower())
                .PageBy(input);


            var count = await AsyncExecuter.CountAsync(query);
            var movies = await AsyncExecuter.ToListAsync(query);

            var result = ObjectMapper.Map<List<Movie>, List<MovieDto>>(movies);

            return new PagedResultDto<MovieDto> { Items = result, TotalCount = count };
        }

        //TODO: Get Actors 
        public async Task<ListResultDto<ActorsLookupDto>> GetActorsAsync()
        {
            var actors = await _actorRepository.GetListAsync();
            return new ListResultDto<ActorsLookupDto>(
            ObjectMapper
            .Map<List<Actor>, List<ActorsLookupDto>>
           (actors)
            );
        }
    }
}
