using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Car c = new Car(60);
            c.Fast += CustomEvent.ShowMessage; 
            c.Slow += CustomEvent.ShowMessage; 
            ConsoleKeyInfo k;
            do
            {
            k = Console.ReadKey();
            if (k.Key == ConsoleKey.RightArrow) 
            c.DriveFroward(); 
            else if (k.Key == ConsoleKey.LeftArrow) 
            c.DriveBack(); 
            } while (k.Key != ConsoleKey.Escape);*/
            Race r = new Race();
            r.StartRace();
        }
    }
}