using System;

namespace HomeWork
{
    class HomeWork
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Hello world");
            Console.WriteLine("2 - Tic Tac Toe");
            Console.WriteLine("3 - PhoneBook");


            Console.WriteLine("0 - close");
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
                case "3":
                    {
                        PhoneBook.Start();
                        return;
                    }

                case "0":
                    {
                        return;
                    }
            }
        }
    }
}
