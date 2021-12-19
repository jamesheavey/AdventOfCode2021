namespace Puzzle3
{
    public class Program
    {
        const string FileName = "Puzzle3Input.txt";
        static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\");

        static List<string> binaries;

        private static void Main()
        {
            binaries = File.ReadAllLines(@$"{FilePath}\{FileName}")
                .ToList();

            Part1();

            Part2();
        }

        private static void Part1()
        {
            var counts = new int[binaries[0].Length];

            foreach (var bin in binaries)
            {
                for (var i = 0; i < bin.Length; i++)
                {
                    counts[i] += bin[i] == '1' ? 1 : 0;
                }
            }

            var readings = new string[2];

            foreach (var digit in counts)
            {
                Console.WriteLine(digit);
                readings[0] += digit >= binaries.Count / 2 ? "1" : "0";
                readings[1] += digit <= binaries.Count / 2 ? "1" : "0";
            }
            Console.WriteLine(binaries.Count);

            Console.WriteLine($"PART 1 - \nThe gamma is: {readings[0]}\n" +
                $"The epsilon is: {readings[1]}\n" +
                $"The Answer is: {Convert.ToInt32(readings[0], 2) * Convert.ToInt32(readings[1], 2)}");
        }

        public static void Part2()
        {
            var CO2 = new List<string>(binaries);
            var O2 = new List<string>(binaries);

            for (var i = 0; i < CO2[0].Length; i++)
            {
                Console.WriteLine($"CO2: {CO2.Count}, O2: {O2.Count}");

                if (CO2.Count == 1) { }
                else
                {
                    var commonVal = CO2.Count(c => c[i] == '1') >= CO2.Count(c => c[i] == '0') ? '1' : '0';

                    CO2.RemoveAll(x => x[i] == commonVal);
                }

                if (O2.Count == 1) { }
                else
                {
                    var commonVal = O2.Count(c => c[i] == '1') >= O2.Count(c => c[i] == '0') ? '0' : '1';

                    O2.RemoveAll(x => x[i] == commonVal);
                }
            }

            Console.WriteLine($"PART 2 - \nThe O2 is: {CO2[0]}\n" +
                $"The CO2 is: {O2[0]}\n" +
                $"The Answer is: {Convert.ToInt32(CO2[0], 2) * Convert.ToInt32(O2[0], 2)}");
        }
    }
}
