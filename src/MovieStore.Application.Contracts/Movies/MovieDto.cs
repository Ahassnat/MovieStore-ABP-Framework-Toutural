using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Movies
{
    public class MovieDto: AuditedEntityDto<Guid>
    {
        public string GenreName { get; set; }
        public Guid GenreId { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
