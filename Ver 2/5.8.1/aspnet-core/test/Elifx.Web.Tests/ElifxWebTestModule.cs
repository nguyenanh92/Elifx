using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Elifx.EntityFrameworkCore;
using Elifx.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Elifx.Web.Tests
{
    [DependsOn(
        typeof(ElifxWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ElifxWebTestModule : AbpModule
    {
        public ElifxWebTestModule(ElifxEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElifxWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ElifxWebMvcModule).Assembly);
        }
    }
}