using Microsoft.EntityFrameworkCore;
using SchoolEntity.Models;
using System.Reflection;

namespace SchoolEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        //In Real Application, I would use appsettings.json to import connection string with Configuration.GetConnectionString("conn_string");
        public const string ConnectionString = @"Server=ANDRIA\MSSQLSERVER01;Database=SweeftDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Pupil> Pupils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
