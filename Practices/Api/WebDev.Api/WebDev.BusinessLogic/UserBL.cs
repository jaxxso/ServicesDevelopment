using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebDev.DataAccess;
using WebDev.Models;

namespace WebDev.BusinessLogic
{
    public class UserBL
    {
        private readonly UserDA _userDA;

        public UserBL(UserDA userDA)
        {
            _userDA = userDA;
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _userDA.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userDA.GetUserById(id);
        }

        public async void AddUser(User user)
        {
            _userDA.AddUser(user);
        }

        public async Task<string> UpdateUser(User user)
        {
            return await _userDA.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userDA.DeleteUser(id);
        }
    }
}
