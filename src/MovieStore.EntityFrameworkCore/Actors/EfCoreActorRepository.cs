using Microsoft.EntityFrameworkCore;
using MovieStore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MovieStore.Actors
{
    public class EfCoreActorRepository : EfCoreRepository<MovieStoreDbContext, Actor, Guid>, IActorRepository
    {
        public EfCoreActorRepository(IDbContextProvider<MovieStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Actor> FindByActorName(string actorName)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.ActorName == actorName);
        }
    }
}
