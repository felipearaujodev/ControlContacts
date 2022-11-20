using ControlContacts.Models;

namespace ControlContacts.Repository
{
    public interface IContactRepository
    {
        ContactModel Add(ContactModel contact);
        IEnumerable<ContactModel> GetAll();
        ContactModel Get(int id);
        ContactModel Update(ContactModel contact);
        bool Delete(int Id);
    }
}
