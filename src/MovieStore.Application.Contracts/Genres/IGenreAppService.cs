using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MovieStore.Genres
{
    public interface IGenreAppService: IApplicationService
    {
        Task<PagedResultDto<GenreDto>> GetListAsync(GenreSearchFilterDto input);
        Task CreateAsync(CreateUpdateGenreDto input);
        Task<GenreDto> GetAsync(Guid id);
        Task UpdateAsync(Guid id, CreateUpdateGenreDto input);
        Task DeleteAsync(Guid id);
    }
}
