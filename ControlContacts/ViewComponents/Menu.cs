using ControlContacts.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControlContacts.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("sessionUser");

            if (string.IsNullOrEmpty(userSession)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession); 
            return View(user);
        }
    }
}
