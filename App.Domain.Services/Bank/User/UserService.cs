using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.User.Services;
using App.Infra.Data.Repos.Ef.Bank.User;

namespace App.Domain.Services.Bank.User
{
    public class UserService : IUserService
    {
        UserRepository repository = new UserRepository();

        public bool Login(string username, string password)
        {
            return repository.Login(username, password);
        }
    }
}
