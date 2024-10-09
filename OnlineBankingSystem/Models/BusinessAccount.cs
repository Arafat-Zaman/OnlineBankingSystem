namespace OnlineBankingSystem.Models
{
    public class BusinessAccount : Account
    {
        public BusinessAccount(string accountHolder, string accountNumber)
            : base(accountHolder, accountNumber) { }
    }
}
