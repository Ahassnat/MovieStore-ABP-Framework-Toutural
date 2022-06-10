using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MovieStore.Movies
{
    public class MovieAlreadyExistsException: BusinessException
    {
        public MovieAlreadyExistsException(string title):base(MovieStoreDomainErrorCodes.MovieAlreadyExists)
        {
            WithData("title", title);
        }
    }
}
