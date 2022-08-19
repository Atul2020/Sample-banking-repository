using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankingdblib;
using System.Data.SqlClient;
namespace Bankingproject
{
    public class AccountNumberNotFoundException : ApplicationException
    {
        public AccountNumberNotFoundException(string message) : base(message) { }
    }
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    public class BankRepository : IBankRepository
    {
        List<SBAccount> sba = new List<SBAccount>();
        List<SBTransaction> sbt = new List<SBTransaction>();
        dbclass db = new dbclass();
        static Random rnd = new Random();
        public static int tid = rnd.Next();
        public void DepositAmount(int accno, decimal amt)
        {
            GetAccountDetails(accno);
             dbclass.DepositingAmount(accno, amt,tid);
            //int flag = 0;
            //foreach(SBAccount item in sba)
            //{
            //    if (item.AccountNumber == accno)
            //    {
            //        flag = 1;
            //        item.CurrentBalance += amt;
            //        sbt.Add(new SBTransaction(tid += 1, DateTime.Now, accno, amt,"deposit"));
            //        Console.WriteLine("The new balance is: " + item.CurrentBalance);
            //    }
                
            //}
            //if (flag == 0)
            //{
            //    throw new AccountNumberNotFoundException("Account Number is not Valid");
            //}
            
        }


        public /*SBAccount*/ SqlDataReader GetAccountDetails(int accno)
        {
            //foreach (SBAccount item in sba)
            //{
            //    if (item.AccountNumber == accno)
            //        return item;
            //}

            if (dbclass.GetDetailsWithAccno(accno).HasRows)
            {
                return dbclass.GetDetailsWithAccno(accno);
            }
            else
            {
                throw new AccountNumberNotFoundException("Account Number is not Valid");
            }
                //return new SBAccount();
            
        }

        public /*List<SBAccount>*/ SqlDataReader GetAllAccounts()
        {
            //return sba;
            return dbclass.SelectAllDetails();

        }

        public /*List<SBTransaction>*/ SqlDataReader GetTransactions(int accno)
        {
            if (dbclass.GetTransDetailsWithAccno(accno).HasRows)
            {
                return dbclass.GetTransDetailsWithAccno(accno);
            }
            else
            {
                throw new AccountNumberNotFoundException("No transactions have been found for this account!!");
            }
            //int flag = 0;
            //foreach (SBAccount item in sba)
            //{
            //    if (item.AccountNumber == accno)
            //        flag = 1;
            //}
            //if (flag == 0)
            //{
            //    throw new AccountNumberNotFoundException("Account Number not found!!!");
            //}
            //List<SBTransaction> transofuser=new List<SBTransaction>();
            //foreach(SBTransaction transaction in sbt)
            //{
            //    if(transaction.AccountNumber == accno)
            //    {
            //        transofuser.Add(transaction);

            //    }
            //}
            //if (transofuser.Count==0)
            //{
            //    throw new AccountNumberNotFoundException("No transactions have been done for this Account Number!!");
            //}
            //return transofuser;

        }

        public void NewAccount(SBAccount acc)
        {
            //Console.WriteLine("Enter the details of your account:");
            //Console.WriteLine("Enter the Account Number:");
            //int accno=int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the your name:");
            //string cust_name=Console.ReadLine();
            //Console.WriteLine("Enter your Address");
            //string cust_address = Console.ReadLine();
            //Console.WriteLine("Enter the current balance:");
            //decimal current_balance=decimal.Parse(Console.ReadLine());


            dbclass.InsertData(acc);

            //sba.Add(acc);

        }

        public void WithdrawAmount(int accno, decimal amt)
        {
            GetAccountDetails(accno);
            dbclass.WithdrawingAmount(accno, amt,tid);
            //int flag = 0;
            //foreach(SBAccount withdrawal in sba)
            //{
            //    if (withdrawal.AccountNumber == accno) {
            //        flag = 1;
            //        if (withdrawal.CurrentBalance >= amt)
            //        {
            //            withdrawal.CurrentBalance -= amt;
            //            sbt.Add(new SBTransaction(tid += 1, DateTime.Now, accno, amt , "withdrawal"));
            //            Console.WriteLine("The new balance is: " + withdrawal.CurrentBalance);

            //        }
            //        else
            //        {
            //            throw new InsufficientBalanceException("You have insufficient balance in your account!!!");
            //        }
            //    }
            //}
            //if (flag == 0)
            //{
            //    throw new AccountNumberNotFoundException("Account Number is not Valid");
            //}
           
        }
    }
}
