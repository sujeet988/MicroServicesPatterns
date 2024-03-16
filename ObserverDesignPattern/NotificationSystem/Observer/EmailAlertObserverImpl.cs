using NotificationSystem.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Observer
{
    public class EmailAlertObserverImpl : INotificationAlertObserver
    {
        string emailId;
        IStocksObservable Observable;

        public EmailAlertObserverImpl( string emailId, IStocksObservable Observable)
        {
            this.emailId = emailId;
            this.Observable = Observable;
        }
        public void update()
        {
            SendMail(emailId, "Product is in stock hurry up");
        }
        private void SendMail(string emailid, string message)
        {
            Console.WriteLine("Mail Sent to Email id:  {0} and Message is : {1}" , emailid, message);
            // send actual email to end users
        }
        
    }

}
