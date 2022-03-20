using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.DataAccess.Context;
using WebDev.Models;

namespace WebDev.DataAccess
{
    public class UserDA
    {
        private readonly AppDbContext _appDbContext;

        public UserDA(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _appDbContext.Users.FindAsync(id);
        }

        public async void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<string> UpdateUser(User user)
        {
            var userExist = _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userExist != null)
            {
                _appDbContext.Entry(user).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                return "User Updated";
            }
            return "User Not Found";
        }

        public async void DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
