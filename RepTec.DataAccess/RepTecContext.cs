using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess
{
    public class RepTecContext : DbContext
    {
        public DbSet<Repairer> Repairers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlCe(@"Data Source=|DataDirectory|\RepTec.sdf");
        }
    }
}