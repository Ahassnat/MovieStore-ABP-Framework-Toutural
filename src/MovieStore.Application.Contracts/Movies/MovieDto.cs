using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Movies
{
    public class MovieDto: AuditedEntityDto<Guid>
    {
        public string GenreName { get; set; }
        public Guid GenreId { get; set; }
        public string ActorName { get; set; }
        public Guid ActorId { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
