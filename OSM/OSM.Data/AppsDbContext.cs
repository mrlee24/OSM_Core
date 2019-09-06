using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OSM.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace OSM.Data
{
    public class AppsDbContext : DbContext
    {
        #region Database Object
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        #endregion

        public AppsDbContext()
        {
        }

        public AppsDbContext(DbContextOptions<AppsDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=DESKTOP-RCBJMDJ\\SQLEXPRESS;Initial Catalog=OSM;Integrated Security=True;Pooling=False";
            base.OnConfiguring(optionsBuilder); optionsBuilder.UseSqlServer(connection);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public virtual void Save()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Select relationship from multiple collection
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            //Composite keys can only be configured using the Fluent API
            //Auto mappting
        }
    }
}
