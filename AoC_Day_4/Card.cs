using System.Collections.Generic;
using System.Linq;

namespace AoC_Day_4
{
    internal class Card
    {
        private List<int> WinningNumbers;
        private List<int> MyNumbers;

        internal Card(List<int> winningNumbers, List<int> myNumbers)
        {
            WinningNumbers = winningNumbers;
            MyNumbers = myNumbers;
        }

        internal int GetScore()
        {
            int score = 0;
            int matches = GetMatches();

            for (int i = 0; i < matches; i++)
            {
                score = (score == 0) ? 1 : (score == 1) ? 2 : score * 2;
            }

            return score;
        }

        internal int GetMatches()
        {
            List<int> matches = MyNumbers.Intersect(WinningNumbers).ToList();

            return matches.Count;
        }
    }
}
