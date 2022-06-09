using MovieStore.Genres;
using MovieStore.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MovieStore
{
    public class MovieStoreDataSeedContributor :
 IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Movie, Guid> _movieRepository;
        private readonly IRepository<Genre, Guid> _genreRepository;

        public MovieStoreDataSeedContributor(IRepository<Movie,Guid> movieRepository,
                                            IRepository<Genre,Guid> genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _genreRepository.CountAsync() > 0)
            {
                return;
            }
            var Drama = new Genre { Name = "Drama" };
            var Herror = new Genre { Name = "Herror" };
            await _genreRepository
             .InsertManyAsync(new[] { Drama, Herror });
            var mov1 = new Movie
            {
                Genre = Drama,
                Title = "Pray",
               Price = 163,
               ReleaseDate = new DateTime(2012, 05, 24)
            };
            var mov2 = new Movie
            {
                Genre = Drama,
                Title = "Love",
                Price = 163,
                ReleaseDate = new DateTime(2017, 05, 24)
            };
            var mov3 = new Movie
            {
                Genre = Herror,
                Title = "Saw",
                Price = 163,
                ReleaseDate = new DateTime(2018, 05, 24)
            };
          

            await _movieRepository
 .InsertManyAsync(new[] { mov1, mov2, mov3 });
           
        }
    }
}
