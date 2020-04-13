using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlatinDashboard.Application.ViewModels.UserViewModels
{
    public class CreateUserViewModel
    {
        public string UserId { get; set; }
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve conter no mínimo 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O campo nome deve conter no máximo 128 caracteres")]
        [DisplayName("Nome do Usuário")]
        public string Name { get; set; }

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

        [DisplayName("Tipo de Usuário")]
        public string UserType { get; set; }

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

        public int[] UserStoresIds { get; set; }

        public CreateUserViewModel()
        {
            UserType = "Comum";
            UserStoresIds = new int[] { };
        }
    }
}
