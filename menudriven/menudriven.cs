using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankingproject;
using System.Data.SqlClient;
namespace menudriven
{
    public class menudriven
    { 
        static void Main()
        {
            BankRepository br = new BankRepository();
            while (true)
            {
                Console.WriteLine("**************Welcome to the Banking app. Please select your option!!!*************");
                Console.WriteLine("1. Create a New Account");
                Console.WriteLine("2. Get Account Details");
                Console.WriteLine("3. Deposit Amount");
                Console.WriteLine("4. Withdraw Amount");
                Console.WriteLine("5. Get All Accounts");
                Console.WriteLine("6. Get Transactions");
                Console.WriteLine("Enter your Option");
                
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Random rn = new Random();
                            int accno = rn.Next();
                            Console.WriteLine("Enter the details of your account:");
                            Console.WriteLine("Enter the your name:");
                            string cust_name = Console.ReadLine();
                            Console.WriteLine("Enter your Address");
                            string cust_address = Console.ReadLine();
                            Console.WriteLine("Enter your initial deposit:");
                            decimal current_balance = decimal.Parse(Console.ReadLine());
                            SBAccount sb = new SBAccount(accno, cust_name, cust_address, current_balance);
                            br.NewAccount(sb);
                            Console.WriteLine("Your Account Number is: " + accno);
                           
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Enter the account number: ");
                                int ano = int.Parse(Console.ReadLine());
                                SqlDataReader sqr = br.GetAccountDetails(ano);
                                Console.WriteLine("---------Account Details---------");
                                while (sqr.Read())
                                {
                                    Console.WriteLine(sqr.GetName(0) + " : " + sqr[0] + "\n" + sqr.GetName(1) + " : " + sqr[1] + "\n" + sqr.GetName(2) + " : " + sqr[2]
                                    + "\n" + sqr.GetName(3) + " : " + sqr[3]);
                                    
                                }
                               
                                //SBAccount nl = br.GetAccountDetails(ano);
                                //Console.WriteLine(nl.AccountNumber + " " + nl.CustomerName + " " + nl.CustomerAddress + "" + nl.CurrentBalance);
                                
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        }
                    case 3:
                        {
                            try
                            {
                                Console.WriteLine("Enter the account number: ");
                                int ano = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the amount to be deposited: ");
                                decimal amt = decimal.Parse(Console.ReadLine());
                                
                                br.DepositAmount(ano, amt);
                                Console.WriteLine("The amount has been deposited");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }

                    case 4:
                        {
                            try
                            {
                                Console.WriteLine("Enter the account number: ");
                                int ano = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the amount to be withdrawn: ");
                                decimal amt = decimal.Parse(Console.ReadLine());
                                br.WithdrawAmount(ano, amt);
                                Console.WriteLine("The amount has been withdrawn");
                            }
                            catch (AccountNumberNotFoundException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 5:
                        {
                            //List<SBAccount> accdetails = br.GetAllAccounts();
                            //foreach (SBAccount item in accdetails)
                            //{
                            //    Console.WriteLine(" Account Number: "+item.AccountNumber +"\n"+" Customer Name: "+item.CustomerName + "\n" + " Customer Address: " +item.CustomerAddress + "\n" + " Current Balance: " + item.CurrentBalance);
                            //}
                            SqlDataReader sqr = br.GetAllAccounts();
                            Console.WriteLine("---------All Account Details---------");
                            while (sqr.Read())
                            {
                                Console.WriteLine(sqr.GetName(0) + " : " + sqr[0] + "\n" + sqr.GetName(1) + " : " + sqr[1] + "\n" + sqr.GetName(2) + " : " + sqr[2]
                                    + "\n" + sqr.GetName(3) + " : " + sqr[3]);
                                Console.WriteLine("---------------------------------");
                            }
                            break;
                        }
                    case 6:
                        {
                            try
                            {
                                Console.WriteLine("Enter the account number: ");
                                int ano = int.Parse(Console.ReadLine());
                                SqlDataReader sqr = br.GetTransactions(ano);
                                Console.WriteLine("---------Transaction Details---------");
                                while (sqr.Read())
                                {
                                    Console.WriteLine(sqr.GetName(0) + " : " + sqr[0] + "\n" + sqr.GetName(1) + " : " + sqr[1] + "\n" + sqr.GetName(2) + " : " + sqr[2]
                                    + "\n" + sqr.GetName(3) + " : " + sqr[3]+ "\n" + sqr.GetName(4) + " : " + sqr[4]);

                                }
                                //List<SBTransaction> transdetails = br.GetTransactions(ano);
                                //foreach (SBTransaction item in transdetails)
                                //{
                                //    Console.WriteLine("Tid: " + item.TransactionID + "\n" + "Transaction Date: " + item.TransactionDate + "\n" + "Account Number: " + item.AccountNumber + "\n" + "Amount: " + item.Amount + "\n" + "Transaction Type: " + item.TransactionType);
                                //}
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }


                }

                //Environment.Exit(0);
            }

        }
    }
}

