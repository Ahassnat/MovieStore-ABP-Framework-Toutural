using Microsoft.AspNetCore.Authorization;
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
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<Genre, Guid> _genreRepository;

        public MovieAppService(IRepository<Movie,Guid> movieRepository,
                               IRepository<Genre,Guid> genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }
        [Authorize(MovieStorePermissions.Movies.Create)]

        public async Task CreateAsync(CreateUpdateMovieDto input)
        {
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

        public async Task<PagedResultDto<MovieDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _movieRepository
 .WithDetailsAsync(x => x.Genre);
            queryable = queryable
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting ?? nameof(Movie.Title));
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
    }
}
