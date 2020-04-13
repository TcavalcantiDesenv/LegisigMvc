using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class EmpresasConfiguration : EntityTypeConfiguration<Empresas>
    {
        public EmpresasConfiguration()
        {
            //Table
            ToTable("Clientes");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Aplicar).IsOptional();
            Property(c => c.Aplicar).IsOptional();
            Property(c => c.Bairro).IsOptional();
            Property(c => c.CEP).IsOptional();
            Property(c => c.RazaoSocial).IsOptional();
            //Property(c => c.IDCliente).IsOptional();
            //Property(c => c.IDLegis).IsOptional();
            //Property(c => c.IDParametros).IsOptional();
            //Property(c => c.Obrigacao).IsOptional();
            //Property(c => c.ProxAvaliacao).IsOptional();
            //Property(c => c.Resultado).IsOptional();
            //Property(c => c.Validado).IsOptional();
        }
    }
}