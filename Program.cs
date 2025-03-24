using System;
using System.Collections.Specialized;

namespace Maze 
{        
    //For Future Me : WTF is this code? I don't know either. I was just trying to make a maze game.
    class Program
    {    
        static char[,] Grid = new char[100,100];
        static int W = 100, H = 10;
        static int PW = 0, PH = 0;
        static void Play()
        {            
            Console.Clear();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Console.Write(Grid[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void GeneratePath()
        {
            int x = 0, y = 0;
            Grid[y, x] = ' '; 

            Random random = new Random();
            while (x < W - 2 && y < H - 2)
            {
                if (random.Next(2) == 0)
                {
                    x++;
                }
                else
                {
                    y++;
                }
                Grid[y, x] = ' ';
            }

            while (x < W - 1)
            {
                x++;
                Grid[y, x] = ' ';
            }
            while (y < H - 1)
            {
                y++;
                Grid[y, x] = ' ';
            }
        }
        static void Game()
        {
            //default
            Random random = new Random();            
            for (int i = 0; i < H; i++) 
            {
                for (int j = 0; j < W; j++)
                {
                    if (i == 0 || i == W - 1 || j == 0 || j == H - 1)
                    {
                        Grid[i,j] = '0';
                    }
                    else if (random.Next(1, 5) == 1)
                    {
                        Grid[i, j] = ' ';
                    }
                    else
                    {
                        Grid[i, j] = '0';
                    }
                }                                
            }
            GeneratePath();            
            string Title = "Welcome to the Maze Game! \nUse W, A, S, D to move the player.";
            foreach (char c in Title)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Thread.Sleep(1500);
            Play();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Maze Game! \n1: for Start\n2: for Exit");
                Console.Write("Enter your choice: ");
                int choice;
                while(!(int.TryParse(Console.ReadLine(),out choice)&& choice > 0 && choice < 3))
                {
                    Console.WriteLine("Invalid choice! Please enter a valid choice.");
                    Console.Write("Enter your choice: ");
                }
                switch (choice)
                {
                    case 1:
                        Game();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }                
                Console.WriteLine("Do you want to play again? \n1: Yes\n2: No");
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 3))
                {
                    Console.WriteLine("Invalid choice! Please enter a valid choice.");
                    Console.Write("Enter your choice: ");
                }
                if (choice != 1) break;
            }
        }
    }
}