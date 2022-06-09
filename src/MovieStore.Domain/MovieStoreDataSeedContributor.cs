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
            var Western = new Genre { Name = "Western" };
            var Comedy = new Genre { Name = "Comedy" };
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
            var mov4 = new Movie 
            {
                Title = "When Harry Met Sally",
                ReleaseDate = new DateTime(1989,2,12),
                Genre = Herror,
                Price = 7.99M
            };
            
            var mov6 = new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = Herror,
                Price = 8.99M
            };
            var mov7 = new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = Comedy,
                Price = 9.99M
            };
            var mov8 = new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = Western,
                Price = 3.99M
            };


            await _movieRepository
 .InsertManyAsync(new[] { mov1, mov2, mov3, mov4, mov6, mov7,mov8 });
           
        }
    }
}
