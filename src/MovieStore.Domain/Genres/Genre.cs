﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MovieStore.Genres
{
    public class Genre : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
  
}
