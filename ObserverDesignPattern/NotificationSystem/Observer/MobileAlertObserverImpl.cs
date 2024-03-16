using NotificationSystem.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Observer
{
    public class MobileAlertObserverImpl : INotificationAlertObserver
    {
        private readonly  string userName;
        private readonly  IStocksObservable Observable;
        public MobileAlertObserverImpl(string emailId, IStocksObservable observable)
        {
            this.userName = emailId;
            Observable = observable;
        }

        public void update()
        {
            SendMessageOnMobile(userName, "Product is in a stock, hurry up");
        }
         private void SendMessageOnMobile(string userName, string msg)
        {
            Console.WriteLine("Message : {0} sent to : {1} ", msg,userName);
            //  sed the actual email to the end user
        }
    }
}
