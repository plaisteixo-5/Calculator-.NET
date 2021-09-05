using System;
using System.IO;

namespace TextEditor
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
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Open the file\n2 - Create a new file\n0 - Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Open(); break;
                case 2: Edit(); break;
                case 0: System.Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("What is the file's path?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();

            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text below (ESC to exit):\n-----------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("What is the path's file?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"The file {path} was saved successfully");
            Menu();
        }
    }
}
