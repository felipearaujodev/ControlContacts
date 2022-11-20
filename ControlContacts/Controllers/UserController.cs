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

        public IActionResult ConfirmDeletion(int Id)
        {
            var user = _respositoryUser.Get(Id);
            return View(user);
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

        public IActionResult ToEdit(int Id)
        {
            var user = _respositoryUser.Get(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(UserModelNoPassword userNoPass)
        {
            try
            {
                UserModel? user = null;
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    { 
                        Id = userNoPass.Id,
                        Name = userNoPass.Name,
                        Email = userNoPass.Email,
                        Login = userNoPass.Login,
                        Profile = userNoPass.Profile
                    };

                    _respositoryUser.Update(user);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("ToEdit", user);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao atualizar o usuário!";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int Id)
        {
            try
            {
                _respositoryUser.Delete(Id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao apagar o usuário!";
                return RedirectToAction("Index");
            }

        }
    }
}
