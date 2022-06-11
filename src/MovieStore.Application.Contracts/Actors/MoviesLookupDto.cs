using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Actors
{
    public class MoviesLookupDto
    {
        // TODO: need more inhansment to get list of Movies by Name as proparty not as object
        public MoviesLookupDto()
        {
           Movies = new HashSet<string>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<string> Movies { get; set; }
    }
}
