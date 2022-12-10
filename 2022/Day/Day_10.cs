using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Day
{
	internal class Day_10 : BaseDay
	{
		private readonly string[] _input;

		public Day_10()
		{
			_input = File.ReadAllLines(InputFilePath);
		}

		public override ValueTask<string> Solve_1()
		{
			var cycleToFind = new[] { 20, 60, 100, 140, 180, 220 };
			var sol = Signal()
				.Where(signal => cycleToFind.Contains(signal.cycle))
				.Select(signal => signal.value * signal.cycle)
				.Sum();
			return new(sol.ToString());
		}

		public override ValueTask<string> Solve_2()
		{
			var screen = "";
			foreach (var signal in Signal())
			{
				var spriteMiddle = signal.value;
				var screenColumn = (signal.cycle - 1) % 40;

				screen += Math.Abs(spriteMiddle - screenColumn) < 2 ? "#" : ".";

				if (screenColumn == 39)
				{
					screen += "\n";
				}
			}

			return new(screen);
		}

		IEnumerable<(int cycle, int value)> Signal()
		{
			var (cycle, x) = (1, 1);

			foreach (var line in _input)
			{
				var parts = line.Split(" ");
				switch (parts[0])
				{
					case "noop":
						yield return (cycle++, x);
						break;
					case "addx":
						yield return (cycle++, x);
						yield return (cycle++, x);
						x += int.Parse(parts[1]);
						break;
					default:
						throw new ArgumentException(parts[0]);
				}
			}
		}
	}
}
