using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class ConformidadeConfiguration : EntityTypeConfiguration<Conformidade>
    {
        public ConformidadeConfiguration()
        {
            //Table
            ToTable("Conformidade");

            //Key
            HasKey(c => c.id);

            //Properties
            Property(c => c.Anexo).IsOptional();
            Property(c => c.Avaliado).IsOptional();
            Property(c => c.DataAvaliacao).IsOptional();
            Property(c => c.DataValidacao).IsOptional();
            Property(c => c.Evidencias).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.IDLegis).IsOptional();
            Property(c => c.IDParametros).IsOptional();
            Property(c => c.Obrigacao).IsOptional();
            Property(c => c.ProxAvaliacao).IsOptional();
            Property(c => c.Resultado).IsOptional();
            Property(c => c.Validado).IsOptional();
        }
    }
}