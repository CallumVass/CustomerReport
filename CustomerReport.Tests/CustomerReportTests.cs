using CustomerReport.Domain;
using CustomerReport.Domain.Model;
using CustomerReport.Services;
using Moq;
using NUnit.Framework;

namespace CustomerReport.Tests
{
    [TestFixture]
    public class CustomerReportTests
    {
        private Mock<ICustomerData> _customerDataMock;
        private Mock<IReportBuilder> _reportBuilderMock;
        private Mock<IEmailer> _emailerMock;

        [SetUp]
        public void Setup()
        {
            _customerDataMock = new Mock<ICustomerData>();
            _reportBuilderMock = new Mock<IReportBuilder>();
            _emailerMock = new Mock<IEmailer>();
        }

        [Test]
        public void RunCustomerReportsShouldSendEmails()
        {
            // arrange
            var expectedCustomer = new Customer("fred@freddo.com");
            const string expectedReportBody = "This is the expected report body";

            _customerDataMock.Setup(c => c.GetCustomersForReport()).Returns(new[] { expectedCustomer });

            _reportBuilderMock.Setup(r => r.CreateCustomerReport(expectedCustomer))
                .Returns(new Report(expectedCustomer.Email, expectedReportBody));

            var sut = new ReportingService(_customerDataMock.Object, _reportBuilderMock.Object, _emailerMock.Object);

            // act
            sut.RunCustomerReports();

            // assert
            _emailerMock.Verify(e => e.Send(expectedCustomer.Email, expectedReportBody));
        }
    }
}
