using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.Cards;
using App.Domain.Core.Bank.Cards.Data.Repositories;
using App.Domain.Core.Bank.Cards.Entities;
using App.Domain.Core.Bank.Cards.Services;
using App.Infra.Data.Repos.Ef;
using App.Infra.Data.Repos.Ef.Bank.Cards;
namespace App.Domain.Services.Bank.Cards
{
    public class CardService : ICardService
    {
        CardRepository CardRepository=new CardRepository();
        public bool ActionsPermition(string Cardnumber)
        {
            return CardRepository.ActionsPermition(Cardnumber);
        }

        public bool CardIsActive(string Cardnumber)
        {
            return CardRepository.CardIsActive(Cardnumber);
        }

        public bool ChangePassword(string Cardnumber, string newpassword)
        {
            return CardRepository.ChangePassword(Cardnumber, newpassword);
        }

        public void ChangeStatus(string Cardnumber)
        {
            CardRepository.ChangeStatus(Cardnumber);
        }

        public bool CheckPassword(string Cardnumber, string password)
        {
            return CardRepository.CheckPassword(Cardnumber, password);
        }

        public int CheckTimesOfInsertingPasswordIncorrectly(string Cardnumber)
        {
            return CardRepository.CheckTimesOfInsertingPasswordIncorrectly(Cardnumber);
        }

        public void CountInstertPasswordWrong(string Cardnumber)
        {
            CardRepository.CountInstertPasswordWrong(Cardnumber);
        }

        public double GetCardBalance(string Cardnumber)
        {
            return CardRepository.GetCardBalance(Cardnumber);
        }

        public Card? GetCardByNumber(string Cardnumber)
        {
            return CardRepository.GetCardByNumber(Cardnumber);
        }

        public List<Card> GetListOfUserCards(string username)
        {
            return CardRepository.GetListOfUserCards(username);
        }

        public void IncreasAmount(double money, string cartnumber)
        {
            CardRepository.IncreasAmount(money, cartnumber);
        }

        public bool IncreasDailyTransaction(double money, string cartnumber)
        {
            return CardRepository.IncreasDailyTransaction(money, cartnumber);
        }

        public bool ReduceAmount(double money, string cartnumber)
        {
            return CardRepository.ReduceAmount(money, cartnumber);
        }

        public void ResetLastTransactionDate(string Cardnumber)
        {
            CardRepository.ResetLastTransactionDate(Cardnumber);
        }

        public void SetLastTransactionDate(string Cardnumber)
        {
            CardRepository.SetLastTransactionDate(Cardnumber);
        }
    }

}
