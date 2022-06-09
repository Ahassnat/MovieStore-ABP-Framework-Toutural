using Volo.Abp.Modularity;

namespace MovieStore;

[DependsOn(
    typeof(MovieStoreApplicationModule),
    typeof(MovieStoreDomainTestModule)
    )]
public class MovieStoreApplicationTestModule : AbpModule
{

}
