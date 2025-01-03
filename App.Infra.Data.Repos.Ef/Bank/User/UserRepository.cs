using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.User;
using App.Domain.Core.Bank.User.Data.Repositories;
using Connection;

namespace App.Infra.Data.Repos.Ef.Bank.User
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _context = new AppDbContext();
        public bool Login(string username, string password)
        {
            return _context.Users.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
