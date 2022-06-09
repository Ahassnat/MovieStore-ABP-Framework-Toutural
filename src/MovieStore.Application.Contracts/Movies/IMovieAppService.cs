using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MovieStore.Movies
{
    public interface IMovieAppService: IApplicationService
    {
        Task<PagedResultDto<MovieDto>>GetListAsync(PagedAndSortedResultRequestDto input);
        Task CreateAsync(CreateUpdateMovieDto input);
        Task<ListResultDto<GenreLookupDto>> GetGenrsAsync();
        Task<MovieDto> GetAsync(Guid id);
        Task UpdateAsync(Guid id, CreateUpdateMovieDto input);
        Task DeleteAsync(Guid id);

    }
}
