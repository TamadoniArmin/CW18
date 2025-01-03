using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.TransAction.Services
{
    public interface ITransactionService
    {
        void AddTransaction(App.Domain.Core.Bank.TransAction.Entities.TransAction transAction);
        List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfSourceAction(string Cardnumber);
        List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfDestanceAction(string Cardnumber);
    }
}
