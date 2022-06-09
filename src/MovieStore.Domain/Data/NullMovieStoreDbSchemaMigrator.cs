using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MovieStore.Data;

/* This is used if database provider does't define
 * IMovieStoreDbSchemaMigrator implementation.
 */
public class NullMovieStoreDbSchemaMigrator : IMovieStoreDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
