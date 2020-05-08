using System.Collections.Generic;
namespace Observer
{
    public interface IObservable
    {
        List <IObserver> observers { get; }

        void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }
         void Unsubscribe (IObserver observer)
         {
             observers.Remove(observer);
         }
    }
}