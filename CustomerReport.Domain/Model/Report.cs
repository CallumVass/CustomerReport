namespace CustomerReport.Domain.Model
{
    public class Report
    {
        public string Email { get; private set; }
        public string Body { get; private set; }

        public Report(string email, string body)
        {
            Email = email;
            Body = body;
        }
    }
}