using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlatinDashboard.Presentation.MVC.Helpers
{
    public static class ListGeneratorHelper
    {
        public static SelectList GenerateMonths()
        {
            //Método para gerar uma lista com os meses
            return new SelectList(
                new[] {
                    new { Value = "01", Label = "Janeiro" },
                    new { Value = "02", Label = "Fevereiro" },
                    new { Value = "03", Label = "Março" },
                    new { Value = "04", Label = "Abril" },
                    new { Value = "05", Label = "Maio" },
                    new { Value = "06", Label = "Junho" },
                    new { Value = "07", Label = "Julho" },
                    new { Value = "08", Label = "Agosto" },
                    new { Value = "09", Label = "Setembro" },
                    new { Value = "10", Label = "Outubro" },
                    new { Value = "11", Label = "Novembro" },
                    new { Value = "12", Label = "Dezembro" }
                }, "Value", "Label", DateTime.Now.ToString("MM"));
        }

        public static SelectList GenerateYears()
        {
            //Método para gerar uma lista com os anos
            List<SelectListItem> listItens = new List<SelectListItem>();
            for (int i = DateTime.Now.Year; i >= 2016; i--)
            {
                listItens.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }
            return new SelectList(listItens, "Value", "Text", DateTime.Now.Year.ToString());
        }

        public static SelectList GenerateProviders()
        {
            //Método para gerar uma lista com os providers de banco de dados
            return new SelectList(
                new[] {
                    new { Value = "Outros", Label = "Outros" },
                    new { Value = "Auditor", Label = "Auditor" },
                    new { Value = "Supervisor", Label = "Supervisor" },
                    new { Value = "Gerente", Label = "Gerente" },
                     new { Value = "Diretor", Label = "Diretor" },
                    new { Value = "Proprietário", Label = "Proprietário" }
                }, "Value", "Label");
        }
    }
}