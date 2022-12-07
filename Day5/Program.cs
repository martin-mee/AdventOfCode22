namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StringReader reader = new(DayInput))
            {
                bool instructions = false;
                string line;
                List<char>[] stacks = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        instructions = true;
                        continue;
                    }

                    if (stacks == null)
                    {
                        int numCols = (int)Math.Ceiling((double)line.Length / 4);
                        stacks = new List<char>[numCols];
                        for (int i = 0; i < stacks.Length; i++)
                        {
                            stacks[i] = new List<char>();
                        }
                    }

                    if (!instructions)
                    {
                        char[] chars = line.ToCharArray();
                        for (int i = 0; i < chars.Length; i+=4)
                        {
                            int colNum = (int)Math.Floor((double)i / 4);
                            if (!char.IsWhiteSpace(chars[i + 1]))
                            {
                                stacks[colNum].Insert(0, chars[i + 1]);
                            }
                        }
                    }
                    else
                    {
                        string[] parts =  line.Split(' ');
                        int numToMove = int.Parse(parts[1]);
                        int colFrom = int.Parse(parts[3]) - 1;
                        int colTo = int.Parse(parts[5]) - 1;

                        for (int i = 0; i < numToMove; i++)
                        {
                            int crateIndex = stacks[colFrom].Count - 1;
                            char crate = stacks[colFrom].ElementAt(crateIndex);
                            stacks[colFrom].RemoveAt(crateIndex);
                            stacks[colTo].Add(crate);
                        }
                    }
                }

                string topCrates = "";
                for (int i = 0; i < stacks.Length; i++)
                {
                    topCrates += stacks[i].LastOrDefault().ToString();
                }
                Console.WriteLine(topCrates);
            }

            using (StringReader reader = new(DayInput))
            {
                bool instructions = false;
                string line;
                List<char>[] stacks = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        instructions = true;
                        continue;
                    }

                    if (stacks == null)
                    {
                        int numCols = (int)Math.Ceiling((double)line.Length / 4);
                        stacks = new List<char>[numCols];
                        for (int i = 0; i < stacks.Length; i++)
                        {
                            stacks[i] = new List<char>();
                        }
                    }

                    if (!instructions)
                    {
                        char[] chars = line.ToCharArray();
                        for (int i = 0; i < chars.Length; i += 4)
                        {
                            int colNum = (int)Math.Floor((double)i / 4);
                            if (!char.IsWhiteSpace(chars[i + 1]))
                            {
                                stacks[colNum].Insert(0, chars[i + 1]);
                            }
                        }
                    }
                    else
                    {
                        string[] parts = line.Split(' ');
                        int numToMove = int.Parse(parts[1]);
                        int colFrom = int.Parse(parts[3]) - 1;
                        int colTo = int.Parse(parts[5]) - 1;

                        IEnumerable<char> crates = stacks[colFrom].TakeLast(numToMove);
                        stacks[colTo].AddRange(crates);
                        stacks[colFrom].RemoveRange(stacks[colFrom].Count - numToMove, numToMove);
                    }
                }

                string topCrates = "";
                for (int i = 0; i < stacks.Length; i++)
                {
                    topCrates += stacks[i].LastOrDefault().ToString();
                }
                Console.WriteLine(topCrates);
            }
        }

        private static string DayInput = "                    [L]     [H] [W]\r\n                [J] [Z] [J] [Q] [Q]\r\n[S]             [M] [C] [T] [F] [B]\r\n[P]     [H]     [B] [D] [G] [B] [P]\r\n[W]     [L] [D] [D] [J] [W] [T] [C]\r\n[N] [T] [R] [T] [T] [T] [M] [M] [G]\r\n[J] [S] [Q] [S] [Z] [W] [P] [G] [D]\r\n[Z] [G] [V] [V] [Q] [M] [L] [N] [R]\r\n 1   2   3   4   5   6   7   8   9 \r\n\r\nmove 1 from 3 to 5\r\nmove 2 from 2 to 8\r\nmove 4 from 1 to 3\r\nmove 2 from 1 to 4\r\nmove 1 from 7 to 1\r\nmove 2 from 9 to 7\r\nmove 4 from 5 to 9\r\nmove 7 from 8 to 9\r\nmove 2 from 5 to 2\r\nmove 1 from 2 to 9\r\nmove 1 from 1 to 8\r\nmove 1 from 2 to 7\r\nmove 3 from 8 to 2\r\nmove 6 from 9 to 7\r\nmove 5 from 4 to 1\r\nmove 7 from 9 to 5\r\nmove 1 from 4 to 5\r\nmove 4 from 1 to 7\r\nmove 1 from 8 to 1\r\nmove 4 from 7 to 9\r\nmove 1 from 5 to 8\r\nmove 9 from 9 to 3\r\nmove 1 from 8 to 9\r\nmove 1 from 1 to 5\r\nmove 4 from 3 to 2\r\nmove 10 from 5 to 3\r\nmove 8 from 2 to 8\r\nmove 7 from 8 to 3\r\nmove 9 from 7 to 5\r\nmove 1 from 9 to 3\r\nmove 3 from 6 to 4\r\nmove 3 from 7 to 6\r\nmove 1 from 8 to 7\r\nmove 1 from 1 to 8\r\nmove 1 from 4 to 7\r\nmove 5 from 7 to 6\r\nmove 14 from 3 to 7\r\nmove 16 from 3 to 9\r\nmove 1 from 8 to 4\r\nmove 2 from 4 to 9\r\nmove 1 from 3 to 7\r\nmove 1 from 6 to 8\r\nmove 15 from 7 to 2\r\nmove 10 from 9 to 7\r\nmove 7 from 2 to 4\r\nmove 1 from 2 to 7\r\nmove 11 from 6 to 7\r\nmove 5 from 5 to 9\r\nmove 15 from 7 to 8\r\nmove 1 from 7 to 2\r\nmove 2 from 9 to 7\r\nmove 4 from 5 to 1\r\nmove 5 from 4 to 9\r\nmove 6 from 2 to 4\r\nmove 2 from 2 to 5\r\nmove 2 from 1 to 4\r\nmove 1 from 1 to 5\r\nmove 3 from 5 to 6\r\nmove 8 from 7 to 9\r\nmove 9 from 4 to 9\r\nmove 1 from 4 to 8\r\nmove 11 from 9 to 7\r\nmove 4 from 6 to 1\r\nmove 17 from 8 to 7\r\nmove 26 from 7 to 1\r\nmove 1 from 4 to 8\r\nmove 24 from 1 to 7\r\nmove 22 from 9 to 3\r\nmove 1 from 8 to 2\r\nmove 6 from 3 to 4\r\nmove 2 from 1 to 2\r\nmove 1 from 7 to 9\r\nmove 16 from 7 to 3\r\nmove 1 from 9 to 5\r\nmove 6 from 4 to 1\r\nmove 1 from 2 to 7\r\nmove 6 from 3 to 2\r\nmove 1 from 5 to 4\r\nmove 6 from 3 to 5\r\nmove 1 from 4 to 1\r\nmove 3 from 1 to 4\r\nmove 4 from 5 to 4\r\nmove 7 from 1 to 7\r\nmove 6 from 4 to 3\r\nmove 1 from 1 to 6\r\nmove 1 from 2 to 5\r\nmove 1 from 1 to 7\r\nmove 15 from 3 to 1\r\nmove 2 from 2 to 7\r\nmove 3 from 5 to 8\r\nmove 9 from 7 to 5\r\nmove 8 from 5 to 7\r\nmove 3 from 8 to 5\r\nmove 1 from 6 to 9\r\nmove 5 from 7 to 8\r\nmove 3 from 2 to 4\r\nmove 2 from 2 to 5\r\nmove 4 from 3 to 7\r\nmove 5 from 8 to 3\r\nmove 1 from 5 to 8\r\nmove 5 from 3 to 1\r\nmove 2 from 5 to 7\r\nmove 1 from 9 to 8\r\nmove 1 from 5 to 8\r\nmove 19 from 1 to 4\r\nmove 19 from 7 to 1\r\nmove 7 from 1 to 4\r\nmove 1 from 7 to 4\r\nmove 3 from 3 to 5\r\nmove 22 from 4 to 5\r\nmove 3 from 8 to 3\r\nmove 7 from 1 to 8\r\nmove 3 from 3 to 5\r\nmove 3 from 3 to 6\r\nmove 3 from 6 to 9\r\nmove 3 from 9 to 1\r\nmove 1 from 3 to 4\r\nmove 2 from 8 to 9\r\nmove 25 from 5 to 6\r\nmove 4 from 1 to 5\r\nmove 5 from 5 to 4\r\nmove 2 from 8 to 2\r\nmove 1 from 9 to 2\r\nmove 3 from 5 to 7\r\nmove 12 from 6 to 8\r\nmove 1 from 7 to 3\r\nmove 7 from 8 to 1\r\nmove 1 from 5 to 7\r\nmove 1 from 3 to 8\r\nmove 2 from 7 to 4\r\nmove 6 from 8 to 5\r\nmove 10 from 6 to 3\r\nmove 2 from 6 to 2\r\nmove 1 from 6 to 3\r\nmove 17 from 4 to 6\r\nmove 3 from 3 to 9\r\nmove 3 from 8 to 4\r\nmove 1 from 7 to 5\r\nmove 1 from 3 to 8\r\nmove 1 from 2 to 5\r\nmove 10 from 1 to 7\r\nmove 3 from 2 to 7\r\nmove 2 from 1 to 8\r\nmove 15 from 6 to 3\r\nmove 7 from 5 to 9\r\nmove 9 from 9 to 5\r\nmove 1 from 9 to 3\r\nmove 2 from 3 to 5\r\nmove 3 from 8 to 6\r\nmove 1 from 9 to 3\r\nmove 11 from 5 to 8\r\nmove 9 from 3 to 8\r\nmove 1 from 5 to 6\r\nmove 9 from 8 to 5\r\nmove 10 from 7 to 5\r\nmove 5 from 5 to 3\r\nmove 4 from 6 to 8\r\nmove 2 from 6 to 8\r\nmove 2 from 5 to 6\r\nmove 1 from 2 to 1\r\nmove 9 from 5 to 3\r\nmove 2 from 7 to 5\r\nmove 3 from 5 to 4\r\nmove 1 from 4 to 1\r\nmove 2 from 4 to 3\r\nmove 1 from 7 to 1\r\nmove 2 from 1 to 7\r\nmove 3 from 4 to 5\r\nmove 2 from 7 to 3\r\nmove 14 from 3 to 9\r\nmove 13 from 3 to 1\r\nmove 8 from 1 to 4\r\nmove 6 from 1 to 2\r\nmove 11 from 8 to 6\r\nmove 4 from 3 to 9\r\nmove 2 from 9 to 2\r\nmove 1 from 5 to 2\r\nmove 6 from 4 to 9\r\nmove 6 from 8 to 9\r\nmove 6 from 9 to 4\r\nmove 2 from 4 to 7\r\nmove 4 from 4 to 6\r\nmove 4 from 2 to 9\r\nmove 2 from 7 to 9\r\nmove 2 from 2 to 1\r\nmove 3 from 5 to 3\r\nmove 2 from 1 to 7\r\nmove 1 from 5 to 2\r\nmove 7 from 9 to 7\r\nmove 2 from 2 to 8\r\nmove 10 from 6 to 5\r\nmove 5 from 5 to 6\r\nmove 9 from 7 to 8\r\nmove 3 from 3 to 9\r\nmove 4 from 5 to 1\r\nmove 10 from 9 to 3\r\nmove 7 from 6 to 2\r\nmove 5 from 3 to 9\r\nmove 3 from 1 to 7\r\nmove 1 from 4 to 7\r\nmove 1 from 4 to 9\r\nmove 1 from 3 to 7\r\nmove 1 from 2 to 1\r\nmove 1 from 5 to 1\r\nmove 1 from 1 to 7\r\nmove 3 from 6 to 3\r\nmove 3 from 3 to 4\r\nmove 6 from 7 to 4\r\nmove 3 from 9 to 8\r\nmove 9 from 8 to 1\r\nmove 3 from 8 to 1\r\nmove 13 from 9 to 5\r\nmove 2 from 2 to 8\r\nmove 4 from 8 to 3\r\nmove 11 from 1 to 2\r\nmove 14 from 2 to 6\r\nmove 6 from 3 to 8\r\nmove 4 from 9 to 7\r\nmove 10 from 5 to 3\r\nmove 2 from 7 to 3\r\nmove 1 from 1 to 8\r\nmove 1 from 1 to 7\r\nmove 1 from 7 to 8\r\nmove 1 from 1 to 4\r\nmove 8 from 4 to 2\r\nmove 2 from 5 to 1\r\nmove 1 from 1 to 9\r\nmove 1 from 7 to 3\r\nmove 1 from 9 to 5\r\nmove 1 from 4 to 2\r\nmove 1 from 4 to 6\r\nmove 1 from 7 to 3\r\nmove 11 from 6 to 9\r\nmove 4 from 2 to 5\r\nmove 4 from 2 to 5\r\nmove 10 from 5 to 6\r\nmove 9 from 9 to 5\r\nmove 1 from 9 to 2\r\nmove 2 from 8 to 4\r\nmove 1 from 9 to 6\r\nmove 5 from 2 to 1\r\nmove 5 from 8 to 6\r\nmove 4 from 1 to 9\r\nmove 1 from 8 to 1\r\nmove 3 from 9 to 4\r\nmove 5 from 5 to 1\r\nmove 1 from 9 to 7\r\nmove 11 from 6 to 3\r\nmove 4 from 4 to 9\r\nmove 9 from 6 to 5\r\nmove 2 from 6 to 5\r\nmove 3 from 9 to 1\r\nmove 1 from 4 to 8\r\nmove 4 from 1 to 3\r\nmove 3 from 5 to 4\r\nmove 2 from 4 to 9\r\nmove 2 from 9 to 4\r\nmove 1 from 9 to 8\r\nmove 6 from 5 to 4\r\nmove 1 from 7 to 8\r\nmove 3 from 5 to 2\r\nmove 3 from 8 to 5\r\nmove 1 from 2 to 1\r\nmove 24 from 3 to 9\r\nmove 2 from 2 to 1\r\nmove 10 from 1 to 7\r\nmove 18 from 9 to 8\r\nmove 5 from 3 to 7\r\nmove 5 from 9 to 5\r\nmove 12 from 7 to 2\r\nmove 1 from 7 to 6\r\nmove 8 from 4 to 7\r\nmove 1 from 4 to 5\r\nmove 12 from 5 to 9\r\nmove 1 from 6 to 9\r\nmove 3 from 2 to 8\r\nmove 5 from 7 to 3\r\nmove 21 from 8 to 7\r\nmove 3 from 3 to 8\r\nmove 11 from 9 to 5\r\nmove 10 from 5 to 6\r\nmove 3 from 7 to 2\r\nmove 3 from 6 to 4\r\nmove 2 from 3 to 1\r\nmove 2 from 3 to 5\r\nmove 1 from 1 to 7\r\nmove 1 from 1 to 4\r\nmove 3 from 4 to 1\r\nmove 1 from 9 to 1\r\nmove 1 from 4 to 3\r\nmove 3 from 5 to 8\r\nmove 1 from 9 to 6\r\nmove 4 from 2 to 3\r\nmove 6 from 8 to 6\r\nmove 1 from 9 to 3\r\nmove 7 from 2 to 4\r\nmove 5 from 4 to 5\r\nmove 1 from 2 to 6\r\nmove 3 from 1 to 9\r\nmove 3 from 9 to 4\r\nmove 1 from 1 to 9\r\nmove 2 from 5 to 3\r\nmove 3 from 5 to 2\r\nmove 4 from 7 to 2\r\nmove 2 from 4 to 3\r\nmove 2 from 2 to 3\r\nmove 2 from 4 to 8\r\nmove 5 from 2 to 3\r\nmove 6 from 6 to 4\r\nmove 8 from 7 to 3\r\nmove 4 from 4 to 5\r\nmove 1 from 3 to 1\r\nmove 2 from 8 to 6\r\nmove 7 from 7 to 5\r\nmove 1 from 9 to 1\r\nmove 14 from 3 to 6\r\nmove 4 from 7 to 1\r\nmove 6 from 5 to 3\r\nmove 4 from 1 to 2\r\nmove 9 from 3 to 5\r\nmove 1 from 7 to 2\r\nmove 2 from 3 to 7\r\nmove 1 from 4 to 8\r\nmove 1 from 4 to 9\r\nmove 3 from 3 to 6\r\nmove 9 from 5 to 2\r\nmove 1 from 8 to 9\r\nmove 1 from 1 to 7\r\nmove 1 from 9 to 3\r\nmove 1 from 4 to 8\r\nmove 1 from 9 to 4\r\nmove 3 from 5 to 1\r\nmove 2 from 1 to 9\r\nmove 1 from 4 to 9\r\nmove 15 from 6 to 9\r\nmove 3 from 3 to 5\r\nmove 2 from 1 to 3\r\nmove 2 from 7 to 4\r\nmove 5 from 6 to 5\r\nmove 6 from 2 to 9\r\nmove 1 from 7 to 2\r\nmove 2 from 4 to 6\r\nmove 2 from 3 to 1\r\nmove 1 from 1 to 6\r\nmove 1 from 8 to 3\r\nmove 1 from 3 to 9\r\nmove 3 from 5 to 1\r\nmove 3 from 6 to 2\r\nmove 6 from 5 to 3\r\nmove 6 from 6 to 8\r\nmove 4 from 1 to 6\r\nmove 12 from 9 to 7\r\nmove 4 from 6 to 8\r\nmove 1 from 5 to 1\r\nmove 2 from 8 to 2\r\nmove 2 from 2 to 1\r\nmove 5 from 3 to 6\r\nmove 3 from 1 to 6\r\nmove 5 from 8 to 6\r\nmove 1 from 3 to 6\r\nmove 5 from 2 to 7\r\nmove 8 from 9 to 4\r\nmove 15 from 7 to 8\r\nmove 5 from 6 to 3\r\nmove 1 from 3 to 8\r\nmove 15 from 8 to 3\r\nmove 7 from 2 to 9\r\nmove 1 from 7 to 4\r\nmove 10 from 9 to 5\r\nmove 4 from 6 to 4\r\nmove 3 from 8 to 6\r\nmove 1 from 8 to 6\r\nmove 1 from 7 to 3\r\nmove 10 from 6 to 9\r\nmove 7 from 3 to 2\r\nmove 10 from 9 to 7\r\nmove 8 from 5 to 7\r\nmove 8 from 3 to 7\r\nmove 1 from 5 to 9\r\nmove 1 from 6 to 8\r\nmove 1 from 5 to 4\r\nmove 1 from 8 to 6\r\nmove 5 from 3 to 8\r\nmove 9 from 4 to 2\r\nmove 1 from 9 to 2\r\nmove 4 from 2 to 3\r\nmove 2 from 2 to 9\r\nmove 2 from 4 to 8\r\nmove 4 from 9 to 1\r\nmove 1 from 4 to 9\r\nmove 1 from 7 to 8\r\nmove 9 from 2 to 1\r\nmove 1 from 2 to 5\r\nmove 1 from 5 to 3\r\nmove 1 from 9 to 3\r\nmove 4 from 3 to 6\r\nmove 4 from 8 to 9\r\nmove 2 from 3 to 6\r\nmove 2 from 6 to 9\r\nmove 1 from 4 to 8\r\nmove 3 from 6 to 3\r\nmove 2 from 6 to 5\r\nmove 1 from 5 to 2\r\nmove 2 from 2 to 1\r\nmove 9 from 7 to 3\r\nmove 7 from 3 to 9\r\nmove 9 from 9 to 8\r\nmove 10 from 7 to 1\r\nmove 3 from 9 to 3\r\nmove 3 from 3 to 1\r\nmove 5 from 8 to 3\r\nmove 1 from 9 to 3\r\nmove 1 from 5 to 6\r\nmove 3 from 8 to 4\r\nmove 1 from 8 to 4\r\nmove 2 from 8 to 2\r\nmove 7 from 3 to 8\r\nmove 4 from 4 to 2\r\nmove 1 from 4 to 6\r\nmove 1 from 8 to 1\r\nmove 5 from 7 to 5\r\nmove 2 from 6 to 7\r\nmove 3 from 8 to 7\r\nmove 2 from 2 to 1\r\nmove 23 from 1 to 6\r\nmove 2 from 3 to 5\r\nmove 1 from 3 to 6\r\nmove 1 from 7 to 2\r\nmove 22 from 6 to 4\r\nmove 5 from 2 to 7\r\nmove 6 from 5 to 3\r\nmove 17 from 4 to 1\r\nmove 5 from 8 to 2\r\nmove 23 from 1 to 7\r\nmove 5 from 3 to 1\r\nmove 15 from 7 to 2\r\nmove 2 from 3 to 4\r\nmove 1 from 8 to 4\r\nmove 5 from 1 to 9\r\nmove 6 from 7 to 1\r\nmove 8 from 4 to 6\r\nmove 4 from 9 to 5\r\nmove 3 from 5 to 7\r\nmove 1 from 9 to 1\r\nmove 7 from 7 to 4\r\nmove 7 from 1 to 5\r\nmove 10 from 2 to 3\r\nmove 4 from 2 to 4\r\nmove 6 from 2 to 8\r\nmove 7 from 6 to 7\r\nmove 7 from 3 to 1\r\nmove 3 from 6 to 2\r\nmove 5 from 8 to 7\r\nmove 7 from 5 to 7\r\nmove 1 from 5 to 6\r\nmove 1 from 6 to 2\r\nmove 2 from 3 to 4\r\nmove 1 from 3 to 7\r\nmove 1 from 2 to 6\r\nmove 3 from 7 to 6\r\nmove 1 from 8 to 3\r\nmove 4 from 4 to 2\r\nmove 2 from 4 to 9\r\nmove 2 from 1 to 7\r\nmove 1 from 4 to 9\r\nmove 1 from 3 to 5\r\nmove 4 from 6 to 1\r\nmove 3 from 4 to 5\r\nmove 2 from 4 to 1\r\nmove 8 from 7 to 1\r\nmove 1 from 4 to 1\r\nmove 6 from 2 to 3\r\nmove 1 from 2 to 4\r\nmove 4 from 3 to 2\r\nmove 1 from 4 to 5\r\nmove 3 from 2 to 5\r\nmove 11 from 7 to 5\r\nmove 2 from 9 to 1\r\nmove 8 from 7 to 4\r\nmove 2 from 3 to 5\r\nmove 1 from 2 to 1\r\nmove 8 from 4 to 1\r\nmove 1 from 9 to 4\r\nmove 7 from 5 to 4\r\nmove 22 from 1 to 5\r\nmove 5 from 4 to 2\r\nmove 6 from 1 to 7\r\nmove 4 from 2 to 7\r\nmove 19 from 5 to 4\r\nmove 1 from 7 to 6\r\nmove 3 from 1 to 6\r\nmove 3 from 7 to 9\r\nmove 1 from 2 to 4\r\nmove 20 from 4 to 6\r\nmove 13 from 5 to 9\r\nmove 2 from 1 to 3\r\nmove 10 from 9 to 8\r\nmove 3 from 9 to 4\r\nmove 1 from 8 to 1\r\nmove 1 from 1 to 8\r\nmove 1 from 3 to 1\r\nmove 2 from 9 to 2";
    }
}