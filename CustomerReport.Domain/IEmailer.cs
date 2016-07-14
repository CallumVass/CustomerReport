using System;

namespace CustomerReport.Domain
{
    public interface IEmailer
    {
        void Send(string toAddress, string body);
    }

    public class Emailer : IEmailer
    {
        public void Send(string toAddress, string body)
        {
            Console.Out.WriteLine("Send Email to: {0}, Body: {1}", toAddress, body);
        }
    }
}
