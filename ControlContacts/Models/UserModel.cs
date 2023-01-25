using ControlContacts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControlContacts.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Digite o e-email do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil")]
        public ProfileEnum? Profile { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool PasswordIsValid(string password) 
        { 
            return Password == password;
        }
    }
}
