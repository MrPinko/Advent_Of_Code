namespace _2022.Day.Day_01
{
    public class Day_01 : BaseDay
    {

        private IEnumerable<int> _input;

        public Day_01()
        {
            _input = File.ReadAllText(InputFilePath).Split("\r\n\r\n").Select(x => x.Split("\r\n").Select(int.Parse).Sum()).OrderDescending();
        }

        public override ValueTask<string> Solve_1()
        {
            var itemStash = _input.First();
            return new(itemStash.ToString());
        }


        public override ValueTask<string> Solve_2()
        {
            var itemStash = _input.Take(3).Sum();
            return new(itemStash.ToString());
        }

    }
}
