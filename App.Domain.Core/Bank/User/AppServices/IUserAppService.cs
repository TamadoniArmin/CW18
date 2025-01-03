using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.User.AppServices
{
    public interface IUserAppService
    {
        bool Login(string username, string password);
    }
}
