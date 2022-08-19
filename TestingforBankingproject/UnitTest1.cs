using Bankingproject;
using System.Data.SqlClient;
namespace TestingforBankingproject
{
    public class Tests
    {
        public static BankRepository bp;
        [SetUp]
        public void Setup()
        {
            bp=new BankRepository();
        }

        [Test]
        public void DepositingTest()
        {
            SqlDataReader dr = bp.GetAccountDetails(1000000001);
            dr.Read();
            decimal currentbal = (decimal)dr[3];

            bp.DepositAmount(1000000001, 500);

            SqlDataReader dr1 = bp.GetAccountDetails(1000000001);
            dr1.Read();
            decimal predicted_amt = currentbal + 500;
            decimal amount_after = (decimal)dr1[3];

            Assert.AreEqual(predicted_amt, amount_after);

        }
        [Test]
        public void WithdrawingTest()
        {
            SqlDataReader dr = bp.GetAccountDetails(1000000001);
            dr.Read();
            decimal currentbal = (decimal)dr[3];

            bp.WithdrawAmount(1000000001, 500);

            SqlDataReader dr1 = bp.GetAccountDetails(1000000001);
            dr1.Read();
            decimal predicted_amt = currentbal - 500;
            decimal amount_after = (decimal)dr1[3];

            Assert.AreEqual(predicted_amt, amount_after);

        }
    }
}