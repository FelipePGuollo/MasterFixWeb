using FirebirdSql.EntityFrameworkCore.Firebird.Extensions;
using MasterFixWeb.Models;
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
            _connectionString = "database=localhost:C:\\Users\\MasterCim\\Desktop\\MasterFIX\\SAMPLEDATABASE.FDB;user=sysdba;password=masterkey;Charset=NONE";
        }
        public DbSet<Entidade> Entidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseFirebird(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entidadeConf = modelBuilder.Entity<Entidade>();
            {
                entidadeConf.Property(x => x.Id).HasColumnName("ID_ENTIDADE");
                entidadeConf.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(60);
                entidadeConf.Property(x => x.Rua).HasColumnName("RUA").HasMaxLength(50);
                entidadeConf.Property(x => x.Numero).HasColumnName("NUMERO");
                entidadeConf.Property(x => x.Complemento).HasColumnName("COMPLEMENTO").HasMaxLength(30);
                entidadeConf.Property(x => x.Bairro).HasColumnName("BAIRRO").HasMaxLength(30);
                entidadeConf.Property(x => x.Cidade).HasColumnName("CIDADE").HasMaxLength(35);
                entidadeConf.Property(x => x.Uf).HasColumnName("UF").HasMaxLength(2);
                entidadeConf.Property(x => x.Cep).HasColumnName("CEP").HasMaxLength(10);
                entidadeConf.Property(x => x.Fone1).HasColumnName("FONE1").HasMaxLength(14);
                entidadeConf.Property(x => x.Fone2).HasColumnName("FONE2").HasMaxLength(14);
                entidadeConf.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(50);
                entidadeConf.Property(x => x.Homepage).HasColumnName("HOMEPAGE").HasMaxLength(100);
                entidadeConf.Property(x => x.Contato).HasColumnName("CONTATO").HasMaxLength(30);
                entidadeConf.Property(x => x.ContatoFone).HasColumnName("CONTATO_FONE").HasMaxLength(14);
                entidadeConf.Property(x => x.CnpjCpf).HasColumnName("CNPJ_CPF").HasMaxLength(18);
                entidadeConf.Property(x => x.InscRg).HasColumnName("INSC_RG").HasMaxLength(20);
                entidadeConf.Property(x => x.Obs).HasColumnName("OBS").HasMaxLength(80);
                entidadeConf.ToTable("ENTIDADE");
            }
        }
    }
}   
