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
            var readings = new string[2];

            for (var i = 0; i < binaries[0].Length; i++)
            {
                readings[0] += binaries.Count(c => c[i] == '1') >= binaries.Count(c => c[i] == '0') ? '1' : '0';
                readings[1] += binaries.Count(c => c[i] == '1') >= binaries.Count(c => c[i] == '0') ? '0' : '1';
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

            for (var i = 0; i < binaries[0].Length; i++)
            {
                var CO2commonVal = CO2.Count(c => c[i] == '1') >= CO2.Count(c => c[i] == '0') ? '1' : '0';
                var O2commonVal = O2.Count(c => c[i] == '1') >= O2.Count(c => c[i] == '0') ? '0' : '1';

                if (CO2.Count > 1) CO2.RemoveAll(x => x[i] == CO2commonVal);
                if (CO2.Count > 1) O2.RemoveAll(x => x[i] == O2commonVal);
            }

            Console.WriteLine($"PART 2 - \nThe O2 is: {CO2[0]}\n" +
                $"The CO2 is: {O2[0]}\n" +
                $"The Answer is: {Convert.ToInt32(CO2[0], 2) * Convert.ToInt32(O2[0], 2)}");
        }
    }
}
