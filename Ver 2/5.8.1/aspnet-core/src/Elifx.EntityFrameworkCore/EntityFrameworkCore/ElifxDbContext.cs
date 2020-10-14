using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Elifx.Authorization.Roles;
using Elifx.Authorization.Users;
using Elifx.Models;
using Elifx.MultiTenancy;

namespace Elifx.EntityFrameworkCore
{
    public class ElifxDbContext : AbpZeroDbContext<Tenant, Role, User, ElifxDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ElifxDbContext(DbContextOptions<ElifxDbContext> options)
            : base(options)
        {
        }
    }
}
