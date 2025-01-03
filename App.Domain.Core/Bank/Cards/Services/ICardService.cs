using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards.Entities;

namespace App.Domain.Core.Bank.Cards.Services
{
    public interface ICardService
    {
        bool ActionsPermition(string Cardnumber);
        bool CheckPassword(string Cardnumber, string password);
        bool ChangePassword(string Cardnumber, string newpassword);
        bool CardIsActive(string Cardnumber);
        double GetCardBalance(string Cardnumber);
        bool ReduceAmount(double money, string cartnumber);
        void CountInstertPasswordWrong(string Cardnumber);
        void IncreasAmount(double money, string cartnumber);
        Card? GetCardByNumber(string Cardnumber);
        void ChangeStatus(string Cardnumber);
        void SetLastTransactionDate(string Cardnumber);
        void ResetLastTransactionDate(string Cardnumber);
        bool IncreasDailyTransaction(double money, string cartnumber);
        int CheckTimesOfInsertingPasswordIncorrectly(string Cardnumber);
        List<Card> GetListOfUserCards(string username);
    }
}
