using ControlContacts.Data;
using ControlContacts.Models;

namespace ControlContacts.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public ContactRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            _dataBaseContext.Contacts.Add(contact);
            _dataBaseContext.SaveChanges();

             return contact;
        }

        public bool Delete(int Id)
        {
            var contactDB = Get(Id);
            if (contactDB == null) throw new Exception("Erro ao deletar");

            _dataBaseContext.Contacts.Remove(contactDB);
            _dataBaseContext.SaveChanges();

            return true;
        }

        public ContactModel Get(int Id)
        {
            return _dataBaseContext.Contacts.FirstOrDefault(c=>c.Id == Id);
        }

        public IEnumerable<ContactModel> GetAll()
        {
            return _dataBaseContext.Contacts.ToList();
        }

        public ContactModel Update(ContactModel contact)
        {
            var contactDB = Get(contact.Id);
            if (contactDB == null) throw new Exception("Erro ao atualizar");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Cell = contact.Cell;

            _dataBaseContext.Contacts.Update(contactDB);
            _dataBaseContext.SaveChanges();

            return contactDB;

        }
    }
}
