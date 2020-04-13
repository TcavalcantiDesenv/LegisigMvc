using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class LeisClientesConfiguration : EntityTypeConfiguration<LeisClientes>
    {
        public LeisClientesConfiguration()
        {
            //Table
            ToTable("LeisClientes");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Aplicavel).IsOptional();
            Property(c => c.Ambito).IsOptional();
            Property(c => c.Ano).IsOptional();
            Property(c => c.Arqpdf).IsOptional();
            Property(c => c.Ativo).IsOptional();
            Property(c => c.Data).IsOptional();
            Property(c => c.Dias).IsOptional();
            Property(c => c.Ementa).IsOptional();
            Property(c => c.Estado).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.Lei).IsOptional();
            Property(c => c.Link).IsOptional();
            Property(c => c.Localidade).IsOptional();
            Property(c => c.Municipio).IsOptional();

            Property(c => c.Numero ).IsOptional();
            Property(c => c.Orgao).IsOptional();
            Property(c => c.Pais).IsOptional();
            Property(c => c.Param).IsOptional();
            Property(c => c.RazaoSocial).IsOptional();
            Property(c => c.Sistema).IsOptional();
            Property(c => c.Tema).IsOptional();
            Property(c => c.Tipo).IsOptional();
        }
    }
}