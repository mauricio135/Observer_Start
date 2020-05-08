using System;

namespace Observer
{
    public class TemperatureReporter: IObserver
    {
        private bool first;
        private Temperature last;
        private IObservable provider;

        public void StartReporting(TemperatureSensor provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature t)
        {
            Console.WriteLine($"The temperature is {t.Degrees}°C at {t.Date:g}");
            if (first)
            {
                last = t;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {t.Degrees - last.Degrees}° in " +
                    $"{t.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }

    }
}