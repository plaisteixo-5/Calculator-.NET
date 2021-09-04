using System;

namespace Calculator
{
    class Program
    {

        static void Main(string[] args)
        {

            int? control = null;

            Console.Clear();

            Console.WriteLine("Digite o primeiro valor: ");
            float value1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Digite o segundo valor: ");
            float value2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            while (control != 0)
            {
                control = SelectControl();

                Console.Clear();

                switch (control)
                {
                    case 1: Sum(value1, value2); break;
                    case 2: Sub(value1, value2); break;
                    case 3: Div(value1, value2); break;
                    case 4: Mult(value1, value2); break;
                    case 0: break;
                    default: Console.WriteLine("Select a valid comand!"); break;
                }
            }

        }

        static int SelectControl()
        {
            int control;

            Console.Clear();
            Console.WriteLine("Options:\n1 - Sum\n2 - Subtract\n3 - Divide\n4 - Multiply\n0 - Exit\n-------------------");
            Console.Write("Choose One: ");
            control = int.Parse(Console.ReadLine());

            return control;
        }

        static void Sum(float v1, float v2)
        {
            Console.WriteLine($"The sum of {v1} and {v2} is {v1 + v2}\nPress ENTER to back to menu.");
            Console.ReadLine();
        }

        static void Sub(float v1, float v2)
        {
            Console.WriteLine($"The sub of {v1} and {v2} is {v1 - v2}\nPress ENTER to back to menu.");
            Console.ReadLine();
        }

        static void Div(float v1, float v2)
        {
            if (v2 == 0)
            {
                Console.WriteLine("It's not possible divide anything by zero\nPress ENTER to back to menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"The divide of {v1} / {v2} is {v1 / v2}\nPress ENTER to back to menu.");
                Console.ReadLine();
            }
        }

        static void Mult(float v1, float v2)
        {
            Console.WriteLine($"The multiplication of {v1} * {v2} is {v1 * v2}\nPress ENTER to back to menu.");
            Console.ReadLine();
        }
    }
}
