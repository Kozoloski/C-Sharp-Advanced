using Domain.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserManager
    {
        private readonly IFileManager fileManager;

        public UserManager()
        {
            fileManager = new FileManager();
        }
        public void AddUser(User user)
        {
            var users = fileManager.ReadFromFile();
            users.Add(user);
            fileManager.WriteToFile(users);
        }

        public List<User> GetAllUsers()
        {
            var users = fileManager.ReadFromFile();
            return users;
        }

        public User GetUserByUserName(string userName)
        {
            var users = fileManager.ReadFromFile();
            return users.FirstOrDefault(x => x.Username == userName);
        }

        public void UpdateUser(User user)
        {
            var users = fileManager.ReadFromFile();
            var userToUpdate = users.FirstOrDefault(x => x.Username == user.Username);
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Activities = user.Activities;
            fileManager.WriteToFile(users);
        }
    }
}
