using System.Drawing;

namespace Day10
{
    internal class Program
    {
        private static int cycleNo = 0;
        private static int x = 1;
        private static int totalSignalStrength = 0;

        private static int xPos = 1;
        private static Point scanPoint = new Point(0, 0);
        private static string[] display = new string[6];

        static void Main(string[] args)
        {
            CaclulateSignalStrengths();

            DrawSomeStuff();
        }

        private static void CaclulateSignalStrengths()
        {
            using StringReader reader = new(DayInput);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                DoCycle(0);
                if (parts[0] == "addx")
                {
                    DoCycle(int.Parse(parts[1]));
                }
            }

            Console.WriteLine("Sum of signal strengths = " + totalSignalStrength);
        }

        private static void DoCycle(int xDiff)
        {
            cycleNo++;
            if (cycleNo == 20
                || cycleNo == 60
                || cycleNo == 100
                || cycleNo == 140
                || cycleNo == 180
                || cycleNo == 220)
            {
                totalSignalStrength += (cycleNo * x);
                Console.WriteLine("Signal strength cycle:" + cycleNo + " = " + cycleNo * x);
            }
            x += xDiff;
        }

        private static void DrawSomeStuff()
        {
            using StringReader reader = new(DayInput);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                DoCycleCrt(0);

                string[] parts = line.Split(' ');
                if (parts[0] == "addx")
                {
                    DoCycleCrt(int.Parse(parts[1]));
                }
            }

            for (int i = 0; i < display.Length; i++)
            {
                Console.WriteLine(display[i]);
            }
        }

        private static void DoCycleCrt(int xDiff)
        {
            if (scanPoint.X >= xPos - 1 && scanPoint.X <= xPos + 1)
            {
                display[scanPoint.Y] += "#";
            }
            else
            {
                display[scanPoint.Y] += ".";
            }

            if (scanPoint.X == 39)
            {
                scanPoint.X = 0;
                scanPoint.Offset(0, 1);
            }
            else
            {
                scanPoint.Offset(1, 0);
            }

            xPos += xDiff;
        }

        private static string DayInput = "noop\r\nnoop\r\nnoop\r\naddx 3\r\naddx 20\r\nnoop\r\naddx -12\r\nnoop\r\naddx 4\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\naddx 2\r\naddx 5\r\naddx 16\r\naddx -14\r\naddx -25\r\naddx 30\r\naddx 1\r\nnoop\r\naddx 5\r\nnoop\r\naddx -38\r\nnoop\r\nnoop\r\nnoop\r\naddx 3\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx 5\r\naddx 5\r\naddx 2\r\naddx 13\r\naddx 6\r\naddx -16\r\naddx 2\r\naddx 5\r\naddx -15\r\naddx 16\r\naddx 7\r\nnoop\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx -39\r\naddx 4\r\naddx -2\r\naddx 2\r\naddx 7\r\nnoop\r\naddx -2\r\naddx 17\r\naddx -10\r\nnoop\r\nnoop\r\naddx 5\r\naddx -1\r\naddx 6\r\nnoop\r\naddx -2\r\naddx 5\r\naddx -8\r\naddx 12\r\naddx 3\r\naddx -2\r\naddx -19\r\naddx -16\r\naddx 2\r\naddx 5\r\nnoop\r\naddx 25\r\naddx 7\r\naddx -29\r\naddx 3\r\naddx 4\r\naddx -4\r\naddx 9\r\nnoop\r\naddx 2\r\naddx -20\r\naddx 23\r\naddx 1\r\nnoop\r\naddx 5\r\naddx -10\r\naddx 14\r\naddx 2\r\naddx -1\r\naddx -38\r\nnoop\r\naddx 20\r\naddx -15\r\nnoop\r\naddx 7\r\nnoop\r\naddx 26\r\naddx -25\r\naddx 2\r\naddx 7\r\nnoop\r\nnoop\r\naddx 2\r\naddx -5\r\naddx 6\r\naddx 5\r\naddx 2\r\naddx 8\r\naddx -3\r\nnoop\r\naddx 3\r\naddx -2\r\naddx -38\r\naddx 13\r\naddx -6\r\nnoop\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\naddx 7\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\nnoop\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop";
        //private static string DayInput = "addx 15\r\naddx -11\r\naddx 6\r\naddx -3\r\naddx 5\r\naddx -1\r\naddx -8\r\naddx 13\r\naddx 4\r\nnoop\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx -35\r\naddx 1\r\naddx 24\r\naddx -19\r\naddx 1\r\naddx 16\r\naddx -11\r\nnoop\r\nnoop\r\naddx 21\r\naddx -15\r\nnoop\r\nnoop\r\naddx -3\r\naddx 9\r\naddx 1\r\naddx -3\r\naddx 8\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx -36\r\nnoop\r\naddx 1\r\naddx 7\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\naddx 6\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx 7\r\naddx 1\r\nnoop\r\naddx -13\r\naddx 13\r\naddx 7\r\nnoop\r\naddx 1\r\naddx -33\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx 8\r\nnoop\r\naddx -1\r\naddx 2\r\naddx 1\r\nnoop\r\naddx 17\r\naddx -9\r\naddx 1\r\naddx 1\r\naddx -3\r\naddx 11\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx -13\r\naddx -19\r\naddx 1\r\naddx 3\r\naddx 26\r\naddx -30\r\naddx 12\r\naddx -1\r\naddx 3\r\naddx 1\r\nnoop\r\nnoop\r\nnoop\r\naddx -9\r\naddx 18\r\naddx 1\r\naddx 2\r\nnoop\r\nnoop\r\naddx 9\r\nnoop\r\nnoop\r\nnoop\r\naddx -1\r\naddx 2\r\naddx -37\r\naddx 1\r\naddx 3\r\nnoop\r\naddx 15\r\naddx -21\r\naddx 22\r\naddx -6\r\naddx 1\r\nnoop\r\naddx 2\r\naddx 1\r\nnoop\r\naddx -10\r\nnoop\r\nnoop\r\naddx 20\r\naddx 1\r\naddx 2\r\naddx 2\r\naddx -6\r\naddx -11\r\nnoop\r\nnoop\r\nnoop";
    }
}