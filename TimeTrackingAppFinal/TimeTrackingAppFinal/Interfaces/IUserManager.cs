using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserManager
    {
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User GetUserByUserName(string userName);
        public List<User> GetAllUsers();
    }
}
