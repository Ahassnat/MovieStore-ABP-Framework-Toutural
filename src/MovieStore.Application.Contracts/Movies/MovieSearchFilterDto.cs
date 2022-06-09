using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MovieStore.Movies
{
    public class MovieSearchFilterDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
