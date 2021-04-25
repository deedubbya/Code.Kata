using Code.Kata.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Code.Kata.DataAccess
{
    public class DriverContext: DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Uri dbPath = new Uri($@"{System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/drivers.db");
            optionsBuilder.UseSqlite($@"Data Source={dbPath}");
        }      
    }
}
