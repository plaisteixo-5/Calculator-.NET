using System;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Seconds -> 10s = 10 seconds\nM = Minute -> 1m = 1 minute\nE = Exit");
            Console.WriteLine("How much time do you want to count?");

            string data = Console.ReadLine().ToLower();

            if (data == "e") System.Environment.Exit(0);

            char type = data[data.Length - 1];
            int time = int.Parse(data.Substring(0, data.Length - 1));

            Start(time, type);
        }

        static void Start(int time, char type)
        {
            int currentTime = 0;
            int minutes = 0;
            if (type == 'm') time *= 60;

            while (time != currentTime)
            {
                Console.Clear();
                currentTime++;
                if (currentTime == 60)
                {
                    minutes++;
                    time -= currentTime;
                    currentTime = 0;
                }
                if (minutes != 0) Console.WriteLine(minutes + " minutes and " + currentTime + " seconds");
                else Console.WriteLine(currentTime + " seconds");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Stopwatch finished!!\nPress ENTER to back to MENU.");
            Console.ReadLine();
            Menu();
        }
    }
}
