using ControlContacts.Models;
using ControlContacts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlContacts.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetLogin(loginModel.Login);
                    if(user != null)
                    {
                        if (user.PasswordIsValid(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["MensagemErro"] = "Usuário e/ou senha inválido(s)";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não fi possível realizar o login, verifique se o login e senha estão corretos!";
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}
