using System.Collections.Generic;

namespace AoC_Day_2
{
    internal class Game
    {
        internal int Id { get; set; }
        internal List<Hand> Hands { get; set; }

        internal Game(string line) 
        {
            string info = line.Split(':')[0];
            string data = line.Split(':')[1];

            Id = int.Parse(info.Split(' ')[1]);

            Hands = new List<Hand>();
            
            foreach (string s in data.Split(';'))
            {
                Hands.Add(new Hand(s));
            }
        }

        internal int GetMaxCountRed()
        {
            int max = 0;

            foreach (Hand h in Hands)
            {
                if (h.CountRed > max)
                {
                    max = h.CountRed;
                }
            }

            return max;
        }

        internal int GetMaxCountGreen()
        {
            int max = 0;

            foreach (Hand h in Hands)
            {
                if (h.CountGreen > max)
                {
                    max = h.CountGreen;
                }
            }

            return max;
        }

        internal int GetMaxCountBlue()
        {
            int max = 0;

            foreach (Hand h in Hands)
            {
                if (h.CountBlue > max)
                {
                    max = h.CountBlue;
                }
            }

            return max;
        }
    }
}
