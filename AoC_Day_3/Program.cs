using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AoC_Day_3
{
    internal class Program
    {
        private static List<Number> numbers = new List<Number>();
        private static List<Symbol> symbols = new List<Symbol>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../../input.txt");

            InitLists(input);

            Console.WriteLine("Sum of all the part numbers: " + GetSumPartNumbers());
            Console.WriteLine("Sum of all gear ratios: " + GetSumGearRatios());
        }

        private static void InitLists(string[] rows)
        {
            for (int i  = 0; i < rows.Length; i++)
            {
                char[] chars = rows[i].ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    if (Char.IsDigit(chars[j]))
                    {
                        Number number = new Number();
                        number.Start = new Point(i, j);

                        while (j < chars.Length && Char.IsDigit(chars[j]))
                        {
                            number.AppendDigit(chars[j]);
                            j++;
                        }

                        j--;
                        number.End = new Point(i, j);
                        numbers.Add(number);
                    }
                    else if (chars[j] != '.')
                    {
                        Symbol symbol = new Symbol();
                        symbol.Type = chars[j];
                        symbol.Position = new Point(i, j);
                        symbols.Add(symbol);
                    }
                }
            }
        }

        private static int GetSumPartNumbers()
        {
            return numbers
                .Where(n => symbols.Any(s => IsAdjacent(n, s)))
                .Sum(n => n.Value);
        }

        private static int GetSumGearRatios()
        {
            return symbols
                .Where(s => s.Type == '*')
                .Select(s => numbers
                    .Where(n => IsAdjacent(n, s)).ToList())
                .Where(g => g.Count() == 2)
                .Sum(g => g[0].Value * g[1].Value);
        }

        private static bool IsAdjacent(Number n, Symbol s)
        {
            return Math.Abs(s.Position.X - n.Start.X) <= 1
                && s.Position.Y >= n.Start.Y - 1
                && s.Position.Y <= n.End.Y + 1;
        }
    }
}
