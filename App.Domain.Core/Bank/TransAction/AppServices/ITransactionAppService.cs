using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.TransAction.AppServices
{
    public interface ITransactionAppService
    {
        bool AddTransaction(string SourceCardNumber, string DestinationCardNumber, double AmountOfMoney);
        List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfSourceAction(string Cardnumber);
        List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfDestanceAction(string Cardnumber);
    }
}
