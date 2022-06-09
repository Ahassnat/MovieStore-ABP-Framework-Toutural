using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MovieStore.Genres
{
    public class GenreAppService : MovieStoreAppService, IGenreAppService
    {
        private readonly IRepository<Genre, Guid> _genreRepository;

        public GenreAppService(IRepository<Genre,Guid> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task CreateAsync(CreateUpdateGenreDto input)
        {
            await _genreRepository.InsertAsync(ObjectMapper.Map<CreateUpdateGenreDto, Genre>(input));
        }

        public  async Task DeleteAsync(Guid id)
        {
            await _genreRepository.DeleteAsync(id); 
        }

        public async Task<GenreDto> GetAsync(Guid id)
        {
            return  ObjectMapper.Map<Genre, GenreDto>( await _genreRepository.GetAsync(id));
           
        }

        public async Task<PagedResultDto<GenreDto>> GetListAsync(GenreSearchFilterDto input)
        {
            var queryable = await _genreRepository.GetQueryableAsync();
 
            queryable = queryable.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Name.ToLower().Contains(input.Filter.ToLower()))
        
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting ?? nameof(Genre.Name));
            var genres = await
           AsyncExecuter.ToListAsync(queryable);
            var count = await _genreRepository.GetCountAsync();
            return new PagedResultDto<GenreDto>(
            count,
            ObjectMapper.Map<List<Genre>, List<GenreDto>>
           (genres)
            );
        }

        public  async Task UpdateAsync(Guid id, CreateUpdateGenreDto input)
        {
            var genre = await _genreRepository.GetAsync(id);
            ObjectMapper.Map(input, genre);
        }
    }
}
