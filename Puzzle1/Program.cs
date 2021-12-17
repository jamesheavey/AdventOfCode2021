namespace Puzzle1
{
    public class Program
    {
        const string FilePath = @"C:\Users\james.heavey\source\repos\AdventOfCode2021\Puzzle1\Puzzle1Input.txt";
        private static void Main()
        {
            Part1();

            Part2();
        }

        private static void Part1()
        {
            var lines = File.ReadAllLines(FilePath)
                .Select(t => Convert.ToInt32(t)).ToList();

            var depthIncrease = 0;

            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i] > lines[i - 1])
                {
                    depthIncrease++;
                }
            }

            Console.WriteLine($"PART 1 - The depth increased {depthIncrease} times");
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(FilePath)
                .Select(t => Convert.ToInt32(t)).ToList();

            var depthIncrease = 0;

            for (int i = 1; i < lines.Count - 2; i++)
            {
                // sum of moving window comparison has same elements i and i+1 therefore compare extremes
                if (lines[i+2] > lines[i-1])
                {
                    depthIncrease++;
                }
            }

            Console.WriteLine($"PART 2 - The depth increased {depthIncrease} times");
        }
    }
}