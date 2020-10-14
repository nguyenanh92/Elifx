using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Elifx.Authorization;

namespace Elifx
{
    [DependsOn(
        typeof(ElifxCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ElifxApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ElifxAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ElifxApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
