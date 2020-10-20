using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping p1 = new Ping();
            p1.Notify += DisplayMessage;
            Pong p2 = new Pong();
            p2.Notify += DisplayMessage;
            Console.WriteLine("Welcome to my app!");
            for(; ; )
            {
                Console.WriteLine("Select Ping(1) or Pong(2). To exit select 3.");
                int select = Input.SelectInput();
                if (select == 1)
                {
                    Console.WriteLine("You choosed Ping.\nDo you want to shoot? (Write 1 to shoot or 2 to exit.)");
                    int shselect = Input.ShootInput();
                    if (shselect == 1)
                    {
                        p1.Shoot();
                    }
                    else
                        break;
                }
                else if (select == 2)
                {
                    Console.WriteLine("You choosed Pong.\nDo you want to shoot? (Write 1 to shoot or 2 to exit.)");
                    int shselect = Input.ShootInput();
                    if (shselect == 1)
                    {
                        p2.Shoot();
                    }
                    else
                        break;
                }
                else
                    break;
                Console.WriteLine("Для продолжения нажмите любую клавишу!");
                            Console.ReadKey();
            }
            static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
    class Ping
    {
        public delegate void Message(string message);
        public event Message Notify;
        public string Sum { get; set; }
        public void Shoot()
        {
            Notify?.Invoke("Ping received Pong");
        }
    }
    class Pong
    {
        public delegate void Message(string message);
        public event Message Notify;
        public string Sum { get; set; }
        public void Shoot()
        {
            Notify?.Invoke("Pong received Ping");
        }
    }
    class Input
    {
        public static int SelectInput()
        {
            int nums = 0;

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0 && nums<4)
                    return nums;
                else
                {
                    Console.WriteLine("Choose 1, 2 or 3!");
                    return SelectInput();
                }
            }
            else
            {
                Console.WriteLine("Choose 1, 2 or 3!");
                return SelectInput();
            }
        }
        public static int ShootInput()
        {
            int nums = 0;

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0 && nums < 3)
                    return nums;
                else
                {
                    Console.WriteLine("Choose 1 or 2!");
                    return ShootInput();
                }
            }
            else
            {
                Console.WriteLine("Choose 1 or 2!");
                return ShootInput();
            }
        }
    }
}
