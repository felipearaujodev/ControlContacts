
using ControlContacts.Models;
using ControlContacts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlContacts.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly Helpers.ISession _iSession;
        public LoginController(IUserRepository userRepository, Helpers.ISession iSession)
        {
            _userRepository = userRepository;
            _iSession = iSession;
        }

        public IActionResult Index()
        {
            //se o usuário estiver logado, redirecionar para home
            if(_iSession.GetUserSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logoff()
        {
            _iSession.RemoveUserSession();

            return RedirectToAction("Index", "Home");
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
                            _iSession.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["MensagemErro"] = "Usuário e/ou senha inválido(s)";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Não foi possível realizar o login, verifique se o login e senha estão corretos!";
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}
