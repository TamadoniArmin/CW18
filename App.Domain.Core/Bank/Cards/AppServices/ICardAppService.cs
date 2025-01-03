using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards.Entities;

namespace App.Domain.Core.Bank.Cards.AppServices
{
    public interface ICardAppService
    {
        bool CheckPassword(string Cardnumber, string password);
        void ChangePassword(string Cardnumber, string newpassword);
        double GetCardBalance(string Cardnumber);
        bool ReduceAmount(double money, string cartnumber, string DistansCardnumber);
        void IncreasAmount(double money, string cartnumber);
        void ChangeStatus(string Cardnumber);
        bool GetCardByNumber(string Cardnumber);
        bool ActionsPermition(string Cardnumber);
        void SetLastTransactionDate(string Cardnumber);
        void ResetLastTransactionDate(string Cardnumber);
        bool IncreasDailyTransaction(double money, string cartnumber);
        void CheckTimesOfInsertingPasswordIncorrectly(string Cardnumber);
        void CountInstertPasswordWrong(string Cardnumber);
        List<Card> GetListOfUserCards(string username);
        Card GetDistancCard(string Cardnumber);
    }
}
