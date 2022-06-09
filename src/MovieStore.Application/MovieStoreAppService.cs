using System;
using System.Collections.Generic;
using System.Text;
using MovieStore.Localization;
using Volo.Abp.Application.Services;

namespace MovieStore;

/* Inherit your application services from this class.
 */
public abstract class MovieStoreAppService : ApplicationService
{
    protected MovieStoreAppService()
    {
        LocalizationResource = typeof(MovieStoreResource);
    }
}
