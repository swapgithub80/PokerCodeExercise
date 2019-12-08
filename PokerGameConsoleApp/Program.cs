using System;
using System.Linq;
using System.Text;
using PokerGameConsoleApp.Common;
namespace PokerGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.SetWindowSize(65, 40);
                Console.BufferWidth = 65;
                Console.BufferHeight = 40;
                Console.Title = "Poker Game";
                string playagain = "Y";
                do
                {
                    LetsPlay();
                    Console.WriteLine("\nPlay Again / Quit Game ? (Y/N) ");
                    if (Console.ReadLine().ToUpper() == "N")
                    {
                        playagain = "N";
                        break;
                    }

                } while (playagain != "N");
                Console.WriteLine("Thank you for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: \n {ex}");
                Console.ReadLine();
            }
        }

        private static void LetsPlay()
        {
            try
            {
                     Console.WriteLine("Enter the cards from the players' hands: \n");
                     string hands = Console.ReadLine();
                     string winner = CardDataValidations.EvaluatePokerHands(hands);
                     Console.WriteLine(winner);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}