using API.Server.Entity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Emit;

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

      //  private readonly Mock<DbSet<Servidor>> _mockServerSet;
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            //set the primary key
            builder.Entity<Servidor>().HasKey(c => c.Id);
            builder.Entity<Video>().HasKey(c => c.Id);
            builder.Entity<Servidor>().HasMany(s => s.Videos).WithOne(v => v.Servidor);

            base.OnModelCreating(builder);
        }
    }
}
