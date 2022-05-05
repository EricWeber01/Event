using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class CustomEvent : EventArgs
    {
        public string Message { get; set; }
        public CustomEvent(string str)
        {
            Message = str;

        }
        public static void ShowMessage(object obj, CustomEvent args)
        {
            Console.WriteLine($"{obj.GetType() }  {args.Message}");
        }
    }
    public class Car
    {
        public event EventHandler<CustomEvent> Fast;
        public event EventHandler<CustomEvent> Slow;

        public int CurSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public Car(int _s)
        {


            CurSpeed = 0;
            MaxSpeed = _s;
        }
        public void DriveFroward()
        {
            CurSpeed += 5;
            Console.WriteLine($"Скорость: {CurSpeed} | Макс. Скорость {MaxSpeed}");
            if (CurSpeed >= MaxSpeed && Fast != null)
            {
                Fast(this, new CustomEvent("Вы едете слишком быстро - это может повредить мотор"));
            }

        }
        public void DriveBack()
        {
            CurSpeed -= 5;
            Console.WriteLine($"Скорость: {CurSpeed} | Макс. Скорость {MaxSpeed}");
            if (CurSpeed < 0 && Slow != null)
            {
                CurSpeed = 0;
                Slow(this, new CustomEvent("Вы стоите на месте - прибавьте газу"));
            }
        }


    }
}
