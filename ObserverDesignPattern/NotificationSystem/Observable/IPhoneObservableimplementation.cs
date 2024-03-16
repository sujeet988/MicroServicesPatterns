using NotificationSystem.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Observable
{
    public class IPhoneObservableimplementation : IStocksObservable
    {
        private List<INotificationAlertObserver> _observerlist = new List<INotificationAlertObserver>();
        private int stockCount = 0;
        public void add(INotificationAlertObserver notificationAlertObserver)
        {
            _observerlist.Add(notificationAlertObserver);
        }
        public void remove(INotificationAlertObserver notificationAlertObserver)
        {
            _observerlist.Remove(notificationAlertObserver);
        }
        public void NotifySubscriber()
        {
            foreach(INotificationAlertObserver notificationAlertObserver in _observerlist)
            {
                notificationAlertObserver.update();
            }
        }
        public void SetStockCount(int newStocksAdded)
        {
            if (stockCount == 0)
            {
                NotifySubscriber();
            }
            stockCount = stockCount+newStocksAdded;
        }

        public int GetStockCount()
        {
            return stockCount;
        }

        
     

       
    }
}
