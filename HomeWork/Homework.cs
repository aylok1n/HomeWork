using System;

namespace HomeWork
{
    class HomeWork
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Hello world");
            Console.WriteLine("2 - Tic Tac Toe");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": 
                    {
                        HelloWorld.Start();
                        return;
                    }
                case "2":
                    {
                        TicTacToe.Start();
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}
