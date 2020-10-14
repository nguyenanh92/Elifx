using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Elifx.EntityFrameworkCore
{
    public static class ElifxDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ElifxDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ElifxDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
