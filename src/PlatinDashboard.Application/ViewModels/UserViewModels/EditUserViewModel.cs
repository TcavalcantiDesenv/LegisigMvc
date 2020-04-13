using AutoMapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlatinDashboard.Application.ViewModels.UserViewModels
{
    public class EditUserViewModel
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

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }

        public int[] UserStoresIds { get; set; }

        public EditUserViewModel()
        {
            UserStoresIds = new int[] { };
        }

        public EditUserViewModel(UserViewModel userViewModel)
        {
            UserStoresIds = userViewModel.UserStoresIds;
            Mapper.Map(userViewModel, this);
        }
    }
}
