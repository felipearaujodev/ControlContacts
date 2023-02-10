using ControlContacts.Models;
using Newtonsoft.Json;

namespace ControlContacts.Helpers
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSession(UserModel user)
        {
            _httpContext.HttpContext.Session.SetString("sessionUser", JsonConvert.SerializeObject(user));
        }

        public UserModel GetUserSession()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("sessionUser");
            if (string.IsNullOrEmpty(sessionUser)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessionUser");
        }
    }
}
