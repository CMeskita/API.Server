using API.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Server.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Video> Video { get; set; }

        public DbSet<Servidor> Servidor { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            //set the primary key
            builder.Entity<Servidor>().HasKey(c => c.Id);
            builder.Entity<Video>().HasKey(c => c.Id);


            base.OnModelCreating(builder);
        }
    }
}
