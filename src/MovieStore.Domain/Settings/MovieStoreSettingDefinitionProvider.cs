using Volo.Abp.Settings;

namespace MovieStore.Settings;

public class MovieStoreSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MovieStoreSettings.MySetting1));
    }
}
