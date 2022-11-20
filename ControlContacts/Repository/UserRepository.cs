using ControlContacts.Data;
using ControlContacts.Models;

namespace ControlContacts.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public UserModel Add(UserModel user)
        {
            user.RegistrationDate = DateTime.Now;
            _dataBaseContext.User.Add(user);
            _dataBaseContext.SaveChanges();

             return user;
        }

        public bool Delete(int Id)
        {
            var userDB = Get(Id);
            if (userDB == null) throw new Exception("Erro ao deletar");

            _dataBaseContext.User.Remove(userDB);
            _dataBaseContext.SaveChanges();

            return true;
        }

        public UserModel Get(int Id)
        {
            return _dataBaseContext.User.FirstOrDefault(c=>c.Id == Id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _dataBaseContext.User.ToList();
        }

        public UserModel Update(UserModel user)
        {
            var userDB = Get(user.Id);
            if (userDB == null) throw new Exception("Erro ao atualizar");

            userDB.Name = user.Name;
            userDB.Login = user.Login;
            userDB.Password = user.Password;
            userDB.Email = user.Email;
            userDB.UpdateDate = user.UpdateDate;
            userDB.Profile = user.Profile;

            _dataBaseContext.User.Update(userDB);
            _dataBaseContext.SaveChanges();

            return userDB;

        }
    }
}
