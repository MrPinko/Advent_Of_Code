using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022.Day
{
	internal class Day_06 : BaseDay
	{
		private readonly string _input;

		public Day_06()
		{
			_input = File.ReadAllText(InputFilePath);
		}

		public override ValueTask<string> Solve_1() => new(StartOfBlock(4).ToString());

		public override ValueTask<string> Solve_2() => new(StartOfBlock(14).ToString());

		int StartOfBlock(int l) =>
		 Enumerable.Range(l, _input.Length).First(i => _input.Substring(i - l, l).ToHashSet().Count == l);
	}
}
