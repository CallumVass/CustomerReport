using CustomerReport.Domain;
using CustomerReport.Services;

namespace CustomerReport
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static ReportingService Compose()
        {
            return new ReportingService(new CustomerData(), new ReportBuilder(), new Emailer());
        }
    }
}
