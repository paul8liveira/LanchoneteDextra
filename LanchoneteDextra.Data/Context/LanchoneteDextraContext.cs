using LanchoneteDextra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanchoneteDextra.Data.Context
{
    public class LanchoneteDextraContext : DbContext
    {
        //Constutor da classe enviando contexto para classe DBContext
        public LanchoneteDextraContext() : base("DefaultConnection") { }

        //DbSets
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }

        //Sobrescrevendo OnModelCreating para redefinir alguns padroes de criacao da base de dados atraves do Update-Database do Migrations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Nao utiliza padrao de pluralizacao
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Define que se houver campo na entidade com nome da tabela + Id, define como chave primaria (Ex: InputId)
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //padroniza todos os campos string para varchar(100)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //add configuracoes especificas de cada entidade
            //modelBuilder.Configurations.Add(new InputConfiguration());
            //modelBuilder.Configurations.Add(new ResultConfiguration());
        }
    }
}
