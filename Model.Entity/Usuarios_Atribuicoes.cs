using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{

    public class Usuarios_Atribuicoes
    {
        public int ID { get; set; }
        public int Estados { get; set; }

        [Display(Name = "Código")]
        public Nullable<int> IDUsuario { get; set; }
        public Nullable<int> IDPagina { get; set; }
        public Nullable<int> Cod_Atribuicao { get; set; }
        public string Nivel { get; set; }
        public string Atribuicao { get; set; }
        public Nullable<System.DateTime> DataIni { get; set; }
        public Nullable<System.DateTime> DataFim { get; set; }
        public string HoraIni { get; set; }
        public string HoraFim { get; set; }
        public Nullable<int> Ativo { get; set; }

        public Usuarios_Atribuicoes(int id)
        {
            this.ID = id;
        }
        public Usuarios_Atribuicoes()
        {

        }
    }

}
