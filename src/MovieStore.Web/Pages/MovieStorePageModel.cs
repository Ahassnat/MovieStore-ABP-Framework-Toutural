using MovieStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MovieStore.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MovieStorePageModel : AbpPageModel
{
    protected MovieStorePageModel()
    {
        LocalizationResourceType = typeof(MovieStoreResource);
    }
}
