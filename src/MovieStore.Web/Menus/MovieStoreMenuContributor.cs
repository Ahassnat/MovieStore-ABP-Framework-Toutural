using System.Threading.Tasks;
using MovieStore.Localization;
using MovieStore.MultiTenancy;
using MovieStore.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MovieStore.Web.Menus;

public class MovieStoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<MovieStoreResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MovieStoreMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        //        context.Menu.AddItem(
        // new ApplicationMenuItem(
        // "MovieStore",
        // l["Menu:MovieStore"],
        // icon: "fas fa-shopping-cart"
        // ).AddItem(
        // new ApplicationMenuItem(
        // "MovieStore.Movies",
        // l["Menu:Movies"],
        // url: "/Movies"
        // )
        // )
        //);



        var movieStoreMenu = new ApplicationMenuItem(
    "MoviesStore",
    l["Menu:MovieStore"],
    icon: "fa fa-film"
);

        context.Menu.AddItem(movieStoreMenu);

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(MovieStorePermissions.Movies.Default))
        {
            movieStoreMenu.AddItem(new ApplicationMenuItem(
                "MoviesStore.Movies",
                l["Menu:Movies"],
                url: "/Movies"
            ));
        }

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(MovieStorePermissions.Genres.Default))
        {
            movieStoreMenu.AddItem(new ApplicationMenuItem(
                "MoviesStore.Genres",
                l["Menu:Genres"],
                url: "/Genres"
            ));
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
