using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class ParametrosClienteConfiguration : EntityTypeConfiguration<ParametrosCliente>
    {
        public ParametrosClienteConfiguration()
        {
            //Table
            ToTable("ParametrosCliente");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Aplicavel).IsOptional();
            Property(c => c.Capitulo).IsOptional();
            Property(c => c.Conhecimento).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.IDLegisGeral).IsOptional();
            Property(c => c.Item).IsOptional();
            Property(c => c.Numero).IsOptional();
            Property(c => c.Obrigacao).IsOptional();
            Property(c => c.Parametro).IsOptional();
        }
    }
}