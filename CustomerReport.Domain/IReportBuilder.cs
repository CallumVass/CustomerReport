using CustomerReport.Domain.Model;

namespace CustomerReport.Domain
{
    public interface IReportBuilder
    {
        Report CreateCustomerReport(Customer customer);
    }

    public class ReportBuilder : IReportBuilder
    {
        public Report CreateCustomerReport(Customer customer)
        {
            return new Report(customer.Email, $"This is a report for {customer.Email}");
        }
    }
}