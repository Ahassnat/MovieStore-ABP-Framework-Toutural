using MovieStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MovieStore.Permissions;

public class MovieStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
       // var myGroup = context.AddGroup(MovieStorePermissions.GroupName);
        var movieStoreGroup = context.AddGroup(MovieStorePermissions.GroupName);

        var moviesPermission = movieStoreGroup.AddPermission(MovieStorePermissions.Movies.Default, L("Permission:Movies"));
        moviesPermission.AddChild(MovieStorePermissions.Movies.Create, L("Permission:Movies.Create"));
        moviesPermission.AddChild(MovieStorePermissions.Movies.Edit, L("Permission:Movies.Edit"));
        moviesPermission.AddChild(MovieStorePermissions.Movies.Delete, L("Permission:Movies.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(MovieStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieStoreResource>(name);
    }
}
