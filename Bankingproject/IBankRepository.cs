using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Bankingproject
{
    internal interface IBankRepository
    {
        void NewAccount(SBAccount acc);
        /*SBAccount*/ SqlDataReader GetAccountDetails(int accno);
        /*List<SBAccount> */ SqlDataReader GetAllAccounts();
        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        /*List<SBTransaction>*/ SqlDataReader GetTransactions(int accno);
    }
}
