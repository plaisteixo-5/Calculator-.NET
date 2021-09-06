using System;

namespace EditorHTML
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;

            DrawScreen();
            WriteOprions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);

        }

        public static void DrawScreen()
        {
            DrawSuperiorInferiorEdge('*', '*');
            DrawLateralEdge('*');
            DrawSuperiorInferiorEdge('*', '*');
        }

        public static void DrawSuperiorInferiorEdge(char edge = '+', char middle = '-')
        {
            Console.Write(edge);
            for (int i = 0; i <= 30; i++) Console.Write(middle);
            Console.Write(edge);

            Console.Write("\n");
        }

        public static void DrawLateralEdge(char edge = '|', char middle = ' ')
        {
            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write(edge);
                for (int i = 0; i <= 30; i++) Console.Write(middle);
                Console.Write(edge);
                Console.Write("\n");
            }
        }

        public static void WriteOprions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("=================");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}