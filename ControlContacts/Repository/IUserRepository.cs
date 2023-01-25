using ControlContacts.Models;

namespace ControlContacts.Repository
{
    public interface IUserRepository
    {
        UserModel GetLogin(string login);
        UserModel Add(UserModel contact);
        IEnumerable<UserModel> GetAll();
        UserModel Get(int id);
        UserModel Update(UserModel contact);
        bool Delete(int Id);
    }
}
