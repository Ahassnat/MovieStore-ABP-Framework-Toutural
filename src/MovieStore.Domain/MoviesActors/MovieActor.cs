using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MovieStore.MoviesActors
{
    // M * M RelationShip 
    public class MovieActor : Entity
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { MovieId, ActorId };
        }
    }
}
