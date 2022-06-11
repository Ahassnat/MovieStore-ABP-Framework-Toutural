using MovieStore.Actors;
using MovieStore.Genres;
using MovieStore.MoviesActors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MovieStore.Movies
{
    public class Movie: FullAuditedAggregateRoot<Guid>
    {
        public Genre Genre { get; set; }
        public Guid GenreId { get; set; }
        //public Actor Actor { get; set; }
        //public Guid ActorId { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<MovieActor> Actors { get; set; }

    }
}
