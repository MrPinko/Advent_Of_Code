namespace _2022.Day
{
	public class Day_02 : BaseDay
	{
		private readonly IEnumerable<string[]> _input;

		#region Static Variable

		#region Dictionary Variable

		Dictionary<string, string> winHandOn = new Dictionary<string, string>()
		{
			{ "A", "B" }, //rock , paper
			{ "B", "C" }, //paper , scissor
			{ "C", "A" }, //scissor , rock
		};

		Dictionary<string, string> loseCombination = new Dictionary<string, string>()
		{
			{ "B", "A" }, //paper , rock
			{ "C", "B" }, //scissor , paper
			{ "A", "C" }, //rock , scissor
		};

		Dictionary<string, string> conversionPart1 = new Dictionary<string, string>()
		{
			{ "Y", "B" }, //rock , paper
			{ "Z", "C" }, //paper , scissor
			{ "X", "A" }, //scissor , rock
		};

		Dictionary<string, string> conversionPart2 = new Dictionary<string, string>()
		{
			{ "Y", "DRAW" }, //rock , need to draw
			{ "Z", "WIN" }, //paper , need to win
			{ "X", "LOSE" }, //scissor , need to lose
		};

		Dictionary<string, int> pointsHand = new Dictionary<string, int>()
		{
			{ "A", 1 }, //rock
			{ "B", 2 }, //paper
			{ "C", 3 }, //scissor
		};

		#endregion

		enum PointsOutcome : int
		{
			lost = 0,
			draw = 3,
			win = 6
		}
		#endregion

		public Day_02()
		{
			_input = File.ReadAllText(InputFilePath).Split("\r\n").Select(s => s.Split(" "));
		}

		public override ValueTask<string> Solve_1()
		{
			int score = 0;
			foreach (var item in _input)
			{
				var elfHand = item[0];
				string myHand = conversionPart1[item[1]];
				var pointsValue = pointsHand[myHand];

				if (winHandOn[elfHand] == myHand)
				{
					score += (int)PointsOutcome.win + pointsValue;
				}
				else if (elfHand == myHand)
				{
					score += (int)PointsOutcome.draw + pointsValue;
				}
				else
				{
					score += (int)PointsOutcome.lost + pointsValue;
				}

			}

			return new(score.ToString());
		}

		public override ValueTask<string> Solve_2()
		{
			int score = 0;
			foreach (var item in _input)
			{
				var elfHand = item[0];
				var outcomeNeeded = conversionPart2[item[1]];

				switch (outcomeNeeded)
				{
					case "WIN":
						score += (int)PointsOutcome.win + pointsHand[winHandOn[elfHand]];
						break;

					case "DRAW":
						score += (int)PointsOutcome.draw + pointsHand[elfHand];
						break;

					case "LOSE":
						score += (int)PointsOutcome.lost + pointsHand[loseCombination[elfHand]];
						break;
				}

			}

			return new(score.ToString());
		}
	}
}
