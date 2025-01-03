using App.Domain.Core.Bank.User.Entities;

namespace Bank_page.Models
{
    public static class InmmemoryDB
    {
        public static string? Username { get; set; }
        public static string? CurrentCardNumber { get; set; }
        public static string? DestanceCardNumber { get; set; }
        public static double TransactionMoney { get; set; } = 0;
        public static bool FindDesCard { get; set; }=false;
        public static void ResetAllData()
        {
            Username = null;
            CurrentCardNumber = null;
            DestanceCardNumber = null;
            TransactionMoney = 0;
            FindDesCard = false;
        }
        public static void ResetForCards()
        {
            CurrentCardNumber = null;
            DestanceCardNumber = null;
            TransactionMoney = 0;
            FindDesCard = false;
        }
        public static void ResetForTransaction()
        {
            DestanceCardNumber = null;
            TransactionMoney = 0;
            FindDesCard = false;
        }
    }
}
