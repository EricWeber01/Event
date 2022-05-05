using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public abstract class Auto
    {
        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }
        public int Range { get; set; }
        public string Name { get; set; }
        public bool Win { get; set; }

        public Auto(int _s)
        {
            Win = false;
            Speed = _s;
            Range = 0;
        }
        public abstract void ChangeSpeed();
        public abstract bool IsWin();
        public abstract void Show();


    }
    public class SportCar : Auto
    {
        public event EventHandler<CustomEvent> Start;
        public event EventHandler<CustomEvent> Finish;
        public SportCar(int _s) : base(_s)
        {
            Name = "Спортивное Авто";
            Start += CustomEvent.ShowMessage;
            Finish += CustomEvent.ShowMessage;
            Start(this, new CustomEvent($"{this.Name} has been start the race"));
        }

        public override void ChangeSpeed()
        {
            Random rnd = new Random();
            CurrentSpeed = rnd.Next(Speed - 10, Speed + 20);
            Range += CurrentSpeed;

            Win = IsWin();
        }

        public override bool IsWin()
        {
            if (Range >= 1000)
            {
                Finish(this, new CustomEvent($"{this.Name} has been finish the race"));
                return true;
            }
            else
                return false;
        }

        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} | Speed: {CurrentSpeed}(km/h) | Distance {Range}/1000");
            Console.Write("[");
            for (int i = 0; i <= 1000; i += 100)
            {
                if (i <= Range)
                    Console.Write("||||");
                else
                    Console.Write("....");
            }
            Console.Write("]");
            Console.ResetColor();
        }
    }
    public class LightCar : Auto
    {
        public event EventHandler<CustomEvent> Start;
        public event EventHandler<CustomEvent> Finish;
        public LightCar(int _s) : base(_s)
        {
            Name = "Легковое Авто";
            Start += CustomEvent.ShowMessage;
            Finish += CustomEvent.ShowMessage;
            Start(this, new CustomEvent($"{this.Name} has been start the race"));
        }

        public override void ChangeSpeed()
        {
            Random rnd = new Random();
            CurrentSpeed = rnd.Next(Speed - 10, Speed + 10);
            Range += CurrentSpeed;


            Win = IsWin();

        }

        public override bool IsWin()
        {
            if (Range >= 1000)
            {
                Finish(this, new CustomEvent($"{this.Name} has been finish the race"));
                return true;
            }
            else
                return false;
        }

        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} | Speed: {CurrentSpeed}(km/h) | Distance {Range}/1000");
            Console.Write("[");
            for (int i = 0; i <= 1000; i += 100)
            {
                if (i <= Range)
                    Console.Write("||||");
                else
                    Console.Write("....");
            }
            Console.Write("]");
            Console.ResetColor();
        }
    }

    public class HeavyCar : Auto
    {
        public event EventHandler<CustomEvent> Start;
        public event EventHandler<CustomEvent> Finish;
        public HeavyCar(int _s) : base(_s)
        {
            Name = "Тяжелое Авто";
            Start += CustomEvent.ShowMessage;
            Finish += CustomEvent.ShowMessage;
            Start(this, new CustomEvent($"{this.Name} has been start the race"));
        }

        public override void ChangeSpeed()
        {
            Random rnd = new Random();
            CurrentSpeed = rnd.Next(Speed - 20, Speed + 10);
            Range += CurrentSpeed;

            Win = IsWin();
        }

        public override bool IsWin()
        {
            if (Range >= 1000)
            {
                Finish(this, new CustomEvent($"{this.Name} has been finish the race"));
                return true;
            }
            else
                return false;
        }

        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} | Speed: {CurrentSpeed}(km/h) | Distance {Range}/1000");
            Console.Write("[");
            for (int i = 0; i <= 1000; i += 100)
            {
                if (i <= Range)
                    Console.Write("||||");
                else
                    Console.Write("....");
            }
            Console.Write("]");
            Console.ResetColor();
        }
    }
    public class Bus : Auto
    {
        public event EventHandler<CustomEvent> Start;
        public event EventHandler<CustomEvent> Finish;
        public Bus(int _s) : base(_s)
        {
            Name = "Автобус";
            Start += CustomEvent.ShowMessage;
            Finish += CustomEvent.ShowMessage;
            Start(this, new CustomEvent($"{this.Name} has been start the race"));
        }

        public override void ChangeSpeed()
        {
            Random rnd = new Random();
            CurrentSpeed = rnd.Next(Speed - 15, Speed + 5);
            Range += CurrentSpeed;

            Win = IsWin();
        }

        public override bool IsWin()
        {
            if (Range >= 1000)
            {
                Finish(this, new CustomEvent($"{this.Name} has been finish the race"));
                return true;
            }
            else
                return false;
        }

        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} | Speed: {CurrentSpeed}(km/h) | Distance {Range}/1000");
            Console.Write("[");
            for (int i = 0; i <= 1000; i += 100)
            {
                if (i <= Range)
                    Console.Write("||||");
                else
                    Console.Write("....");
            }
            Console.Write("]");
            Console.ResetColor();
        }
    }

    public class Race
    {
        Random rnd = new Random();
        Auto[] cars;
        Action[] SpeedAction;
        Action[] ShowAction;

        public Race()
        {
            cars = new Auto[] { new SportCar(rnd.Next(140, 160)), new LightCar(rnd.Next(140, 140)), new HeavyCar(rnd.Next(100, 120)), new Bus(rnd.Next(90, 100)) };
            SpeedAction = new Action[] { cars[0].ChangeSpeed, cars[1].ChangeSpeed, cars[2].ChangeSpeed, cars[3].ChangeSpeed };
            ShowAction = new Action[] { cars[0].Show, cars[1].Show, cars[2].Show, cars[3].Show };

        }
        public void StartRace()
        {
            int leap = 0;
            do
            {
                Console.WriteLine($"\n-----------LEAP {++leap}-----------\n");
                for (int i = 0; i < 4; i++)
                {
                    SpeedAction[i]();

                    ShowAction[i]();
                    Console.WriteLine();
                }


            } while (!cars[0].Win && !cars[1].Win && !cars[2].Win && !cars[3].Win);



        }

    }
}