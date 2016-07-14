using System.Collections.Generic;
using CustomerReport.Domain.Model;

namespace CustomerReport.Domain
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetCustomersForReport();
    }

    public class CustomerData : ICustomerData
    {
        public IEnumerable<Customer> GetCustomersForReport()
        {
            yield return new Customer("abc123@test.com");
            yield return new Customer("123abc@test.com");
            yield return new Customer("abc456@test.com");
        }
    }
}