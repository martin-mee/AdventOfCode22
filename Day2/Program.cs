namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StringReader reader = new (DayInput))
            {
                int total = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    total += GetScoreForChoice(parts[1]);
                    total += GetScoreForRound(parts[0], parts[1]);
                }
                Console.WriteLine("Total old way:" + total);
            }

            using (StringReader reader = new (DayInput))
            {
                int total = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    string choice = GetChoiceForResult(parts[0], parts[1]);
                    total += GetScoreForChoice(choice);
                    total += GetScoreForRound(parts[0], choice);
                }
                Console.WriteLine("Total new way:" + total);
            }
        }

        private static string GetChoiceForResult(string you, string result)
        {
            if (result == "X") //lose
            {
                if (you == "A")
                {
                    return "Z";
                }
                else if (you == "B")
                {
                    return "X";
                }
                else
                {
                    return "Y";
                }
            }
            else if (result == "Y") //draw
            {
                if (you == "A")
                {
                    return "X";
                }
                else if (you == "B")
                {
                    return "Y";
                }
                else
                {
                    return "Z";
                }
            }
            else //win
            {
                if (you == "A")
                {
                    return "Y";
                }
                else if (you == "B")
                {
                    return "Z";
                }
                else
                {
                    return "X";
                }
            }
        }

        private static int GetScoreForChoice(string choice)
        {
            switch (choice)
            {
                case "X": return 1;
                case "Y": return 2;
                case "Z": return 3;
                default: return 0;
            }
        }

        private static int GetScoreForRound(string you, string me)
        {
            if (you == "A")
            {
                if (me == "X")
                {
                    return 3;
                }
                else if (me == "Y")
                {
                    return 6;
                }
                else return 0;
            }
            else if (you == "B")
            {
                if (me == "X")
                {
                    return 0;
                }
                else if (me == "Y")
                {
                    return 3;
                }
                else return 6;
            }
            else
            {
                if (me == "X")
                {
                    return 6;
                }
                else if (me == "Y")
                {
                    return 0;
                }
                else return 3;
            }
        }

        private static string DayInput = "B Z\r\nA X\r\nB Z\r\nB Z\r\nC Z\r\nB Z\r\nA Z\r\nB X\r\nC Y\r\nC Y\r\nA X\r\nA X\r\nA Z\r\nB Z\r\nA X\r\nA Z\r\nB X\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nC Y\r\nB Z\r\nA X\r\nA Y\r\nB Y\r\nA X\r\nA Z\r\nB X\r\nB Y\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nA X\r\nC Y\r\nB Z\r\nB Z\r\nC X\r\nA Z\r\nB Z\r\nB Z\r\nC X\r\nC X\r\nB X\r\nB X\r\nA X\r\nB X\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nB Z\r\nB Y\r\nC X\r\nA X\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nA Z\r\nB Z\r\nA X\r\nB Z\r\nC Y\r\nB Y\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nC X\r\nA X\r\nB Y\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nA Z\r\nB Y\r\nA X\r\nA Z\r\nB Z\r\nA X\r\nB X\r\nB X\r\nB X\r\nB X\r\nA X\r\nA Z\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC X\r\nB X\r\nA Z\r\nC Y\r\nB Z\r\nC Z\r\nB X\r\nB Z\r\nB Z\r\nC Z\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nA Y\r\nA X\r\nC Z\r\nB X\r\nB X\r\nC X\r\nC X\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nA Z\r\nB Z\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nB X\r\nB Z\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nA Z\r\nA Z\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nC X\r\nB Z\r\nC Z\r\nA Y\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nA Y\r\nB Z\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nB Z\r\nA Y\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nA Y\r\nA X\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nC X\r\nB X\r\nA X\r\nB Z\r\nB X\r\nC Z\r\nA X\r\nA X\r\nA X\r\nC Y\r\nC Y\r\nB Z\r\nA Z\r\nC X\r\nB X\r\nC Y\r\nA Y\r\nA Z\r\nA Z\r\nA X\r\nA X\r\nC Y\r\nB Z\r\nA Z\r\nB Z\r\nB X\r\nC Z\r\nB X\r\nB X\r\nB Y\r\nA Z\r\nB Z\r\nC Y\r\nB X\r\nC X\r\nC X\r\nA X\r\nB Z\r\nB X\r\nA Y\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nA X\r\nB Z\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nB X\r\nB X\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nB Z\r\nA X\r\nB X\r\nC Z\r\nB X\r\nA Z\r\nA Z\r\nC Z\r\nA Y\r\nC Y\r\nB X\r\nB Z\r\nA X\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nB X\r\nC Y\r\nC X\r\nC Y\r\nB Z\r\nA Z\r\nC Y\r\nA Z\r\nB X\r\nB Z\r\nB Z\r\nA X\r\nA Y\r\nA X\r\nB Z\r\nB Z\r\nB Y\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nA Y\r\nC X\r\nB Z\r\nC Y\r\nA Y\r\nA X\r\nA Z\r\nC Y\r\nC Z\r\nA Y\r\nB X\r\nA X\r\nB X\r\nC Y\r\nC Z\r\nB Y\r\nB Z\r\nB Z\r\nC Y\r\nB Z\r\nC Z\r\nB Y\r\nA Z\r\nA Z\r\nB Z\r\nB X\r\nB X\r\nA Z\r\nC Y\r\nB X\r\nB Z\r\nA Y\r\nC Y\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nC X\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Z\r\nB X\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nC X\r\nA Y\r\nA Z\r\nA X\r\nB Z\r\nB Z\r\nC X\r\nC Y\r\nB X\r\nA X\r\nA Z\r\nB X\r\nB Z\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nA Y\r\nC X\r\nA X\r\nB X\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nA Z\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nB X\r\nC X\r\nC X\r\nA X\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nB X\r\nB X\r\nB Y\r\nB X\r\nA Z\r\nB X\r\nB X\r\nB X\r\nB Z\r\nB Y\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nB Y\r\nB X\r\nA Y\r\nC Z\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nB Y\r\nA Z\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nB X\r\nB X\r\nA X\r\nB Y\r\nA Z\r\nB X\r\nB Z\r\nA X\r\nC Z\r\nB Y\r\nA X\r\nA X\r\nA X\r\nA X\r\nB Y\r\nC Z\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nB Z\r\nA X\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nA X\r\nC Y\r\nA Y\r\nA Z\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nC Z\r\nC Y\r\nB Z\r\nB Y\r\nC Y\r\nC Z\r\nA X\r\nA X\r\nC X\r\nB X\r\nC X\r\nB X\r\nA Z\r\nB Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nA X\r\nC X\r\nB Z\r\nC X\r\nC Z\r\nB X\r\nB X\r\nC Y\r\nB X\r\nA Y\r\nB X\r\nB Z\r\nC X\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nB X\r\nA X\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nC Y\r\nB Z\r\nB Y\r\nB Z\r\nA X\r\nB Y\r\nB Z\r\nC X\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nC X\r\nB Z\r\nC Y\r\nC X\r\nB Y\r\nB X\r\nB X\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nA X\r\nC Y\r\nA Y\r\nB X\r\nC X\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nB X\r\nA X\r\nB Z\r\nA Y\r\nB Z\r\nB Z\r\nB X\r\nB Z\r\nA Z\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nB X\r\nA X\r\nC Z\r\nB Z\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nC X\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nB Z\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nB X\r\nA Y\r\nA X\r\nC Y\r\nA Z\r\nC X\r\nB Y\r\nB Y\r\nB Y\r\nA Z\r\nC Y\r\nB Z\r\nB Z\r\nA Y\r\nB Z\r\nB Z\r\nC Z\r\nC X\r\nC X\r\nB X\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nA X\r\nA Z\r\nC X\r\nB X\r\nA X\r\nB Z\r\nA X\r\nB X\r\nA Y\r\nB X\r\nB Z\r\nB X\r\nB X\r\nC Z\r\nA Z\r\nB Z\r\nC Z\r\nB X\r\nB X\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nA Y\r\nA X\r\nA Z\r\nC Z\r\nA X\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nB X\r\nB X\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nA Z\r\nC Y\r\nA X\r\nC Y\r\nB Z\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nA Z\r\nA X\r\nB X\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nB X\r\nB Z\r\nB Z\r\nA Z\r\nB Z\r\nC Y\r\nB Z\r\nA X\r\nC X\r\nB Z\r\nB X\r\nA X\r\nC Y\r\nC Y\r\nA Z\r\nC Y\r\nC Z\r\nA Z\r\nA Z\r\nB X\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nB Y\r\nC Y\r\nB Y\r\nA Z\r\nA Z\r\nB X\r\nA Z\r\nC X\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nC X\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nA X\r\nB Z\r\nB Y\r\nA Z\r\nA X\r\nB X\r\nC Y\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nB Y\r\nB X\r\nA Z\r\nB Y\r\nC Y\r\nB X\r\nC Y\r\nA X\r\nB Y\r\nB X\r\nC Y\r\nC X\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nA X\r\nB X\r\nA X\r\nB X\r\nB X\r\nB Y\r\nC Y\r\nA X\r\nC X\r\nC Y\r\nC X\r\nB Y\r\nA Z\r\nA X\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nB Y\r\nB Y\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nA X\r\nC Y\r\nB Z\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nA X\r\nC Y\r\nA X\r\nB X\r\nC Y\r\nB X\r\nC Z\r\nC Y\r\nB Z\r\nA Y\r\nA Y\r\nC Y\r\nB Z\r\nA Z\r\nB Z\r\nC Y\r\nA Z\r\nB X\r\nA X\r\nB X\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nA Y\r\nB X\r\nB Z\r\nA Z\r\nC Y\r\nA Z\r\nC X\r\nA Z\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nA X\r\nB Y\r\nC Z\r\nB Z\r\nA Z\r\nC Y\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nB Y\r\nB Z\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nB X\r\nC Y\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nA Y\r\nB X\r\nA X\r\nB Y\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nA Z\r\nB Z\r\nC X\r\nB Z\r\nB Y\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nC Y\r\nA Z\r\nA X\r\nC X\r\nB Z\r\nB Y\r\nA Y\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nC Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Y\r\nA X\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nA X\r\nB Z\r\nB Z\r\nC Y\r\nB Y\r\nB Y\r\nB Z\r\nA X\r\nB Z\r\nA X\r\nB Y\r\nC X\r\nA Z\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nB Y\r\nB X\r\nC Y\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nA X\r\nA Z\r\nB Y\r\nC Y\r\nB X\r\nB Z\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nB Y\r\nC X\r\nB X\r\nA X\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nA Z\r\nA Z\r\nB X\r\nC X\r\nB X\r\nB Y\r\nC Z\r\nC Y\r\nB Y\r\nA X\r\nA Z\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nA Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nC X\r\nC Y\r\nC Y\r\nA Z\r\nB Z\r\nC Y\r\nB Z\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nA X\r\nB X\r\nA X\r\nA Z\r\nA X\r\nB Y\r\nB X\r\nA X\r\nB Z\r\nB Z\r\nB X\r\nA Z\r\nB X\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nA X\r\nA X\r\nB Z\r\nC X\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB X\r\nC Z\r\nC Y\r\nB X\r\nA Y\r\nA Z\r\nC X\r\nB Y\r\nB Z\r\nC Y\r\nB X\r\nA Z\r\nC Z\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nA Z\r\nC Y\r\nB X\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nB X\r\nB X\r\nC Y\r\nB Y\r\nC Y\r\nB Z\r\nB X\r\nA Y\r\nA X\r\nB Z\r\nA Z\r\nB Z\r\nB Z\r\nA Y\r\nC Y\r\nA X\r\nB X\r\nB X\r\nA X\r\nC Y\r\nB Z\r\nB Y\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC Z\r\nB Y\r\nB Y\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nB X\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nC Y\r\nB Z\r\nC Z\r\nA Y\r\nA Z\r\nA Z\r\nC Y\r\nC Y\r\nA Z\r\nB X\r\nB X\r\nA X\r\nB Z\r\nB Z\r\nA X\r\nA Z\r\nC Y\r\nB X\r\nA Z\r\nB X\r\nC Y\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nC Z\r\nC Z\r\nB X\r\nA X\r\nA Y\r\nB Y\r\nB X\r\nB X\r\nA Y\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nA X\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nB Y\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nB Z\r\nB X\r\nA X\r\nB Z\r\nC Y\r\nB X\r\nB Z\r\nC Z\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA Z\r\nB X\r\nB Y\r\nC Y\r\nA X\r\nB Z\r\nC Y\r\nA X\r\nB X\r\nC Y\r\nB X\r\nA Y\r\nC Z\r\nC X\r\nC Z\r\nB Z\r\nC X\r\nA Z\r\nC X\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nC Y\r\nB X\r\nA Y\r\nC Y\r\nB Z\r\nA Y\r\nA Z\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Y\r\nA X\r\nC Y\r\nC X\r\nA Y\r\nB Z\r\nA X\r\nA Z\r\nC Y\r\nA Z\r\nB Z\r\nB Z\r\nC X\r\nB X\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC X\r\nC Z\r\nC Y\r\nC X\r\nC X\r\nC Y\r\nB X\r\nC X\r\nC Z\r\nC Y\r\nB Y\r\nC X\r\nA X\r\nC Y\r\nA X\r\nC Z\r\nC X\r\nC Y\r\nB X\r\nA Z\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nC Z\r\nB X\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nA Y\r\nB X\r\nC X\r\nB X\r\nB Y\r\nB Z\r\nC X\r\nB Z\r\nB Z\r\nA X\r\nA X\r\nB Z\r\nB Z\r\nA Y\r\nA Z\r\nB Y\r\nA X\r\nB X\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nB X\r\nB Z\r\nC Z\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nA Z\r\nB X\r\nA Y\r\nA Y\r\nC Y\r\nB Z\r\nB X\r\nA X\r\nB Y\r\nA Y\r\nB Z\r\nB Z\r\nB Z\r\nB Y\r\nC Z\r\nA X\r\nC X\r\nB Y\r\nA Y\r\nB Z\r\nC Y\r\nA X\r\nB Z\r\nC Y\r\nA X\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nC Y\r\nA Z\r\nB X\r\nC Y\r\nB Z\r\nA Y\r\nB X\r\nC X\r\nB X\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nC Y\r\nB Z\r\nC Y\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nA Y\r\nA X\r\nB Z\r\nB X\r\nB X\r\nA Z\r\nA X\r\nC Z\r\nA X\r\nA X\r\nC Z\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nA Z\r\nB X\r\nC Y\r\nB X\r\nB Z\r\nC X\r\nC Y\r\nC Y\r\nA Z\r\nB X\r\nB X\r\nC Z\r\nC Y\r\nB X\r\nA X\r\nC X\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nA Z\r\nB X\r\nA Y\r\nB Z\r\nB X\r\nC Y\r\nB Y\r\nC Y\r\nA Z\r\nA X\r\nC Y\r\nA Z\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nC X\r\nB Y\r\nA Z\r\nB Z\r\nC Y\r\nA X\r\nB Z\r\nC X\r\nC Y\r\nB X\r\nA Y\r\nB X\r\nB Z\r\nC Y\r\nB X\r\nA Y\r\nB Z\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nC Y\r\nA Y\r\nB Z\r\nB X\r\nA Z\r\nC Y\r\nB Y\r\nA Y\r\nA Z\r\nB Y\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nC X\r\nC X\r\nB Y\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nA Y\r\nA X\r\nA X\r\nC Y\r\nA Y\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nA X\r\nB X\r\nC Y\r\nA Z\r\nB X\r\nA Y\r\nA X\r\nA X\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nA Z\r\nC Y\r\nB X\r\nB Z\r\nC X\r\nC Y\r\nC Y\r\nC Z\r\nB Z\r\nB X\r\nA X\r\nB Z\r\nC Z\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nA Z\r\nC Z\r\nB Z\r\nA X\r\nB Y\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nC Y\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nC Y\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nC Z\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nC Y\r\nA X\r\nC Y\r\nA Z\r\nB X\r\nC X\r\nB X\r\nC X\r\nA Z\r\nC Y\r\nA X\r\nA X\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nA Y\r\nB Z\r\nC X\r\nB Z\r\nA Y\r\nC Y\r\nB X\r\nA Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nA Y\r\nA Z\r\nB Z\r\nC Y\r\nB Y\r\nC X\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nA X\r\nC Z\r\nC Y\r\nA X\r\nB X\r\nC Y\r\nB X\r\nA X\r\nC Z\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nC Y\r\nB X\r\nC Y\r\nA Y\r\nB X\r\nB Z\r\nB Z\r\nC Y\r\nA X\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB Z\r\nB Z\r\nC Y\r\nC X\r\nB Z\r\nB Z\r\nA Z\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nB X\r\nB X\r\nA X\r\nA Z\r\nB Z\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nB X\r\nA Y\r\nC Y\r\nB Z\r\nC Z\r\nB Y\r\nB Z\r\nC X\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nA Z\r\nA Y\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nB Z\r\nC Y\r\nC X\r\nC X\r\nB Z\r\nC Y\r\nA X\r\nB Y\r\nB X\r\nB X\r\nB X\r\nA Y\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nC X\r\nB Z\r\nA X\r\nA Y\r\nB Z\r\nC Z\r\nB Z\r\nA X\r\nB Z\r\nA X\r\nB Z\r\nA Z\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nA Z\r\nB X\r\nC Y\r\nB Y\r\nB X\r\nA X\r\nB Z\r\nA Z\r\nB Z\r\nB Z\r\nB Y\r\nC X\r\nB X\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nB X\r\nC Y\r\nC Z\r\nA Y\r\nB Y\r\nA X\r\nB Z\r\nB Y\r\nA Z\r\nC X\r\nC Y\r\nB Z\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nC X\r\nA Y\r\nB X\r\nB X\r\nB Z\r\nC Y\r\nB Y\r\nA X\r\nB Z\r\nB X\r\nA X\r\nA X\r\nB X\r\nA X\r\nB Z\r\nB X\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC X\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nA X\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nB Z\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nA X\r\nB Z\r\nA X\r\nA X\r\nB X\r\nB Y\r\nC Y\r\nC Y\r\nA X\r\nB Z\r\nC Y\r\nC X\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nA Y\r\nB X\r\nC Y\r\nA X\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nA X\r\nB Y\r\nB Z\r\nB Y\r\nA Y\r\nB Z\r\nB Y\r\nB Z\r\nA Y\r\nC Y\r\nA Y\r\nA X\r\nA Z\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nB X\r\nA Z\r\nB X\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nA Z\r\nA Y\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nA Y\r\nA Y\r\nB X\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nA Z\r\nB X\r\nB X\r\nA Z\r\nB X\r\nB Z\r\nB X\r\nB X\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nA Z\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nB Y\r\nA X\r\nA Z\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nC X\r\nA Z\r\nC X\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nC X\r\nA X\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nA Y\r\nB X\r\nB Z\r\nC X\r\nB X\r\nB Y\r\nB Z\r\nB Z\r\nA Z\r\nC X\r\nB X\r\nB X\r\nB Y\r\nB Z\r\nC Y\r\nC Y\r\nC Y\r\nA Z\r\nB Z\r\nA Z\r\nB Z\r\nB X\r\nC Y\r\nB X\r\nB X\r\nA Y\r\nC Y\r\nA X\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nB Y\r\nC Y\r\nA Z\r\nB X\r\nC Y\r\nB Z\r\nC X\r\nB X\r\nA X\r\nB Z\r\nB X\r\nA Y\r\nB Z\r\nB Z\r\nC X\r\nB X\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nA Y\r\nB X\r\nC X\r\nC Y\r\nB Y\r\nB Z\r\nB X\r\nC X\r\nC Y\r\nB X\r\nB Z\r\nB Z\r\nB X\r\nC Z\r\nB Z\r\nB X\r\nC X\r\nC X\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nC Y\r\nA Z\r\nA Z\r\nB Z\r\nB X\r\nA Z\r\nB X\r\nB Z\r\nB Y\r\nB Z\r\nC Y\r\nB Z\r\nA Z\r\nC X\r\nB Z\r\nB Z\r\nC Y\r\nA Z\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nA Z\r\nA Z\r\nB Z\r\nC X\r\nA X\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nC X\r\nA Z\r\nB X\r\nB Z\r\nB X\r\nB Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nB Z\r\nB X\r\nB Z\r\nB Y\r\nA Z\r\nB Z\r\nC Y\r\nB Z\r\nA X\r\nA Z\r\nA Y\r\nB Y\r\nB Z\r\nB Z\r\nA X\r\nB Y\r\nA Z\r\nB Z\r\nB Z\r\nA Y\r\nC Y\r\nB X\r\nB Z\r\nA X\r\nB Z\r\nB Z\r\nA X\r\nB Z\r\nB Z\r\nB X\r\nA Z\r\nB X\r\nB Z\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nB Z\r\nA X\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nB X\r\nA Z\r\nC Y\r\nB Y\r\nB Z\r\nB Z\r\nB Z\r\nB X\r\nC Y\r\nC X\r\nA X\r\nB Z\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nB X\r\nB Z\r\nC Z\r\nC Y\r\nC Y\r\nA Y\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nC Z\r\nB X\r\nC X\r\nC Y\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA X\r\nB Z\r\nB Y\r\nA Z\r\nB Z\r\nC X\r\nB Y\r\nB X\r\nB Z\r\nB X\r\nA Z\r\nA Z\r\nC Y\r\nC X\r\nC Y\r\nA Z\r\nB Y\r\nA Y\r\nC Y\r\nB Z\r\nA Z\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nC Z\r\nC Y\r\nC X\r\nB Z\r\nB X\r\nA X\r\nA Y\r\nB Z\r\nB X\r\nA Y\r\nB X\r\nB X\r\nC Y\r\nB X\r\nB Z\r\nA Z\r\nC Y\r\nC Y\r\nA Y\r\nB Z\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nB Z\r\nA X\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nA X\r\nC X\r\nB X\r\nC X\r\nA Z\r\nC Y\r\nB X\r\nB Z\r\nB Y\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nB X\r\nB X\r\nA Z\r\nB X\r\nC Y\r\nB Z\r\nA Z\r\nC Y\r\nC X\r\nA Z\r\nB Z\r\nA Z\r\nC Y\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nC Z\r\nB X\r\nB Z\r\nB Y\r\nB Y\r\nB X\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nC X\r\nB X\r\nC Y\r\nB Z\r\nC X\r\nC Y\r\nC X\r\nC X\r\nB Y\r\nB Z\r\nA X\r\nC X\r\nB Z\r\nA Z\r\nA X\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nB X\r\nB X\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nB Y\r\nB X\r\nB Y\r\nA X\r\nB Z\r\nA X\r\nC X\r\nC X\r\nB Z\r\nC Y\r\nA Y\r\nB X\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nB Z\r\nB Z\r\nC Y\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nB X\r\nB X\r\nB Z\r\nB Y\r\nC Z\r\nC X\r\nC Y\r\nB X\r\nB X\r\nA X\r\nB X\r\nC Y\r\nA Z\r\nB Z\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nB Z\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nC Y\r\nA X\r\nB X\r\nB Z\r\nB Y\r\nB Z\r\nC Y\r\nB Y\r\nA Y\r\nA Z\r\nB Z\r\nB Y\r\nC Z\r\nB Z\r\nC Y\r\nB Z\r\nC Y\r\nB Z\r\nB Z\r\nC Y\r\nC Z\r\nA X\r\nC Y\r\nC Y\r\nA Z\r\nA X\r\nC Y\r\nB Z\r\nC X\r\nC Y\r\nB Z\r\nB Z\r\nB Z\r\nC Z\r\nB Y\r\nB Z\r\nB Z\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nB X\r\nB X\r\nB Z\r\nB Y\r\nA Z\r\nA X\r\nA Y\r\nC Y\r\nB Z\r\nC Z\r\nA Y\r\nB X\r\nB Y\r\nC Y\r\nC X\r\nC Y\r\nB X\r\nB X\r\nC X\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nC Z\r\nB Z\r\nB X\r\nA X\r\nC X\r\nC Y\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nB Z\r\nC Y\r\nA X\r\nC X\r\nB Y\r\nB X\r\nA X\r\nA Y\r\nB X\r\nC Y\r\nB X\r\nC Z\r\nC X\r\nB X\r\nA Z\r\nB Z\r\nB X\r\nB Z\r\nA Y\r\nC X\r\nA Z\r\nB Y\r\nB Z\r\nC X\r\nC Z\r\nB X\r\nB Z\r\nB X\r\nB Z\r\nB Z\r\nC X\r\nB X\r\nB X\r\nA Z\r\nC Y\r\nB X\r\nC Y\r\nB Z\r\nB Z\r\nC X\r\nC Y\r\nB Z\r\nA X\r\nB Z\r\nC Y\r\nB X\r\nA X\r\nC Y\r\nA X\r\nA X\r\nC Y";
    }
}