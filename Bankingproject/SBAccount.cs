using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankingproject
{
    public class SBAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal CurrentBalance { get; set; }

        public SBAccount()
        {

        }

        public SBAccount(int accountNumber, string customerName, string customerAddress, decimal currentBalance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CurrentBalance = currentBalance;
        }

            //public overrride string ToString()
        //{
        //    return " ";
        //}
    }
}
