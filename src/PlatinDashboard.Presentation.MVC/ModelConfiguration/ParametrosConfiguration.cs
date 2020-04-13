using PlatinDashboard.Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class ParametrosConfiguration : EntityTypeConfiguration<Parametros>
    {
        public ParametrosConfiguration()
        {
            //Table
            ToTable("Parametros");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Aplicavel).IsOptional();
            Property(c => c.Capitulo).IsOptional();
            Property(c => c.Conhecimento).IsOptional();
            //Property(c => c.Estados).IsOptional();
            //Property(c => c.Dias).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.IDLegisGeral).IsOptional();
            //Property(c => c.Estados).IsOptional();
            Property(c => c.Item).IsOptional();
            Property(c => c.lei).IsOptional();
            Property(c => c.Numero).IsOptional();
            Property(c => c.Obrigacao).IsOptional();
            Property(c => c.param).IsOptional();
            Property(c => c.Parametro).IsOptional();
        }
    }
}