using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.User.AppServices;
using App.Infra.Data.Repos.Ef.Bank.User;

namespace App.Domain.AppServices.Bank.User
{
    public class UserAppService : IUserAppService
    {
        UserRepository repository=new UserRepository();
        public bool Login(string username, string password)
        {
            bool ResultOfLogin = repository.Login(username, password);
            if (!ResultOfLogin)
            {
                Console.WriteLine("There is no user with this informaton in database!! Please try againe.");
                return false;
            }
            return true;
        }
    }
}
