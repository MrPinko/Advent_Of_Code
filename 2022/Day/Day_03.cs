namespace _2022.Day
{
	public class Day_03 : BaseDay
	{
		private readonly IEnumerable<string[]> _input;
		private readonly IEnumerable<string[]> _inputPart2;

		public Day_03()
		{
			_input = File.ReadAllText(InputFilePath).Split("\r\n").Select(x => x.splitByHalf());

			_inputPart2 = File.ReadAllLines(InputFilePath).Chunk(3);
		}

		public override ValueTask<string> Solve_1()
		{
			string sameType = "";
			foreach (var item in _input)
			{
				foreach (var character in item[0])
				{
					if (item[1].Contains(character))
					{
						sameType += character;
						break;
					}
				}
			}

			return new(sameType.Sum(CalculatePriority).ToString());

		}

		public int CalculatePriority(char c)
		{
			return char.IsUpper(c)
				? c - 38
				: c - 96;
		}

		public override ValueTask<string> Solve_2()
		{
			int solution = _inputPart2.Select(group => group[0].Intersect(group[1]).Intersect(group[2]).Single())
				.Sum(CalculatePriority);

			return new(solution.ToString());
		}
	}
	public static class SplitStringByHalf
	{
		public static string[] splitByHalf(this string input)
		{
			int halfOfLength = input.Length / 2;

			var firstHalf = input.Substring(0, halfOfLength);
			var secondHalf = input.Substring(halfOfLength);

			return new[] { firstHalf, secondHalf };
		}

	}
}