using System;
using System.Collections.Generic;
using System.IO;

namespace AoC_Day_2
{
    internal class Program
    {
        private static List<Game> games = new List<Game>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../../input.txt");

            foreach (string s in input)
            {
                games.Add(new Game(s));
            }

            Console.WriteLine("Sum IDs for valid games: " + GetSumIdsValidGames());
            Console.WriteLine("Sum of the power of lowest sets: " + GetSumOfPowerOfSets());
        }

        private static int GetSumIdsValidGames()
        {
            int sumIds = 0;

            foreach (Game game in games)
            {
                if (game.GetMaxCountRed() <= 12 && game.GetMaxCountGreen() <= 13 && game.GetMaxCountBlue() <= 14)
                {
                    sumIds += game.Id;
                }
            }

            return sumIds;
        }

        private static int GetSumOfPowerOfSets()
        {
            int sumPower = 0;

            foreach (Game game in games)
            {
                sumPower += game.GetMaxCountRed() * game.GetMaxCountGreen() * game.GetMaxCountBlue();
            }

            return sumPower;
        }
    }
}
