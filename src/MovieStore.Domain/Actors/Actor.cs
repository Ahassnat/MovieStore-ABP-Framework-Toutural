using MovieStore.MoviesActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MovieStore.Actors
{
    public class Actor: FullAuditedAggregateRoot<Guid>
    {
        public string ActorName { get; set; }

        public string ActorPicture { get; set; }
        public virtual ICollection<MovieActor> Movies { get; set; }
    }
}
