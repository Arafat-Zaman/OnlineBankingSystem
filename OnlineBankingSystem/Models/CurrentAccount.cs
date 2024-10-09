namespace OnlineBankingSystem.Models
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string accountHolder, string accountNumber)
            : base(accountHolder, accountNumber) { }
    }
}
