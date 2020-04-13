using PlatinDashboard.Presentation.MVC.Models;
using System.Data.Entity.ModelConfiguration;

namespace PlatinDashboard.Presentation.MVC.ModelConfiguration
{
    public class LegisGeralConfiguration : EntityTypeConfiguration<LegisGeral>
    {
        public LegisGeralConfiguration()
        {
            //Table
            ToTable("LegisGeral");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Ambito).IsOptional();
            Property(c => c.Ano).IsOptional();
            Property(c => c.Arqpdf).IsOptional();
            Property(c => c.Data).IsOptional();
            //Property(c => c.Dias).IsOptional();
            Property(c => c.Ementa).IsOptional();
            Property(c => c.Estado).IsOptional();
            //Property(c => c.Estados).IsOptional();
            Property(c => c.lei).IsOptional();
            Property(c => c.link).IsOptional();
            Property(c => c.Localidade).IsOptional();
            Property(c => c.Municipio).IsOptional();
            Property(c => c.Numero).IsOptional();
            Property(c => c.Orgao).IsOptional();
            Property(c => c.Pais).IsOptional();
            Property(c => c.param).IsOptional();
    //        Property(c => c.Aplicavel).IsOptional();

            Property(c => c.Sistema).IsOptional();
            Property(c => c.Tema).IsOptional();
            Property(c => c.Tipo).IsOptional();
        }
    }
}