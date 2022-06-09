using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MovieStore.Web;

[Dependency(ReplaceServices = true)]
public class MovieStoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MovieStore";
}
