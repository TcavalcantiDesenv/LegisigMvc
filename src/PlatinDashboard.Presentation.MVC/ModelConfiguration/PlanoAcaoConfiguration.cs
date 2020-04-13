using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class PlanoAcaoConfiguration : EntityTypeConfiguration<PlanoAcao>
    {
        public PlanoAcaoConfiguration()
        {
            //Table
            ToTable("PlanoAcao");

            //Key
            HasKey(c => c.id);

            //Properties
            Property(c => c.Causa).IsOptional();
            Property(c => c.Correcao_Corretivas).IsOptional();
            Property(c => c.DataCausa).IsOptional();
            Property(c => c.DataEficacia).IsOptional();
            Property(c => c.Eficacia).IsOptional();
            Property(c => c.Evidencias).IsOptional();
            Property(c => c.IDAcao).IsOptional();
            Property(c => c.IDCliente).IsOptional();
            Property(c => c.IDLegis).IsOptional();
            Property(c => c.IDParametros).IsOptional();
            Property(c => c.Prazo).IsOptional();
            Property(c => c.ResultFinal).IsOptional();
        }
    }
}