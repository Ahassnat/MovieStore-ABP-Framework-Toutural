using MovieStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MovieStore;

[DependsOn(
    typeof(MovieStoreEntityFrameworkCoreTestModule)
    )]
public class MovieStoreDomainTestModule : AbpModule
{

}
