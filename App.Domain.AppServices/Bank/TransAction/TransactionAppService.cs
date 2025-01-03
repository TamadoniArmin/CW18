using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.AppServices.Bank.Cards;
using App.Domain.Core.Bank.TransAction.AppServices;
using App.Domain.Core.Bank.TransAction.Data.Repositories;
using App.Domain.Services.Bank;
using App.Domain.Services.Bank.Cards;
using App.Domain.Services.Bank.TransAction;
using App.Infra.Data.Repos.Ef.Bank.Cards;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.AppServices.Bank.TransAction
{
    public class TransactionAppService : ITransactionAppService
    {
        TransactionService transactionService=new TransactionService();
        CardRepository cardRepository = new CardRepository();//<---
        CardAppService cardAppService = new CardAppService();//<---
        public bool AddTransaction(string SourceCardNumber, string DestinationCardNumber, double AmountOfMoney)
        {
            try
            {
                var FindCard = cardRepository.GetCardByNumber(DestinationCardNumber);
                if (FindCard is null)
                {
                    Console.WriteLine("Unsuccessful transaction due to not finding the destination card");
                    App.Domain.Core.Bank.TransAction.Entities.TransAction transaction = new App.Domain.Core.Bank.TransAction.Entities.TransAction()
                    {
                        SourceCardNumber = SourceCardNumber,
                        DestinationCardNumber = DestinationCardNumber,
                        Amount = 0,
                        TransactionDate = DateTime.Now,
                        TransactionDetails = "Unsuccessful transaction due to not finding the destination card",
                        isSuccessful = false
                    };
                    transactionService.AddTransaction(transaction);
                    return false;
                }
                var CheckLimit = cardRepository.IncreasDailyTransaction(AmountOfMoney, SourceCardNumber);
                if (!CheckLimit)
                {
                    Console.WriteLine("Transaction failed due to daily transaction limit");
                    App.Domain.Core.Bank.TransAction.Entities.TransAction transaction = new App.Domain.Core.Bank.TransAction.Entities.TransAction()
                    {
                        SourceCardNumber = SourceCardNumber,
                        DestinationCardNumber = DestinationCardNumber,
                        Amount = AmountOfMoney,
                        TransactionDate = DateTime.Now,
                        TransactionDetails = "Transaction failed due to daily transaction limit",
                        isSuccessful = false
                    };
                    transactionService.AddTransaction(transaction);
                    return false;
                }
                var ReducingMoney = cardAppService.ReduceAmount(AmountOfMoney, SourceCardNumber, DestinationCardNumber);
                if (!ReducingMoney)
                {
                    Console.WriteLine("Transaction failed due to insufficient balance");
                    App.Domain.Core.Bank.TransAction.Entities.TransAction transaction = new App.Domain.Core.Bank.TransAction.Entities.TransAction()
                    {
                        SourceCardNumber = SourceCardNumber,
                        DestinationCardNumber = DestinationCardNumber,
                        Amount = AmountOfMoney,
                        TransactionDate = DateTime.Now,
                        TransactionDetails = "Transaction failed due to insufficient balance",
                        isSuccessful = false
                    };
                    transactionService.AddTransaction(transaction);
                    return false;
                }
                else if (FindCard is not null && ReducingMoney is true && CheckLimit is true)
                {
                    cardRepository.IncreasAmount(AmountOfMoney, DestinationCardNumber);
                    App.Domain.Core.Bank.TransAction.Entities.TransAction transaction = new App.Domain.Core.Bank.TransAction.Entities.TransAction()
                    {
                        SourceCardNumber = SourceCardNumber,
                        DestinationCardNumber = DestinationCardNumber,
                        Amount = AmountOfMoney,
                        TransactionDate = DateTime.Now,
                        isSuccessful = true
                    };
                    transactionService.AddTransaction(transaction);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                cardAppService.IncreasAmount(AmountOfMoney, SourceCardNumber);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfDestanceAction(string Cardnumber)
        {
            return transactionService.GetListOfDestanceAction(Cardnumber);
        }

        public List<App.Domain.Core.Bank.TransAction.Entities.TransAction> GetListOfSourceAction(string Cardnumber)
        {
            return transactionService.GetListOfSourceAction(Cardnumber);
        }
    }
}
