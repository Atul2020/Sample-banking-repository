using System.Data.SqlClient;
using Bankingproject;
namespace bankingdblib
{
    public class dbclass
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static void InsertData(SBAccount sb)
        {

            int accountnumber = sb.AccountNumber;
            string customername = sb.CustomerName;
            string customeraddress = sb.CustomerAddress;
            decimal currentbalance = sb.CurrentBalance;

            con = getcon();
            cmd = new SqlCommand("insert into accountdetails values(@accountnumber,@customername,@customeraddress,@currentbalance)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@accountnumber", accountnumber);
            cmd.Parameters.AddWithValue("@customername", customername);
            cmd.Parameters.AddWithValue("@customeraddress", customeraddress);
            cmd.Parameters.AddWithValue("@currentbalance", currentbalance);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i + " number of Row(s) affected");
            con.Close();
        }

        public static SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bankingproj;Integrated Security=true");
            con.Open();
            return con;
        }

        public static SqlDataReader SelectAllDetails()
        {
            //getcon();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bankingproj;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from accountdetails");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            //while (dr.Read())//number of rows
            //{
            //    for (int i = 0; i < dr.FieldCount; i++)//fieldcount==number of columns
            //    {
            //        Console.Write(dr[i] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public static SqlDataReader GetDetailsWithAccno(int accno)
        {
            
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bankingproj;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from accountdetails where @accountnumber=accountnumber");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@accountnumber", accno);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public static SqlDataReader GetTransDetailsWithAccno(int accno)
        {
            con = getcon();
            SqlCommand cmd = new SqlCommand("select * from transactiondetails where @accountnumber=accountnumber");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@accountnumber", accno);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public static void DepositingAmount(int accno, decimal amt,int tid)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=bankingproj;Integrated Security=true");
            con.Open();
            DateTime dt = DateTime.Now;
            string transtype = "Deposit";

                SqlCommand cmd = new SqlCommand("update accountdetails set currentbalance+=@currentbalance where @accountnumber=accountnumber");
                cmd.Connection = con;
                SqlCommand cmd1 = new SqlCommand("insert into transactiondetails values(@transactionid,@transactiondate,@accountnumber,@amount,@transactiontype)");
                cmd1.Connection = con;
                cmd.Parameters.AddWithValue("@accountnumber", accno);
                cmd.Parameters.AddWithValue("@currentbalance", amt);

                cmd1.Parameters.AddWithValue("@transactionid", tid);
                cmd1.Parameters.AddWithValue("@transactiondate", dt);
                cmd1.Parameters.AddWithValue("@accountnumber", accno);
                cmd1.Parameters.AddWithValue("@amount", amt);
                cmd1.Parameters.AddWithValue("@transactiontype", transtype);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine(i + " number of Row(s) affected");
                int j = cmd1.ExecuteNonQuery();
                Console.WriteLine(j + " number of Row(s) affected");

            //SqlCommand cmd = new SqlCommand("update accountdetails set currentbalance+=@currentbalance where @accountnumber=accountnumber");
            //cmd.Connection = con;
            //SqlCommand cmd1 = new SqlCommand("insert into transactiondetails values(@transactionid,@transactiondate,@accountnumber,@amount,@transactiontype)");
            //cmd1.Connection = con;
            //cmd.Parameters.AddWithValue("@accountnumber", accno);
            //cmd.Parameters.AddWithValue("@currentbalance",amt);

            //cmd1.Parameters.AddWithValue("@transactionid", tid);
            //cmd1.Parameters.AddWithValue("@transactiondate", dt);
            //cmd1.Parameters.AddWithValue("@accountnumber", accno);
            //cmd1.Parameters.AddWithValue("@amount", amt);
            //cmd1.Parameters.AddWithValue("@transactiontype", transtype);
            //int i = cmd.ExecuteNonQuery();
            //Console.WriteLine(i + " number of Row(s) affected");
            //int j = cmd1.ExecuteNonQuery();
            //Console.WriteLine(j + " number of Row(s) affected");
        }
        public static void WithdrawingAmount(int accno,decimal amt,int tid)
        {
            con = getcon();

            SqlCommand cmd2 = new SqlCommand("select currentbalance from accountdetails where @accountnumber=accountnumber");
            cmd2.Connection = con;
            cmd2.Parameters.AddWithValue("@accountnumber", accno);
            SqlDataReader dr = cmd2.ExecuteReader();
            dr.Read();
            decimal currentbal = dr.GetDecimal(0);
            dr.Close();
            if (amt <= currentbal)
            {
                DateTime dt = DateTime.Now;
                string transtype = "Withdraw";
                SqlCommand cmd = new SqlCommand("update accountdetails set currentbalance-=@currentbalance where @accountnumber=accountnumber");
                cmd.Connection = con;
                SqlCommand cmd1 = new SqlCommand("insert into transactiondetails values(@transactionid,@transactiondate,@accountnumber,@amount,@transactiontype)");
                cmd1.Connection = con;
                cmd.Parameters.AddWithValue("@accountnumber", accno);
                cmd.Parameters.AddWithValue("@currentbalance", amt);

                cmd1.Parameters.AddWithValue("@transactionid", tid);
                cmd1.Parameters.AddWithValue("@transactiondate", dt);
                cmd1.Parameters.AddWithValue("@accountnumber", accno);
                cmd1.Parameters.AddWithValue("@amount", amt);
                cmd1.Parameters.AddWithValue("@transactiontype", transtype);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine(i + " number of Row(s) affected");
                int j = cmd1.ExecuteNonQuery();
                Console.WriteLine(j + " number of Row(s) affected");

            }
            else
            {
                throw new InsufficientBalanceException("You have insufficient balance in your account!!!");
            }
            //DateTime dt = DateTime.Now;
            //string transtype = "Withdraw";
            //SqlCommand cmd = new SqlCommand("update accountdetails set currentbalance-=@currentbalance where @accountnumber=accountnumber");
            //cmd.Connection = con;
            //SqlCommand cmd1 = new SqlCommand("insert into transactiondetails values(@transactionid,@transactiondate,@accountnumber,@amount,@transactiontype)");
            //cmd1.Connection = con;
            //cmd.Parameters.AddWithValue("@accountnumber", accno);
            //cmd.Parameters.AddWithValue("@currentbalance", amt);

            //cmd1.Parameters.AddWithValue("@transactionid", tid);
            //cmd1.Parameters.AddWithValue("@transactiondate", dt);
            //cmd1.Parameters.AddWithValue("@accountnumber", accno);
            //cmd1.Parameters.AddWithValue("@amount", amt);
            //cmd1.Parameters.AddWithValue("@transactiontype",transtype);
            //int i = cmd.ExecuteNonQuery();
            //Console.WriteLine(i + " number of Row(s) affected");
            //int j = cmd1.ExecuteNonQuery();
            //Console.WriteLine(j + " number of Row(s) affected");
        }


    }
    
}