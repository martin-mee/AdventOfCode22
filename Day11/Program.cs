using System.Numerics;

namespace Day11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoMonkeyBusiness1();
            DoMonkeyBusiness2();
        }

        private static void DoMonkeyBusiness1()
        {
            List<int> monkey0 = new List<int>() { 98, 97, 98, 55, 56, 72 };
            List<int> monkey1 = new List<int>() { 73, 99, 55, 54, 88, 50, 55 };
            List<int> monkey2 = new List<int>() { 67, 98 };
            List<int> monkey3 = new List<int>() { 82, 91, 92, 53, 99 };
            List<int> monkey4 = new List<int>() { 52, 62, 94, 96, 52, 87, 53, 60 };
            List<int> monkey5 = new List<int>() { 94, 80, 84, 79 };
            List<int> monkey6 = new List<int>() { 89 };
            List<int> monkey7 = new List<int>() { 70, 59, 63 };

            //Reverse so that we can go through backwards and remove
            monkey0.Reverse();
            monkey1.Reverse();
            monkey2.Reverse();
            monkey3.Reverse();
            monkey4.Reverse();
            monkey5.Reverse();
            monkey6.Reverse();
            monkey7.Reverse();

            int[] inspections = Enumerable.Repeat(0, 8).ToArray();

            for (int i = 0; i < 20; i++)
            {
                for (int j = monkey0.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey0.ElementAt(j) * 13;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey0.RemoveAt(j);
                    if (newWorry % 11 == 0)
                    {
                        monkey4.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey7.Insert(0, newWorry);
                    }
                    inspections[0]++;
                }

                for (int j = monkey1.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey1.ElementAt(j) + 4;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey1.RemoveAt(j);
                    if (newWorry % 17 == 0)
                    {
                        monkey2.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey6.Insert(0, newWorry);
                    }
                    inspections[1]++;
                }

                for (int j = monkey2.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey2.ElementAt(j) * 11;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey2.RemoveAt(j);
                    if (newWorry % 5 == 0)
                    {
                        monkey6.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey5.Insert(0, newWorry);
                    }
                    inspections[2]++;
                }

                for (int j = monkey3.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey3.ElementAt(j) + 8;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey3.RemoveAt(j);
                    if (newWorry % 13 == 0)
                    {
                        monkey1.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey2.Insert(0, newWorry);
                    }
                    inspections[3]++;
                }

                for (int j = monkey4.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey4.ElementAt(j) * monkey4.ElementAt(j);
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey4.RemoveAt(j);
                    if (newWorry % 19 == 0)
                    {
                        monkey3.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey1.Insert(0, newWorry);
                    }
                    inspections[4]++;
                }

                for (int j = monkey5.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey5.ElementAt(j) + 5;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey5.RemoveAt(j);
                    if (newWorry % 2 == 0)
                    {
                        monkey7.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey0.Insert(0, newWorry);
                    }
                    inspections[5]++;
                }

                for (int j = monkey6.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey6.ElementAt(j) + 1;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey6.RemoveAt(j);
                    if (newWorry % 3 == 0)
                    {
                        monkey0.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey5.Insert(0, newWorry);
                    }
                    inspections[6]++;
                }

                for (int j = monkey7.Count - 1; j >= 0; j--)
                {
                    int newWorry = monkey7.ElementAt(j) + 3;
                    newWorry = (int)Math.Floor((double)newWorry / 3);
                    monkey7.RemoveAt(j);
                    if (newWorry % 7 == 0)
                    {
                        monkey4.Insert(0, newWorry);
                    }
                    else
                    {
                        monkey3.Insert(0, newWorry);
                    }
                    inspections[7]++;
                }
            }

            int[] top2 = inspections.Order().TakeLast(2).ToArray();
            Console.WriteLine(top2[0] * top2[1]);
        }

        private static void DoMonkeyBusiness2()
        {
            List<BigInteger> monkey0 = new List<BigInteger>() { 98, 97, 98, 55, 56, 72 };
            List<BigInteger> monkey1 = new List<BigInteger>() { 73, 99, 55, 54, 88, 50, 55 };
            List<BigInteger> monkey2 = new List<BigInteger>() { 67, 98 };
            List<BigInteger> monkey3 = new List<BigInteger>() { 82, 91, 92, 53, 99 };
            List<BigInteger> monkey4 = new List<BigInteger>() { 52, 62, 94, 96, 52, 87, 53, 60 };
            List<BigInteger> monkey5 = new List<BigInteger>() { 94, 80, 84, 79 };
            List<BigInteger> monkey6 = new List<BigInteger>() { 89 };
            List<BigInteger> monkey7 = new List<BigInteger>() { 70, 59, 63 };

            //Reverse so that we can go through backwards and remove
            monkey0.Reverse();
            monkey1.Reverse();
            monkey2.Reverse();
            monkey3.Reverse();
            monkey4.Reverse();
            monkey5.Reverse();
            monkey6.Reverse();
            monkey7.Reverse();

            BigInteger[] inspections = Enumerable.Repeat((BigInteger)0, 8).ToArray();

            for (int i = 0; i < 10000; i++)
            {
                for (int j = monkey0.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey0.ElementAt(j) * 13;
                    monkey0.RemoveAt(j);
                    if (newWorry % 11 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey4.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey7.Insert(0, newWorry);
                    }
                    inspections[0]++;
                }

                for (int j = monkey1.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey1.ElementAt(j) + 4;
                    monkey1.RemoveAt(j);
                    if (newWorry % 17 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey2.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey6.Insert(0, newWorry);
                    }
                    inspections[1]++;
                }

                for (int j = monkey2.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey2.ElementAt(j) * 11;
                    monkey2.RemoveAt(j);
                    if (newWorry % 5 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey6.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey5.Insert(0, newWorry);
                    }
                    inspections[2]++;
                }

                for (int j = monkey3.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey3.ElementAt(j) + 8;
                    monkey3.RemoveAt(j);
                    if (newWorry % 13 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey1.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey2.Insert(0, newWorry);
                    }
                    inspections[3]++;
                }

                for (int j = monkey4.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey4.ElementAt(j) * monkey4.ElementAt(j);
                    monkey4.RemoveAt(j);
                    if (newWorry % 19 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey3.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey1.Insert(0, newWorry);
                    }
                    inspections[4]++;
                }

                for (int j = monkey5.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey5.ElementAt(j) + 5;
                    monkey5.RemoveAt(j);
                    if (newWorry % 2 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey7.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey0.Insert(0, newWorry);
                    }
                    inspections[5]++;
                }

                for (int j = monkey6.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey6.ElementAt(j) + 1;
                    monkey6.RemoveAt(j);
                    if (newWorry % 3 == 0)
                    {
                        newWorry = newWorry % 9699690;
                        monkey0.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690;
                        monkey5.Insert(0, newWorry);
                    }
                    inspections[6]++;
                }

                for (int j = monkey7.Count - 1; j >= 0; j--)
                {
                    BigInteger newWorry = monkey7.ElementAt(j) + 3;
                    monkey7.RemoveAt(j);
                    if (newWorry % 7 == 0)
                    {
                        newWorry = newWorry % 9699690; 
                        monkey4.Insert(0, newWorry);
                    }
                    else
                    {
                        newWorry = newWorry % 9699690; 
                        monkey3.Insert(0, newWorry);
                    }
                    inspections[7]++;
                }
            }

            BigInteger[] top2 = inspections.Order().TakeLast(2).ToArray();
            Console.WriteLine(top2[0] * top2[1]);
        }
    }
}