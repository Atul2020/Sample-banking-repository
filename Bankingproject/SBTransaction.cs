using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankingproject
{
    public class SBTransaction
    {
        public long TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }

        public SBTransaction() { }
        public SBTransaction(long transactionID, DateTime transactionDate, int accountNumber, decimal amount, string transactionType)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
        }
    }
}
