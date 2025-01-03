using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.TransAction.Data.Repositories;
using App.Infra.Data.Repos.Ef.Bank.TransAction;
using App.Domain.Core.Bank.TransAction.Data;
using App.Domain.Core.Bank.TransAction.Services;

namespace App.Domain.Services.Bank.TransAction
{
    public class TransactionService : ITransactionService
    {
        TransactionRepository transactionRepository = new TransactionRepository();
        public void AddTransaction(App.Domain.Core.Bank.TransAction.Entities.TransAction transAction)
        {
             transactionRepository.AddTransaction(transAction);
        }

        public List<Core.Bank.TransAction.Entities.TransAction> GetListOfDestanceAction(string Cardnumber)
        {
            return transactionRepository.GetListOfDestanceAction(Cardnumber);
        }

        public List<Core.Bank.TransAction.Entities.TransAction> GetListOfSourceAction(string Cardnumber)
        {
            return transactionRepository.GetListOfSourceAction(Cardnumber);
        }
    }
}
    