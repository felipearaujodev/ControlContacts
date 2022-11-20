using ControlContacts.Models;

namespace ControlContacts.Repository
{
    public interface IUserRepository
    {
        UserModel Add(UserModel contact);
        IEnumerable<UserModel> GetAll();
        UserModel Get(int id);
        UserModel Update(UserModel contact);
        bool Delete(int Id);
    }
}
