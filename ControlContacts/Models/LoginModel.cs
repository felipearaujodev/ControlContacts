using System.ComponentModel.DataAnnotations;

namespace ControlContacts.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
