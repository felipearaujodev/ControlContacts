using ControlContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlContacts.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}
