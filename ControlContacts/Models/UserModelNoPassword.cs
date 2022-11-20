using ControlContacts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControlContacts.Models
{
    public class UserModelNoPassword
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil")]
        public ProfileEnum? Profile { get; set; }
    }
}
