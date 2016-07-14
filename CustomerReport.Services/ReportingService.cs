using CustomerReport.Domain;

namespace CustomerReport.Services
{
    public class ReportingService
    {
        public ICustomerData CustomerData { get; private set; }
        public IReportBuilder ReportBuilder { get; private set; }
        public IEmailer Emailer { get; private set; }

        public ReportingService(ICustomerData customerData, IReportBuilder reportBuilder, IEmailer emailer)
        {
            CustomerData = customerData;
            ReportBuilder = reportBuilder;
            Emailer = emailer;
        }

        public void RunCustomerReports()
        {
            var customers = CustomerData.GetCustomersForReport();

            foreach (var customer in customers)
            {
                var report = ReportBuilder.CreateCustomerReport(customer);
                Emailer.Send(report.Email, report.Body);
            }
        }
    }
}
