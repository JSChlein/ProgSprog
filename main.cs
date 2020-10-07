using System;

namespace Opg4Delegate
{
    class Program
    {
        static void Main(string[] args)
        {

            FastCar fc = new FastCar(85, 23);

            fc.FuelChanged += c_FuelChanged;
            fc.SpeedChanged += c_SpeedChanged;

            fc.Speed = 100;
            fc.FuelLitersInTank = 12;

            fc.FuelChanged -= c_FuelChanged;

            fc.Speed = 120;
            fc.FuelLitersInTank = 10;



        }

        static void c_SpeedChanged(object sender, int oldValue, int newValue)
        {
            if(oldValue != null)
            {
                Console.WriteLine("Speed changed.");
                Console.WriteLine("Old value: " +oldValue);
                Console.WriteLine("New Value: " + newValue);
            }
        }

        static void c_FuelChanged(object sender, int oldValue, int newValue)
        {
            if (oldValue != null)
            {
                Console.WriteLine("Fuel changed.");
                Console.WriteLine("Old value: " + oldValue);
                Console.WriteLine("New Value: " + newValue);
            }
        }
    }
}
