namespace Puzzle2
{
    public class Program
    {
        const string FileName = "Puzzle3Input.txt";
        static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\");

        private static void Main()
        {
            var binaries = File.ReadAllLines(@$"{FilePath}\{FileName}")
                .ToList();

        }

        private static void Part1()
        {

        }

        public static void Part2()
        {

        }
    }
}
