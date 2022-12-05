using System.Text.RegularExpressions;

namespace _2022.Day
{
	public class Day_05 : BaseDay
	{
		private readonly string[] _input;

		private Stack<char>[] stacks;

		record struct Move(int count, Stack<char> from, Stack<char> to);

		public Day_05()
		{
			_input = File.ReadAllText(InputFilePath).Split("\r\n\r\n");

		}

		public override ValueTask<string> Solve_1()
		{
			return new(Solve(CrateMover9000));
		}

		public override ValueTask<string> Solve_2()
		{
			return new(Solve(CrateMover9001));
		}

		private string Solve(Action<Move> crateFunction)
		{
			var cranestack = _input[0].Split("\r\n");

			stacks = cranestack.Last().Chunk(4).Select(i => new Stack<char>()).ToArray();

			foreach (var line in cranestack.Reverse().Skip(1))
			{
				foreach (var (stack, item) in stacks.Zip(line.Chunk(4)))
				{
					if (item[1] != ' ')
					{
						stack.Push(item[1]);
					}
				}
			}

			var instructions = _input[1].Split("\r\n");
			foreach (var line in instructions)
			{
				var m = Regex.Match(line, @"move (.*) from (.*) to (.*)");
				var count = int.Parse(m.Groups[1].Value);
				var from = int.Parse(m.Groups[2].Value) - 1;
				var to = int.Parse(m.Groups[3].Value) - 1;
				crateFunction(new Move(count, stacks[from], stacks[to]));
			}

			return new(string.Join("", stacks.Select(stack => stack.Pop())));
		}

		void CrateMover9000(Move move)
		{
			for (var i = 0; i < move.count; i++)
			{
				move.to.Push(move.from.Pop());
			}
		}

		void CrateMover9001(Move move)
		{
			var tempstack = new Stack<char>();

			CrateMover9000(move with { to = tempstack });
			CrateMover9000(move with { from = tempstack });
		}
	}
}
