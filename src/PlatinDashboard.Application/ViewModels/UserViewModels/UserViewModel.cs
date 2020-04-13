using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlatinDashboard.Application.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        [Key]
        public string UserId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve conter no mínimo 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O campo nome deve conter no máximo 128 caracteres")]
        [DisplayName("Nome do Usuário")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "O campo sobrenome deve conter no mínimo 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O campo sobrenome deve conter no máximo 128 caracteres")]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [DisplayName("Login")]
        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        [DisplayName("E-mail")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }

        [DisplayName("Status")]
        public bool Active { get; set; }

        [DisplayName("Tipo de Usuário")]
        public string UserType { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? AdministrativeCode { get; set; }
        public bool ImportedFromAdministrative { get; set; }
        public int[] UserStoresIds { get; set; }

        public UserViewModel()
        {
            UserStoresIds = new int[] { };
        }
    }
}
