using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class LegisClientesConfiguration : EntityTypeConfiguration<LegisClientes>
    {
        public LegisClientesConfiguration()
        {
            //Table
            ToTable("LegisClientes");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Aplicavel).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.IDLegisGeral).IsOptional();
            Property(c => c.IDProduto).IsOptional();
            Property(c => c.IDSubProduto).IsOptional();
            Property(c => c.Lei).IsOptional();
        }
    }
}