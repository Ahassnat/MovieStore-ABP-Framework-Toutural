using Microsoft.EntityFrameworkCore;
using MovieStore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MovieStore.Movies
{
    public class EfCoreMovieRepository : EfCoreRepository<MovieStoreDbContext, Movie, Guid>, IMovieRepository
    {
        public EfCoreMovieRepository(IDbContextProvider<MovieStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Movie> FindByTitle(string title)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.Title == title);
        }
    }
}
