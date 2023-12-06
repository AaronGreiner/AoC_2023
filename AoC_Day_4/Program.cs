using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_Day_4
{
    internal class Program
    {
        private static List<Card> cards = new List<Card>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../../input.txt");

            int totalScore = 0;

            foreach (string s in input)
            {
                cards.Add(new Card(
                    GetListNumbers(s.Split(':')[1].Split('|')[0]), 
                    GetListNumbers(s.Split(':')[1].Split('|')[1])));
            }

            foreach (Card card in cards)
            {
                totalScore += card.GetScore();
            }

            Console.WriteLine("Total points: " + totalScore);
            Console.WriteLine("Total number of scratchcards: " + "TODO");
        }

        private static List<int> GetListNumbers(string s)
        {
            Regex regex = new Regex(@"\d+");
            return regex.Matches(s).Cast<Match>().Select(m => int.Parse(m.Value)).ToList();
        }
    }
}
