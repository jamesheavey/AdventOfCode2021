namespace Puzzle2
{
    public class Program
    {
        const string FileName = "Puzzle2Input.txt";
        static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\");

        static List<(string inst, int mag)> commands;

        private static void Main()
        {
            commands = File.ReadAllLines(@$"{FilePath}\{FileName}")
                .Select(l => l.Split())
                .Select(x => (x[0], Convert.ToInt32(x[1])))
                .ToList();

            Part1();

            Part2();
        }

        private static void Part1()
        {
            var submarine = new Submarine(0,0,0);

            foreach (var (inst, mag) in commands)
            {
                switch (inst)
                {
                    case "forward": submarine.X += mag;
                        break;

                    case "up": submarine.Y -= mag;
                        break;

                    case "down": submarine.Y += mag;
                        break;
                }
            }

            Console.WriteLine($"PART 1 - \nThe position is: {submarine.X}\n" +
                $"The depth is: {submarine.Y}\n" +
                $"The Answer is: {submarine.X*submarine.Y}");
        }

        public static void Part2()
        {
            var submarine = new Submarine(0, 0, 0);

            foreach (var (inst, mag) in commands)
            {
                switch (inst)
                {
                    case "forward":
                        submarine.X += mag;
                        submarine.Y += (mag * submarine.AIM);
                        break;

                    case "up": submarine.AIM -= mag;
                        break;

                    case "down": submarine.AIM += mag;
                        break;
                }
            }

            Console.WriteLine($"PART 2 - \nThe position is: {submarine.X}\n" +
                $"The depth is: {submarine.Y}\n" +
                $"The Answer is: {submarine.X * submarine.Y}");
        }
    }
}
