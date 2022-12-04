namespace _2022.Day
{
	public class Day_04 : BaseDay
	{
		private readonly IEnumerable<int[][]> _input;

		public Day_04()
		{
			_input = File.ReadAllText(InputFilePath).Split("\r\n").Select(x => x.Split(",")
			.Select(y => y.Split("-").Select(int.Parse).ToArray()).ToArray());
		}

		public override ValueTask<string> Solve_1()
		{
			int sum = 0;
			foreach (var item in _input)
			{

				if ((item[0][0] <= item[1][0] && item[0][1] >= item[1][1]) ||
					(item[1][0] <= item[0][0] && item[1][1] >= item[0][1]))
				{
					sum++;
				}
			}
			return new(sum.ToString());
		}

		public override ValueTask<string> Solve_2()
		{
			int sum = 0;
			foreach (var item in _input)
			{
				if (!((item[0][1] < item[1][0]) || (item[0][0] > item[1][1])))
				{
					sum++;
				}
			}
			return new(sum.ToString());
		}
	}
}

