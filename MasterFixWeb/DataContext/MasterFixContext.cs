using FirebirdSql.EntityFrameworkCore.Firebird.Extensions;
using MasterFixWeb.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFixWeb.DataContext
{
    public class MasterFixContext : DbContext
    {
        readonly string _connectionString;

        public MasterFixContext()
        {
            _connectionString = "database=localhost:C:\\Users\\MasterCim\\Desktop\\MasterFIX\\SAMPLEDATABASE.FDB;user=sysdba;password=masterkey";
        }

        public DbSet<Demo> Demos { get; set; }
        public DbSet<Entidade> Entidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var demoConf = modelBuilder.Entity<Demo>();
            {                
                demoConf.Property(x => x.Id).HasColumnName("ID");
                demoConf.Property(x => x.FooBar).HasColumnName("FOOBAR");
                demoConf.ToTable("DEMO");
            }

            var entidadeConf = modelBuilder.Entity<Entidade>();
            {
                entidadeConf.Property(x => x.Id).HasColumnName("ID_ENTIDADE");
                entidadeConf.Property(x => x.Nome).HasColumnName("NOME");
                entidadeConf.Property(x => x.Rua).HasColumnName("RUA");
                entidadeConf.Property(x => x.Numero).HasColumnName("NUMERO");
                entidadeConf.Property(x => x.Complemento).HasColumnName("COMPLEMENTO");
                entidadeConf.Property(x => x.Bairro).HasColumnName("BAIRRO");
                entidadeConf.Property(x => x.Cidade).HasColumnName("CIDADE");
                entidadeConf.Property(x => x.Uf).HasColumnName("UF");
                entidadeConf.Property(x => x.Cep).HasColumnName("CEP");
                entidadeConf.Property(x => x.Fone1).HasColumnName("FONE1");
                entidadeConf.Property(x => x.Fone2).HasColumnName("FONE2");
                entidadeConf.Property(x => x.Email).HasColumnName("EMAIL");
                entidadeConf.Property(x => x.Homepage).HasColumnName("HOMEPAGE");
                entidadeConf.Property(x => x.Contato).HasColumnName("CONTATO");
                entidadeConf.Property(x => x.ContatoFone).HasColumnName("CONTATO_FONE");
                entidadeConf.Property(x => x.CnpjCpf).HasColumnName("CNPJ_CPF");
                entidadeConf.Property(x => x.InscRg).HasColumnName("INSC_RG");
                entidadeConf.Property(x => x.Obs).HasColumnName("OBSCONV");
                entidadeConf.ToTable("ENTIDADE");
            }
        }
    }

    public class Demo
    {
        public int Id { get; set; }
        public string FooBar { get; set; }
    }
}   
