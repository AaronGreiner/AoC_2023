using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../../input.txt");

            List<int> calibrationValues = new List<int>();
            List<int> realCalibrationValues = new List<int>();

            foreach (string s in input)
            {
                calibrationValues.Add(GetCalibrationValue(s));
                realCalibrationValues.Add(GetRealCalibrationValue(s));
            }

            Console.WriteLine("Sum of all the calibration values: " + calibrationValues.Sum());
            Console.WriteLine("Sum of all the real calibration values: " + realCalibrationValues.Sum());
        }

        private static int GetCalibrationValue(string s)
        {
            Regex regex = new Regex(@"\d");
            List<string> matches = regex.Matches(s).Cast<Match>().Select(m => m.Value).ToList();

            return int.Parse(matches.First() + matches.Last());
        }

        private static int GetRealCalibrationValue(string s)
        {
            Regex regex = new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");
            List<string> matches = regex.Matches(s).Cast<Match>().Select(m => m.Groups[1].Value).ToList();

            return int.Parse(ConvertValue(matches.First()) + ConvertValue(matches.Last()));
        }

        private static string ConvertValue(string s)
        {
            switch (s)
            {
                case "one":   return "1";
                case "two":   return "2";
                case "three": return "3";
                case "four":  return "4";
                case "five":  return "5";
                case "six":   return "6";
                case "seven": return "7";
                case "eight": return "8";
                case "nine":  return "9";
                default:      return s;
            }
        }
    }
}
