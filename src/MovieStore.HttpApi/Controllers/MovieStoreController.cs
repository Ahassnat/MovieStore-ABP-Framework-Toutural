using MovieStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MovieStore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MovieStoreController : AbpControllerBase
{
    protected MovieStoreController()
    {
        LocalizationResource = typeof(MovieStoreResource);
    }
}
