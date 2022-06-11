using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Actors
{
    public class CreateUpdateActorDto
    {
        public Guid MovieId { get; set; }
        public string ActorName { get; set; }

        public string ActorPicture { get; set; }
    }
}
