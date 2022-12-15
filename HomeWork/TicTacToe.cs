using System;

namespace HomeWork
{
    class TicTacToe
    {
        int[,] array = {
                           {0,0,0},
                           {0,0,0},
                           {0,0,0}

                       };
        int row = 0;
        int col = 0;
        int player = 1;
        static bool win;

        public static void Start()
        {
            Console.Clear();
            TicTacToe game = new TicTacToe();
            int counter = 0;
            Console.WriteLine("welcome to X-O game");
            while (counter < 9)
            {
                game.Print();
                game.GetInput();
                game.SetArray();
                win = game.CheckWinner();
                if (win)
                {
                    break;
                }
                game.ChangePlayer();

                counter++;
            }

            game.Print();
            game.PrintResult();
        }
        void Print()
        {
            Console.WriteLine();
            Console.WriteLine("Player" + player);
            Console.WriteLine("----------------------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Console.Write("-\t");
                    }
                    else if (array[i, j] == 1)
                    {
                        Console.Write("X\t");
                    }
                    else
                    {
                        Console.Write("O\t");
                    }
                }
                Console.WriteLine();
            }
        }
        void GetInput()
        {
            do
            {
                do
                {
                    Console.Write("Enter a Row:[1..3]");
                    string Rowstr = Console.ReadLine();
                    try
                    {
                        row = Convert.ToInt32(Rowstr);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                } while (row > 3 || row < 1);

                do
                {
                    Console.Write("Enter a Col:[1..3]");
                    string Colstr = Console.ReadLine();
                    try
                    {
                        col = Convert.ToInt32(Colstr);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input.");
                    }

                } while (col > 3 || col < 1);
                row--;
                col--;
            } while (array[row, col] != 0);

        }
        void SetArray()
        {
            if (player == 1)
            {
                array[row, col] = 1;
            }
            else
            {
                array[row, col] = 10;
            }
        }

        bool CheckWinner()
        {
            //calculate sum of rows
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += array[i, j];
                }
                if (sum == 3 || sum == 30)
                {
                    return true;
                }
                sum = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += array[j, i];
                }
                if (sum == 3 || sum == 30)
                {
                    return true;
                }

            }
            sum = array[1, 1] + array[2, 2] + array[0, 0];
            if (sum == 3 || sum == 30)
            {
                return true;
            }
            //calculate sum of sub diameter /
            sum = array[0, 2] + array[1, 1] + array[2, 0];
            if (sum == 3 || sum == 30)
            {
                return true;
            }
            return false;
        }
        void ChangePlayer()
        {
            if (player == 1)
            {
                player = 2;
            }
            else
            {
                player = 1;
            }
        }
        void PrintResult()
        {
            if (win)
            {
                if (player == 1)
                {
                    Console.WriteLine("Player 1 won the game");
                }
                else
                {
                    Console.WriteLine("Player 2 won the game");
                }
            }
            else
            {
                Console.WriteLine("Nobody won");
            }
        }
    }
}
