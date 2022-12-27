using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UsersDals : IUsersDal
    {
        private List<User> users = new List<User>() {
            new User() { Id = 1, Name = "Anna", Login = "abcd", Password = "1234"},
        };

        public User GetById(int id)
        {
            return users.FirstOrDefault(item => item.Id == id);
        }
        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(item => item.Login == login);
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
