using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Actors
{
    public class ActorDto: AuditedEntityDto<Guid>
    {
        public string MovieName { get; set; }
        public Guid MovieId { get; set; }
        public string ActorName { get; set; }

        public string ActorPicture { get; set; }
    }
}
