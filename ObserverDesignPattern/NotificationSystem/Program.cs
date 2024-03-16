
using NotificationSystem.Observable;
using NotificationSystem.Observer;

namespace NotificationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Observer Design Pattern Demo ");
            IStocksObservable iphonestocksObservable = new IPhoneObservableimplementation();
            INotificationAlertObserver observer1=new EmailAlertObserverImpl("sujeet@gmail.com", iphonestocksObservable);
            INotificationAlertObserver observer2 = new EmailAlertObserverImpl("sujeet@gmail.com", iphonestocksObservable);
            INotificationAlertObserver observer3 = new MobileAlertObserverImpl("sujeet@gmail.com", iphonestocksObservable);
            iphonestocksObservable.add(observer1);
            iphonestocksObservable.add(observer2);
            iphonestocksObservable.add(observer3);
            iphonestocksObservable.SetStockCount(1);
            
            Console.ReadLine();

        }
    }
}