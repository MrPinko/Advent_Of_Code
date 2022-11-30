using System.ComponentModel;

namespace _2022.Day
{
    public class Day_01 : BaseDay
    {
        private readonly string _input;
        public Day_01()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() => new($"Solution 1 {ClassPrefix} {CalculateIndex()}");


        public override ValueTask<string> Solve_2() => new("Solution 2");

    }
}
