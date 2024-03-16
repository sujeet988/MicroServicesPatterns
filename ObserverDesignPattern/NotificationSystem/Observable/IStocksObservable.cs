using NotificationSystem.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Observable
{
    public interface IStocksObservable
    {

        public void add(INotificationAlertObserver notificationAlertObserver);
        public void remove(INotificationAlertObserver notificationAlertObserver);
        public void NotifySubscriber();
        public void SetStockCount(int newStocksAdded);
        public int GetStockCount();
    }
    

}
