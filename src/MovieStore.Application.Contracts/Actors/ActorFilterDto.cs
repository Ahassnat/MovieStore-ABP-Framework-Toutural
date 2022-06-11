using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Actors
{
    public class ActorFilterDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
   
}
