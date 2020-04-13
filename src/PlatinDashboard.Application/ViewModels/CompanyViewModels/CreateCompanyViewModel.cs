using PlatinDashboard.Application.Administrativo.ViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlatinDashboard.Application.ViewModels.CompanyViewModels
{
    public class CreateCompanyViewModel
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O nome da Empresa é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(255, ErrorMessage = "O nome deve conter no máximo 255 caracteres")]
        [DisplayName("Cliente")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public string CompanyType { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo Nome Fantasia deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome Fantasia deve conter no máximo 100 caracteres")]
        [DisplayName("Nome Fantasia")]
        public string DatabaseServer { get; set; }

        [Required(ErrorMessage = "O campo Responsável é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo Responsável deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Responsável deve conter no máximo 100 caracteres")]
        [DisplayName("Responsável")]
        public string Database { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo Telefone deve conter no mínimo 3 caracteres")]
        [MaxLength(8, ErrorMessage = "O campo Telefone deve conter no máximo 8 caracteres")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Valor inválido para o campo Telefone")]
        [DisplayName("Telefone")]
        public string DatabasePort { get; set; }

        [Required(ErrorMessage = "O campo tipo  é obrigatório")]
        [DisplayName("Tipo de Adm")]
        public string DatabaseProvider { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo CNPJ deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo CNPJ deve conter no máximo 100 caracteres")]
        [DisplayName("CNPJ")]
        public string DatabaseUser { get; set; }

        [Required(ErrorMessage = "O campo I.E. é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo I.E. deve conter no mínimo 6 caracteres")]
        [MaxLength(40, ErrorMessage = "O campo I.E. deve conter no máximo 40 caracteres")]
        [DisplayName("I.E.")]
        public string DatabasePassword { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve conter no mínimo 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O campo nome deve conter no máximo 128 caracteres")]
        [DisplayName("Nome do Usuário")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = "O campo sobrenome deve conter no mínimo 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O campo sobrenome deve conter no máximo 128 caracteres")]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo login é obrigatório")]
        [MinLength(5, ErrorMessage = "O campo login deve conter no mínimo 5 caracteres")]
        [MaxLength(256, ErrorMessage = "O campo login deve conter no máximo 256 caracteres")]
        [DisplayName("Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [MinLength(8, ErrorMessage = "O campo e-mail deve conter no mínimo 8 caracteres")]
        [MaxLength(256, ErrorMessage = "O campo e-mail deve conter no máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "O campo e-mail deve possuir um formato válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo senha deve conter no mínimo 6 caracteres")]
        [MaxLength(255, ErrorMessage = "O campo e-mail deve conter no máximo 255 caracteres")]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo confirmação de senha é obrigatório")]        
        [DisplayName("Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha informada não confere")]
        public string ConfirmPassword { get; set; }

        public int? CustomerCode { get; set; }
        public int? AdministrativeCode { get; set; }

        public bool ImportedFromAdministrative { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }

        public void GetUsuarioInformation(UsuarioViewModel usuarioViewModel)
        {
            FirstName = usuarioViewModel.Login;
            UserName = usuarioViewModel.Login;
            Password = usuarioViewModel.Senha;
            AdministrativeCode = usuarioViewModel.Id;
            Email = usuarioViewModel.Email;
            ImportedFromAdministrative = true;
        }

        public void GetRedeInformation(RedeViewModel redeViewModel)
        {
            Name = redeViewModel.NomeFantasia;
            CustomerCode = redeViewModel.CodigoCliente;
            ImportedFromAdministrative = true;
        }

        public void GenerateDefaultConnetionValues()
        {
            DatabaseServer = "Não Informado";
            Database = "Não Informado";
            DatabasePort = "0000";
            DatabaseUser = "Não Informado";
            DatabasePassword = "Não Informado";
            DatabaseProvider = "Outros";
        }
    }
}
