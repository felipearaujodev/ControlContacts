using ControlContacts.Models;
using ControlContacts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlContacts.Controllers
{
    public class UserController : Controller
    {
        public IUserRepository _respositoryUser { get; }

        public UserController(IUserRepository respositoryUser)
        {
            _respositoryUser = respositoryUser;
        }
        public IActionResult Index()
        {
            var users = _respositoryUser.GetAll().OrderByDescending(c => c.Id);

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _respositoryUser.Add(user);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o usuário, tente novamente!";
                return RedirectToAction("Index");
            }


        }
    }
}
