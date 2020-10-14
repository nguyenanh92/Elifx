namespace Database.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ElifxDbContext : DbContext
    {
        public ElifxDbContext()
            : base("name=ElifxDbContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<MailConfig> MailConfigs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Copyright)
                .IsFixedLength();

            modelBuilder.Entity<MailConfig>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<MailConfig>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<MailConfig>()
                .Property(e => e.Smtp)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Article>()
                .Property(e => e.Alias)
                .IsUnicode(false);
        }
    }
}
