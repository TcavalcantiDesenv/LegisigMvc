﻿using PlatinDashboard.Domain.Farmacia.Entities;
using System.Data.Entity.ModelConfiguration;

namespace PlatinDashboard.Infra.Data.Farmacia.EntityConfig.MySql
{
    public class ClsVenAllConfiguration : EntityTypeConfiguration<ClsVenAll>
    {
        public ClsVenAllConfiguration()
        {
            ToTable("cls_ven_all");

            HasKey(c => new { c.Dat, c.Cls });

            Property(c => c.Dat)
                .HasColumnName("data")
                .HasColumnType("DATE")
                .IsRequired();

            Property(c => c.My)
                .HasColumnName("mes_ano")
                .HasColumnType("VARCHAR")
                .HasMaxLength(6);

            Property(c => c.Cls)
                .HasColumnName("classificacao")
                .HasColumnType("INT")
                .IsRequired();

            Property(c => c.Vlb)
                .HasColumnName("valor_bruto")
                .HasColumnType("DECIMAL");

            Property(c => c.Vld)
                .HasColumnName("valor_desconto")
                .HasColumnType("DECIMAL");

            Property(c => c.Vlc)
                .HasColumnName("valor_custo")
                .HasColumnType("DECIMAL");

            Property(c => c.Vde)
                .HasColumnName("valor_devolucao")
                .HasColumnType("DECIMAL");

            Property(c => c.Vdc)
                .HasColumnName("valor_custo_devolucao")
                .HasColumnType("DECIMAL");

            Property(c => c.Reg)
                .HasColumnName("qtde_registro")
                .HasColumnType("INT");

            Property(c => c.Tme)
                .HasColumnName("ticket_medio")
                .HasColumnType("DECIMAL");

            Property(c => c.Nua)
                .HasColumnName("nua")
                .HasColumnType("INT");

            Property(c => c.Vme)
                .HasColumnName("valor_medio")
                .HasColumnType("DECIMAL");

        }
    }
}
