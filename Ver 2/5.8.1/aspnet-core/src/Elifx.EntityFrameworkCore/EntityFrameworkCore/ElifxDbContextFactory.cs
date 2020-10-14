using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Elifx.Configuration;
using Elifx.Web;

namespace Elifx.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ElifxDbContextFactory : IDesignTimeDbContextFactory<ElifxDbContext>
    {
        public ElifxDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ElifxDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ElifxDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ElifxConsts.ConnectionStringName));

            return new ElifxDbContext(builder.Options);
        }
    }
}
