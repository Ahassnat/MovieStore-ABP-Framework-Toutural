using MovieStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MovieStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MovieStoreEntityFrameworkCoreModule),
    typeof(MovieStoreApplicationContractsModule)
    )]
public class MovieStoreDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
