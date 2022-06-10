using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MovieStore.Movies
{
    public interface IMovieRepository: IRepository<Movie, Guid>
    {
        Task<Movie> FindByTitle(string title);
    }
}
