using System;
using Microsoft.Data.Entity;
using RepTec.Core.Entity;

namespace RepTec.DataAccess
{
    public class RepTecContext : DbContext
    {
        public DbSet<Repairer> Repairers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Environment.GetEnvironmentVariable("SQLCONNSTR_RepTec");
            if (connString == null)
            {
                // Seems, we are on localhost.
                optionsBuilder.UseSqlCe(@"Data Source=|DataDirectory|\RepTec.sdf");
            }
            else {
                // Wow! We are on Azure!
                optionsBuilder.UseSqlServer(connString);
            }
        }
    }
}