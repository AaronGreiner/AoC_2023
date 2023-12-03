using System.Drawing;

namespace AoC_Day_3
{
    internal class Number
    {
        internal int Value { get; set; }
        internal Point Start { get; set; }
        internal Point End { get; set; }

        internal void AppendDigit(char c)
        {
            Value = int.Parse(Value.ToString() + c.ToString());
        }
    }
}
