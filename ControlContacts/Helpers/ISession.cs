using ControlContacts.Models;

namespace ControlContacts.Helpers
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel GetUserSession();
    }
}
