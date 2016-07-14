namespace CustomerReport.Domain.Model
{
    public class Customer
    {
        public string Email { get; private set; }

        public Customer(string email)
        {
            Email = email;
        }
    }
}