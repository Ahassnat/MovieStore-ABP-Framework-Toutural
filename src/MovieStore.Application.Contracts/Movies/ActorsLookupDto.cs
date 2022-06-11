using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Movies
{
    public class ActorsLookupDto
    {
        // TODO: need more inhansment to get list of Actors by Name as proparty not as object
        public ActorsLookupDto()
        {
            Actors = new HashSet<string>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<string> Actors { get; set; }
    }
}
