using Microsoft.AspNetCore.Authorization;
using MovieStore.Movies;
using MovieStore.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Actors
{
    //TODO: Add Permissions 
    [Authorize(MovieStorePermissions.Actors.Default)]
    public class ActorAppService : MovieStoreAppService, IActorAppService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository;

        public ActorAppService(IActorRepository actorRepository,
            IMovieRepository movieRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
        }

        [Authorize(MovieStorePermissions.Actors.Create)]
        public async Task CreateAsync(CreateUpdateActorDto input)
        {
            var exstingActor = await _actorRepository.FindByActorName(input.ActorName);
            if (exstingActor != null) throw new ActorAlreadyExistsException(input.ActorName);
            await _actorRepository.InsertAsync(ObjectMapper.Map<CreateUpdateActorDto, Actor>(input));
        }


        [Authorize(MovieStorePermissions.Actors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _actorRepository.DeleteAsync(id);
        }

        public async Task<ActorDto> GetAsync(Guid id)
        {
            var movie = await _actorRepository.GetAsync(id);
            return ObjectMapper.Map<Actor, ActorDto>(movie);
        }

        public async Task<PagedResultDto<ActorDto>> GetListAsync(ActorFilterDto input)
        {
            var queryable = await _actorRepository.GetQueryableAsync();
            queryable = queryable.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.ActorName.ToLower().Contains(input.Filter.ToLower()))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting ?? nameof(Actor.ActorName));

            var actors = await AsyncExecuter.ToListAsync(queryable);
            var count = await _actorRepository.GetCountAsync();

            return new PagedResultDto<ActorDto>
                (
                count,
                ObjectMapper.Map<List<Actor>,List<ActorDto>>(actors)
                );
        }

        public async Task<ListResultDto<MoviesLookupDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetListAsync();
            var movieMap = ObjectMapper.Map<List<Movie>, List<MoviesLookupDto>>(movies);
            return new ListResultDto<MoviesLookupDto> (movieMap);
        }


        [Authorize(MovieStorePermissions.Actors.Edit)]
        public async Task UpdateAsync(Guid id, CreateUpdateActorDto input)
        {
            var exstingActor = await _actorRepository.FindByActorName(input.ActorName);
            if (exstingActor != null) throw new ActorAlreadyExistsException(input.ActorName);

            var actor = await _actorRepository.GetAsync(id);
            ObjectMapper.Map(input,actor);
        }
    }
}
