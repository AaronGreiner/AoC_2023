namespace AoC_Day_2
{
    internal class Hand
    {
        internal int CountRed { get; set; }
        internal int CountGreen { get; set; }
        internal int CountBlue { get; set; }

        internal Hand(string line)
        {
            foreach (string s in line.Split(','))
            {
                switch (s.Split(' ')[2])
                {
                    case "red":
                        CountRed += int.Parse(s.Split(' ')[1]);
                        break;
                    case "green":
                        CountGreen += int.Parse(s.Split(' ')[1]);
                        break;
                    case "blue":
                        CountBlue += int.Parse(s.Split(' ')[1]);
                        break;
                }
            }
        }
    }
}
