using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MovieStore.Actors
{
    public class ActorAlreadyExistsException: BusinessException
    {
        public ActorAlreadyExistsException(string actorName):base(MovieStoreDomainErrorCodes.ActorAlreadyExists)
        {
            WithData("actorName", actorName);
        }
    }
}
