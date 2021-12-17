namespace Puzzle2
{
    public class Program
    {
        const string FilePath = @"C:\Users\james.heavey\source\repos\AdventOfCode2021\Puzzle2\Puzzle2Input.txt";
        private static void Main()
        {
            Part1();

            Part2();
        }

        private static void Part1()
        {
            var lines = File.ReadAllLines(FilePath);

            var instructions = new List<string>();
            var magnitudes = new List<int>();

            foreach (var line in lines)
            {
                var split = line.Split(' ');
                instructions.Add(split[0]);
                magnitudes.Add(Convert.ToInt32(split[1]));
            }

            var submarine = new Submarine(0,0,0);

            for (int i = 0; i < lines.Count(); i++)
            {
                switch (instructions[i])
                {
                    case "forward":
                        submarine.X = submarine.X + magnitudes[i];
                        break;

                    case "up":
                        submarine.Y = submarine.Y - magnitudes[i];
                        break;

                    case "down":
                        submarine.Y = submarine.Y + magnitudes[i];
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"PART 1 - \nThe position is: {submarine.X}\n" +
                $"The depth is: {submarine.Y}\n" +
                $"The Answer is: {submarine.X*submarine.Y}");
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(FilePath);

            var instructions = new List<string>();
            var magnitudes = new List<int>();

            foreach (var line in lines)
            {
                var split = line.Split(' ');
                instructions.Add(split[0]);
                magnitudes.Add(Convert.ToInt32(split[1]));
            }

            var submarine = new Submarine(0, 0, 0);

            for (int i = 0; i < lines.Count(); i++)
            {
                switch (instructions[i])
                {
                    case "forward":
                        submarine.X = submarine.X + magnitudes[i];
                        submarine.Y = submarine.Y + (magnitudes[i] * submarine.AIM);
                        break;

                    case "up":
                        submarine.AIM = submarine.AIM - magnitudes[i];
                        break;

                    case "down":
                        submarine.AIM = submarine.AIM + magnitudes[i];
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"PART 2 - \nThe position is: {submarine.X}\n" +
                $"The depth is: {submarine.Y}\n" +
                $"The Answer is: {submarine.X * submarine.Y}");
        }
    }
}
