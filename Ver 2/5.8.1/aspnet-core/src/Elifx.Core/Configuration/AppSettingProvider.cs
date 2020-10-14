using System.Collections.Generic;
using Abp.Configuration;

namespace Elifx.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.CompanyName, "Elifx", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Description, "Elifx", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Phone, "0981769974", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Address, "HN", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Hotline, "0981769974", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),   
                
                new SettingDefinition(AppInfoSettingNames.Zalo, "0981769974", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Facebook, "#", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Youtube, "#", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Instagram, "#", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.Website, "#", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.MetaTitle, "Elifx", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppInfoSettingNames.MetaDescription, "Elifx", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

            };
        }
    }
}
