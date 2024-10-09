namespace OnlineBankingSystem.Models
{
    public class Customer
    {
        public string Name { get; }
        public string Phone { get; }

        public Customer(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
