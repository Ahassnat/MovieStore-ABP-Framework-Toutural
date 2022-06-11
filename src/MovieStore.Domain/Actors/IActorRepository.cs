using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MovieStore.Actors
{
    public interface IActorRepository:IRepository<Actor,Guid>
    {
        Task<Actor> FindByActorName(string actorName);
    }
}
