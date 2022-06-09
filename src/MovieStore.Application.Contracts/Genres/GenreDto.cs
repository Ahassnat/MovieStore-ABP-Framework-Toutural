using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Genres
{
    public class GenreDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
