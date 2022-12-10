using System.Text.RegularExpressions;

namespace _2022.Day
{
	internal class Day_07 : BaseDay
	{
		private readonly string[] _input;

		public Day_07()
		{
			_input = File.ReadAllLines(InputFilePath);
		}

		public override ValueTask<string> Solve_1()
		{
			var path = new Stack<string>();
			var sizes = new Dictionary<string, int>();

			var sol = GetDirectorySizes().Where(w => w < 100_000).Sum();

			return new(sol.ToString());
		}

		public override ValueTask<string> Solve_2()
		{
			var directorySpace = GetDirectorySizes();
			var freeSpace = 70_000_000 - directorySpace.Max();
			return new(directorySpace.Where(size => freeSpace + size >= 30_000_000).Min().ToString());
		}

		private List<int> GetDirectorySizes()
		{
			var path = new Stack<string>();
			var sizes = new Dictionary<string, int>();
			foreach (var line in _input)
			{
				if (line == "$ cd ..")
				{
					path.Pop();
				}
				else if (line.StartsWith("$ cd"))
				{
					path.Push(string.Join("", path) + line.Split(" ")[2]);
				}
				else if (Regex.Match(line, @"\d+").Success)
				{
					var size = int.Parse(line.Split(" ")[0]);
					foreach (var dir in path)
					{
						sizes[dir] = sizes.GetValueOrDefault(dir) + size;
					}
				}
			}
			return sizes.Values.ToList();
		}

	}
}
