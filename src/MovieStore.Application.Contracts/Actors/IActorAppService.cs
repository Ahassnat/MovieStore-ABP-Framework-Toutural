using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MovieStore.Actors
{
    public interface IActorAppService: IApplicationService
    {
        Task CreateAsync(CreateUpdateActorDto input);
        Task UpdateAsync(Guid id, CreateUpdateActorDto input);
        Task DeleteAsync(Guid id);
        Task<PagedResultDto<ActorDto>> GetListAsync(ActorFilterDto input);
        Task<ActorDto> GetAsync(Guid id);
        Task<ListResultDto<MoviesLookupDto>> GetMoviesAsync();  // to bring Movies with Actor 
    }
}
