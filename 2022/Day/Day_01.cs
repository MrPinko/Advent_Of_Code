
namespace _2022.Day
{
    public class Day_01 : BaseDay
    {

		private IEnumerable<IEnumerable<int>> _input;

		public Day_01()
		{
			_input = File.ReadAllText(InputFilePath).Split("\r\n\r\n").Select(x => x.Split("\r\n").Select(int.Parse));
		}

        public override ValueTask<string> Solve_1()
        {
			var itemStash = _input.Select(elf => elf.Aggregate(0, (acc, value) => acc + value));
			return new(itemStash.Max().ToString());
		}

		public override ValueTask<string> Solve_2()
        {
			var itemStash = _input.Select(elf => elf.Aggregate(0, (acc, value) => acc + value)).OrderDescending().Take(3).Sum();
			return new(itemStash.ToString());
		}

	}
}
