using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.User.Data.Repositories
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
        //void GetListOfUserCards(string username);
    }
}
