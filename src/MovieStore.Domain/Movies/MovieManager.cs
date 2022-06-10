//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp;
//using Volo.Abp.Domain.Services;

//namespace MovieStore.Movies
//{
//    public class MovieManager:DomainService
//    {
//        private readonly IMovieRepository _movieRepository;

//        public MovieManager(IMovieRepository movieRepository)
//        {
//            _movieRepository = movieRepository;
//        }
//        public async Task<Movie> CreateAsync([NotNull] string title)
//        {
//            Check.NotNullOrWhiteSpace(title, nameof(title));

//            var existingMovie = await _movieRepository.FindByTitle(title);
//            if (existingMovie != null)
//            {
//                throw new MovieAlreadyExistsException(title);
//            }

//            return existingMovie;
//        }

//        public async Task UpdateAsync(
//           [NotNull] Movie movie,
//           [NotNull] string newTitle)
//        {
//            Check.NotNull(movie, nameof(movie));
//            Check.NotNullOrWhiteSpace(newTitle, nameof(newTitle));

//            var existingMovie = await _movieRepository.FindByTitle(newTitle);
//            if (existingMovie != null)
//            {
//                throw new MovieAlreadyExistsException(newTitle);
//            }
//        }
//    }
//}
