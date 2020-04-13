using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace PlatinDashboard.Application.ViewModels.CompanyViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O nome da Cliente é obrigatório")]
        [MinLength(3, ErrorMessage = "O Cliente deve conter no mínimo 3 caracteres")]
        [MaxLength(255, ErrorMessage = "O Cliente deve conter no máximo 255 caracteres")]
        [DisplayName("Cliente")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public string CompanyType { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome Fantasia deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Nome Fantasia deve conter no máximo 100 caracteres")]
        [DisplayName("Nome Fantasia")]
        public string DatabaseServer { get; set; }

        [Required(ErrorMessage = "O responsavel é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo responsavel de dados deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo responsavel de dados deve conter no máximo 100 caracteres")]
        [DisplayName("Responsável")]
        public string Database { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo Telefone deve conter no mínimo 3 caracteres")]
        [MaxLength(8, ErrorMessage = "O campo Telefone deve conter no máximo 8 caracteres")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Valor inválido para o campo Telefone (somente Numeros)")]
        [DisplayName("Telefone")]
        public string DatabasePort { get; set; }

        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        [DisplayName("Cargo")]
        public string DatabaseProvider { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
        [MinLength(14, ErrorMessage = "O campo CNPJ deve conter no mínimo 14 caracteres")]
        [MaxLength(18, ErrorMessage = "O campo CNPJ deve conter no máximo 18 caracteres")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:##.###.###/#####-##}")]
        [DisplayName("CNPJ")]
        public string DatabaseUser { get; set; }

        [Required(ErrorMessage = "O campo IE obrigatório")]
        [MinLength(12, ErrorMessage = "O campo IE deve conter no mínimo 12 caracteres")]
        [MaxLength(15, ErrorMessage = "O campo IE deve conter no máximo 15 caracteres")]
        [DisplayName("I.E.")]
        public string DatabasePassword { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }

        public int CustomerCode { get; set; }

        [ScaffoldColumn(false)]
        public bool ImportedFromAdministrative { get; set; }

        public DbConnection GetDbConnection()
        {
            var connectionString = $"server={DatabaseServer};port={DatabasePort};user id={DatabaseUser};password={DatabasePassword};database={Database}";
            var databaseProvider = DatabaseProvider == "MySQL" ? "MySql.Data.MySqlClient" : "Npgsql";
            var conn = DbProviderFactories.GetFactory(databaseProvider).CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }

        public string GetConnectionString()
        {
            var connectionString = $"server={DatabaseServer};port={DatabasePort};user id={DatabaseUser};password={DatabasePassword};database={Database}";
            return connectionString;
        }

        public bool CheckConnectionConfiguration()
        {
            //Método para verificar se a conexão da empresa foi configurada
            return !DatabaseServer.Equals("Não Informado") || 
                   !DatabasePort.Equals("0000") || 
                   !DatabasePassword.Equals("Não Informado") ||
                   !DatabaseUser.Equals("Não Informado") ||
                   !DatabasePassword.Equals("Não Informado");
        }
    }    
}
