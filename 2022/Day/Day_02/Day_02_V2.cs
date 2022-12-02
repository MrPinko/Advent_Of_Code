namespace _2022.Day.Day_02
{
	public class Day_02_V2 : BaseDay
	{
		private readonly IEnumerable<string> _input;

		public Day_02_V2()
		{
			_input = File.ReadLines("./Inputs/02.txt");
		}

		public override ValueTask<string> Solve_1()
		{
			//A for Rock, B for Paper, C for Scissors

			//X for Rock, Y for Paper, Z for Scissors.

			//score 1 for Rock, 2 for Paper, and 3 for Scissors

			//0 if you lost, 3 if the round was a draw, and 6 if you won.

			var points = _input.Aggregate(0, (acc, val) =>
			{
				return acc + val switch
				{
					"A X" => 4, //draw
					"A Y" => 8, //win
					"A Z" => 3, //lose
					"B X" => 1, //lose
					"B Y" => 5, //draw
					"B Z" => 9, //win
					"C X" => 7, //win
					"C Y" => 2, //lose
					"C Z" => 6, //draw
					_ => throw new NotImplementedException(),
				};
			});

			return new(points.ToString());

		}

		public override ValueTask<string> Solve_2()
		{
			//X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win

			var points = _input.Aggregate(0, (acc, val) =>
			{
				return acc + val switch
				{
					"A X" => 3,
					"A Y" => 4,
					"A Z" => 8,
					"B X" => 1,
					"B Y" => 5,
					"B Z" => 9,
					"C X" => 2,
					"C Y" => 6,
					"C Z" => 7,
					_ => throw new NotImplementedException()
				};
			});

			return new(points.ToString());
		}

	}
}
