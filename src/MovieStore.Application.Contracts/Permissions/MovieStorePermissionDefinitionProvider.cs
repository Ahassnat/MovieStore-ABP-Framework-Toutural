using MovieStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MovieStore.Permissions;

public class MovieStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MovieStorePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MovieStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieStoreResource>(name);
    }
}
