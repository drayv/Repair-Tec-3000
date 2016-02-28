using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using RepTec.Core.Entity;

namespace RepTec.DataAccess
{
    public class RepTecContext : DbContext
    {
        public DbSet<Repairer> Repairers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "RepTec.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}