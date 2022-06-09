using System.Threading.Tasks;

namespace MovieStore.Data;

public interface IMovieStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
