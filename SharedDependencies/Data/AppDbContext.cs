using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedDependencies.Models;

namespace SharedDependencies.Data {
    public class AppDbContext : DbContext { // inherited/personalized DbContext class which mimics the data structure of the SQL table
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DbData> DbDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<DbData>().ToTable("test_table");
        }
    }
}
