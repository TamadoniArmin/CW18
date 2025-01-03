using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.User.Services
{
    public interface IUserService
    {
        bool Login(string username, string password);
    }
}
