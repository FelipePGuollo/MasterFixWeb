using FirebirdSql.EntityFrameworkCore.Firebird.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFixWeb.Entities
{
    public class MasterFixContext : DbContext
    {
        readonly string _connectionString;

        public MasterFixContext()
        {
            _connectionString = "database=localhost:C:\\Users\\MasterCim\\Desktop\\MasterFIX\\SAMPLEDATABASE.FDB;user=sysdba;password=masterkey";
        }

        public DbSet<Demo> Demos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var demoConf = modelBuilder.Entity<Demo>();
            demoConf.Property(x => x.Id).HasColumnName("ID");
            demoConf.Property(x => x.FooBar).HasColumnName("FOOBAR");
            demoConf.ToTable("DEMO");
        }
    }

    public class Demo
    {
        public int Id { get; set; }
        public string FooBar { get; set; }
    }
}   
