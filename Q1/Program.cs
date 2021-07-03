using System;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Food f = new Food() { Amount = 1000 };
            f.AmountChanged += notifyAmountChanged;
            f.Amount = 990;
            Console.WriteLine("Calory:" + f.ComputeCalory());
            Console.ReadLine();
        }
        public static void notifyAmountChanged(float oldValue, float newValue)
        {
            Console.WriteLine("Amount changed - old value:"+ oldValue + ", new value :"+newValue);
        }
    }
}
