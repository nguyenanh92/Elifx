using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Elifx.Configuration.Dto;

namespace Elifx.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ElifxAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
         }
    }
}
