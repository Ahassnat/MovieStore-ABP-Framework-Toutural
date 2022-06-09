using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Genres
{
    public class GenreSearchFilterDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
