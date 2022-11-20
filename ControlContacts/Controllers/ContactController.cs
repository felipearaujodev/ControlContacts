using ControlContacts.Models;
using ControlContacts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlContacts.Controllers
{
    public class ContactController : Controller
    {
        public IContactRepository _respositoryContact { get; }

        public ContactController(IContactRepository respositoryContact)
        {
            _respositoryContact = respositoryContact;
        }

        public IActionResult Index()
        {
            var contacts = _respositoryContact.GetAll();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ToEdit(int Id)
        {
            var contact = _respositoryContact.Get(Id);
            return View(contact);
        }

        public IActionResult ConfirmDeletion(int Id)
        {
            var contact = _respositoryContact.Get(Id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _respositoryContact.Add(contact);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch(Exception)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o contato, tente novamente!";
                return RedirectToAction("Index");
            }

            
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _respositoryContact.Update(contact);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("ToEdit", contact);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao atualizar o contato!";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                _respositoryContact.Delete(Id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Erro ao apagar o contato!";
                return RedirectToAction("Index");
            }
            
        }
    }
}
