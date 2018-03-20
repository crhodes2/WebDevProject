using System.Data.Entity;
using WebDevProject.Data.Entities;

namespace WebDevProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<Pokemon> Pokemons {get; set;}
        public virtual DbSet<Vitamins> Vitamins { get; set; }

        public System.Data.Entity.DbSet<WebDevProject.Models.View.VitaminViewModel> VitaminViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
    }

}