
Console.WriteLine("====================");
Console.WriteLine("      AOC 2022      ");
Console.WriteLine("       DOTNET       ");
Console.WriteLine("====================");
Console.WriteLine("SELECT:");
Console.WriteLine("1 FOR SOLVE ALL DAYS");
Console.WriteLine("2 FOR SOLVE LAST DAY");
Console.WriteLine("");

//string? menu = Console.ReadLine();
string menu = "2";
switch (menu)
{
    case "1":
        await Solver.SolveAll(opt =>
        {
            opt.ElapsedTimeFormatSpecifier = "F3";
        });
        break;

    case "2":
        await Solver.SolveLast(opt =>
        {
			opt.ElapsedTimeFormatSpecifier = "F3";
        });
        break;

    default:
        Console.WriteLine("INVALID OPTION");
        break;
}



