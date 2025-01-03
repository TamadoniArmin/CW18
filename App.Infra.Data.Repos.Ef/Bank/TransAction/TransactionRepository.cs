using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infra.Data.Repos.Ef.Bank.TransAction;
using App.Domain.Core.Bank.TransAction;
using App.Domain.Core.Bank.TransAction.Data.Repositories;
using App.Infra.Data.Repos.Ef.Bank.Cards;
using Connection;
using App.Domain.Core.Bank.Cards.AppServices;
using App.Domain.Core.Bank.Cards.Services;

namespace App.Infra.Data.Repos.Ef.Bank.TransAction
{
    public class TransactionRepository : ITransactionRepository
    {
        AppDbContext _context = new AppDbContext();
        CardRepository cardRepository = new CardRepository();

        public void AddTransaction(App.Domain.Core.Bank.TransAction.Entities.TransAction transAction)
        {
            _context.Transactions.Add(transAction);
            _context.SaveChanges();
        }

        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfDestanceAction(string Cardnumber)
        {
            return _context.Transactions.Where(t => t.DestinationCard.CardNumber == Cardnumber).ToList();
        }

        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfSourceAction(string Cardnumber)
        {
            return _context.Transactions.Where(t => t.SourceCard.CardNumber == Cardnumber).ToList();
        }
    }
}
