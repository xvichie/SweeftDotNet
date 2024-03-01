using Microsoft.EntityFrameworkCore;
using SchoolEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace SchoolEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANDRIA\MSSQLSERVER01;Database=SweeftDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
