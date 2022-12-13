using System.Drawing;

namespace Day12
{
    internal class Program
    {
        private static Dictionary<int, Route> routes = new();
        private static List<Point> pointsVisited = new();
        private static List<List<int>> map = new();
        private static Point endPos = Point.Empty;
        private static int routeCounter = 0;

        static void Main(string[] args)
        {
            Point mapStartPos = Point.Empty;
            using StringReader reader = new(DayInput);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<int> mapRow = new();
                char[] rowChars = line.ToCharArray();
                foreach (char c in rowChars)
                {
                    if (c == 'S')
                    {
                        mapStartPos = new Point(mapRow.Count, map.Count);
                        mapRow.Add('a');
                    }
                    else if (c == 'E')
                    {
                        endPos = new Point(mapRow.Count, map.Count);
                        mapRow.Add('z');
                    }
                    else
                    {
                        mapRow.Add(c);
                    }
                }
                map.Add(mapRow);
            }

            Console.WriteLine("Start: " + mapStartPos + ", End: " + endPos);

            List<Route> mapStartCompleteRoutes = DoRoute(mapStartPos);
            Console.WriteLine("Shortest: " + (mapStartCompleteRoutes.OrderBy(x => x.points.Count).First().points.Count() - 1));

            int minSteps = int.MaxValue;
            for (int y = 0; y < map.Count; y++)
            {
                List<int> row = map[y];
                for (int x = 0; x < row.Count; x++)
                {
                    if (row[x] == 'a')
                    {
                        List<Route> completeRoutes = DoRoute(new Point(x, y));
                        if (completeRoutes.Count > 0)
                        {
                            int numSteps = completeRoutes.OrderBy(a => a.points.Count).First().points.Count() - 1;
                            minSteps = Math.Min(minSteps, numSteps);
                            Console.WriteLine("Steps for " + x + ", " + y + ": " + numSteps);
                        }
                    }
                }
            }
            Console.WriteLine("Min steps from 'a': " + minSteps);
        }

        private static List<Route> DoRoute(Point startPos)
        {
            routeCounter = 0;
            routes = new();
            pointsVisited = new();

            Route startRoute = new(routeCounter++, new());
            startRoute.points.Add(startPos);
            pointsVisited.Add(startPos);
            routes.Add(startRoute.index, startRoute);

            List<Route> completeRoutes = new();
            int counter = 1;
            while (routes.Count > 0 && completeRoutes.Count == 0)
            {
                //Console.WriteLine("Loop: " + counter + ", NumRoutes: " + routes.Count);
                Route[] loopRoutes = routes.Values.ToArray();
                for (int i = routes.Count - 1; i >= 0; i--)
                {
                    DoStep(loopRoutes.ElementAt(i), completeRoutes);
                }
                counter++;
            }

            return completeRoutes;
        }

        private static void DoStep(Route route, List<Route> completeRoutes)
        {
            List<Point> previousSteps = route.points.ToList();
            bool branch = false;
            Point currentPoint = route.points.Last();
            int currentHeight = map.ElementAt(currentPoint.Y).ElementAt(currentPoint.X);
            int up = currentPoint.Y == 0 ? -1 : map.ElementAt(currentPoint.Y - 1).ElementAt(currentPoint.X);
            int down = currentPoint.Y == map.Count - 1 ? -1 : map.ElementAt(currentPoint.Y + 1).ElementAt(currentPoint.X);
            int left = currentPoint.X == 0 ? -1 : map.ElementAt(currentPoint.Y).ElementAt(currentPoint.X - 1);
            int right = currentPoint.X == map.First().Count - 1 ? -1 : map.ElementAt(currentPoint.Y).ElementAt(currentPoint.X + 1);

            if (up > -1)
            {
                Point newPoint = new Point(currentPoint.X, currentPoint.Y - 1);
                if (pointsVisited.Contains(newPoint))
                {
                    branch = true;
                    routes.Remove(route.index);
                }
                else if (up <= currentHeight + 1)
                {
                    branch = true;
                    route.points.Add(newPoint);
                    pointsVisited.Add(newPoint);
                    if (newPoint == endPos)
                    {
                        routes.Remove(route.index);
                        completeRoutes.Add(route);
                    }
                }
            }

            if (down > -1)
            {
                Point newPoint = new Point(currentPoint.X, currentPoint.Y + 1);
                if (pointsVisited.Contains(newPoint))
                {
                    if (!branch)
                    {
                        branch = true;
                        routes.Remove(route.index);
                    }
                }
                else if (down <= currentHeight + 1)
                {
                    Route steps = route;
                    if (branch)
                    {
                        steps = new Route(routeCounter++, previousSteps.ToList());
                        routes.Add(steps.index, steps);
                    }

                    steps.points.Add(newPoint);
                    pointsVisited.Add(newPoint);
                    if (newPoint == endPos)
                    {
                        routes.Remove(steps.index);
                        completeRoutes.Add(steps);
                    }
                    branch = true;
                }
            }

            if (left > -1)
            {
                Point newPoint = new Point(currentPoint.X - 1, currentPoint.Y);
                if (pointsVisited.Contains(newPoint))
                {
                    if (!branch)
                    {
                        branch = true;
                        routes.Remove(route.index);
                    }
                }
                else if (left <= currentHeight + 1)
                {
                    Route steps = route;
                    if (branch)
                    {
                        steps = new Route(routeCounter++, previousSteps.ToList());
                        routes.Add(steps.index, steps);
                    }

                    steps.points.Add(newPoint);
                    pointsVisited.Add(newPoint);
                    if (newPoint == endPos)
                    {
                        routes.Remove(steps.index);
                        completeRoutes.Add(steps);
                    }
                    branch = true;
                }
            }

            if (right > -1)
            {
                Point newPoint = new Point(currentPoint.X + 1, currentPoint.Y);
                if (pointsVisited.Contains(newPoint))
                {
                    if (!branch)
                    {
                        branch = true;
                        routes.Remove(route.index);
                    }
                }
                else if (right <= currentHeight + 1)
                {
                    Route steps = route;
                    if (branch)
                    {
                        steps = new Route(routeCounter++, previousSteps.ToList());
                        routes.Add(steps.index, steps);
                    }

                    steps.points.Add(newPoint);
                    pointsVisited.Add(newPoint);
                    if (newPoint == endPos)
                    {
                        routes.Remove(steps.index);
                        completeRoutes.Add(steps);
                    }
                    branch = true;
                }
            }

            //We haven't been able to move anywhere
            if (!branch)
            {
                routes.Remove(route.index);
            }
        }

        private static string DayInput = "abaaaaacccccccccccccccccccccccccccccccccccccccaaaaaaaccccaaaaaaaaaaaaaaaaacccccaaaaaacccccccccccccccccccccccaaaaaaaaccccccccccccccccccccccccccccccccaaaaaa\r\nabaaaaaacccaaaacccccccccccccccccccccccaccccccccaaaaaaaaccaaaaaaaaaaaaaaaaccccccaaaaaacccccccccccccccccccccccccaaaaccccccccccccccccccccccccccccccccccaaaaaa\r\nabaaaaaacccaaaacccccccccccccccccaaaaaaaacccccccaaaaaaaaacaaaaaaaaaaaaacccccccccaaaaacccccccccccccccccccccccccaaaaacccccccccccccccccccaaaccccccccccccaaaaaa\r\nabaaacaccccaaaaccccccccccccccccccaaaaaacccccccccaaaaaaaccccaaaaaaaaaaacccccccccaaaaacccccccccccccccccccccccccaacaaaccccccccccccccccccaaacccccccccccccccaaa\r\nabaaacccccccaaacccccccccccaacccccaaaaaaccccccccaaaaaaccccccaacaaaaaaaacccccccccccccccccccccccaaccccccccccccccacccaaaaacccccccccaaccccaaacccccccccccccccaaa\r\nabccccccccccccccccccccccccaaaaccaaaaaaaacccccccaaaaaaaccccccccaaaaaaaaaccccccccccaacccccccccaaaccccccccccccccccccacaaacccccccccaaaaccaaacccccccccccccccaac\r\nabccccccccccccccccccccccaaaaaacaaaaaaaaaaccccccaaccaaaaacccccaaaaccaaaaccccccccccaaacaacccccaaacaaacccaaccccccccaaaaaaaacccccccaaaaakkkkkkcccccccccccccccc\r\nabccccccccccccccccccccccaaaaaccaaaaaaaaaacccccccccccaaaaaaccccacccaaaaaccccccccccaaaaaaccaaaaaaaaaaaaaaaccccccccaaaaaaaaccccccccaaajkkkkkkkaccccccaacccccc\r\nabcccccccccccccccccccccccaaaaacacacaaaccccccccccccccaaaaaaccccccccaaaacccccccccaaaaaaacccaaaaaaaaaaaaaaaaaccccccccaaaaaccccccccccjjjkkkkkkkkccaaaaaacccccc\r\nabcccccccccccccccccccccccaacaacccccaaacccaccccccccccaaaaaaccccccccaaaacccccccccaaaaaaacccccaaaaaacaaaaaaaacccccccaaaaacccccccjjjjjjjooopppkkkcaaaaaaaccccc\r\nabcccccccccccccccccaacaacccccccccccaaaaaaacccccccccccaaaaacccccccccccccccccccccccaaaaaaccccaaaaaaccaaaaaaacccccccaaaaaacciijjjjjjjjoooopppkkkcaaaaaaaacccc\r\nabccccccccccaaaccccaaaaacccccccccccccaaaaacccccccccccaaaaccccccccccccccccccccccccaacaaaccccaaaaaaacaaaaacccccccccaccaaaciiiijjjjjjoooopppppkllcaaaaaaacccc\r\nabccaaccccccaaaaacaaaaacccccccccccccaaaaaacccccccccccccccccccccccccccccccccccccccaacccccccaaaacaaaaaaaaacccaaccccaaaaaciiiiinoooooooouuuupplllaaaaaacccccc\r\nabcaaacccccaaaaaacaaaaaacccccccccccaaaaaaaaccccccccaacaccccccccccccccccccccccccccccccccccccaccccccccccaaccaaaccccaaaaaciiinnnooooooouuuuuppplllaaacacccccc\r\nabaaaaaacccaaaaaacccaaaacccccccccccaaaaaaaaccccccccaaaaccccccccccccccccccccccccccccccccccccccccccccccccaaaaacaacaaaaaaiiinnnnntttoouuuuuupppllllcccccccccc\r\nabaaaaaaccccaaaaacccaaccccccccccacccccaaccccccccccaaaaaccccccccccccccccccccccccccccccccccccccccccccccccaaaaaaaacaaaaaaiiinnnnttttuuuuxxuuupppllllccccccccc\r\nabaaaaacccccaacaaccccccccccccccaaaccccaacccccaacccaaaaaacccccccccccccccccccccccccccccccccccccccccccccccccaaaaaccaaaaaaiiinnnttttxxuuxxyyuuppppllllcccccccc\r\nabaaaacccccccccccccccccccccaaacaaaccccccaaacaaaaccacaaaacccccccccccccccccccccccccccccccccccaacccccccccccaaaaaccccaaaccciinnntttxxxxxxxyyvvvqqqqqlllccccccc\r\nabaaaaaccccccccccccccccccccaaaaaaaaaacccaaaaaaacccccaaccccccccccccccccccccccccccccccccccccaaacccccccccccaacaaaccccccccciiinntttxxxxxxxyyvvvvvqqqqljjcccccc\r\nabccaaaccaccccccccaaacccccccaaaaaaaaaccccaaaaaacccccccccccccccccccccccccccccccaacccccccaaaaacaaccccccccccccaacccccccccchhinnnttxxxxxxyyyyyvvvvqqqjjjcccccc\r\nSbccccaaaacccccccaaaaaacccccccaaaaaccccccaaaaaaaaccccccccccccccccccccaaccccccaaaaccccccaaaaaaaacccccccccccccccccccccccchhhnnntttxxxxEzyyyyyvvvqqqjjjcccccc\r\nabccccaaaacccccccaaaaaaccccccaaaaaacccccaaaaaaaaaacccccccccccccccccccaaccccccaaaaccccccccaaaaacccccccccccccccccccccccccchhhnntttxxxyyyyyyyvvvvqqqjjjcccccc\r\nabcccaaaaaaccccccaaaaaacccccaaaaaaaccccaaaaaaaaaacccccccccccccccccaaaaaaaacccaaaacccccccaaaaaccccccccccccccccccccccccccchhmmmttxxxyyyyyyvvvvvqqqjjjdcccccc\r\nabcccaaaaaacccccccaaaaacccccaaacaaacaaaaaaaaaaccccccccccccaaacccccaaaaaaaaccccccccccccccaacaaacccccccaacaaacccccccccccchhhmmmtswwwyyyyyyvvvqqqqjjjjdddcccc\r\nabcccccaacccccccccaacaacccccccccccacaaaaaccaaaccccccccccaaaaacccccccaaaacccccccccccccccccccaaccccccccaaaaaacccccccccccchhhmmssswwwwwwyyywvrqqqjjjjdddccccc\r\nabcccccccccccccccccccccccccccccccccaaaaaccccaaccccccccacaaaaaacccccaaaaacccccccccccccccccccccccccccccaaaaaacccccccccccchhhmmssswwwwwwywywwrrqjjjjddddccccc\r\nabcccccccccccccccccccccccccccccccccaaaaaccccccccaaacaaacaaaaaacccccaaaaaaccccccccccccccccccccccccccccaaaaaaaccccccccccchhmmmsssswwsswwwwwwrrkkjjddddcccccc\r\nabccccccccccccccccccccccccccccccccccaaaaacccccccaaaaaaacaaaaaccccccaaccaacccccccccccaaccccccccccccccaaaaaaaacaacaaccccchhhmmmsssssssswwwwrrrkkjddddaaccccc\r\nabcccccccccccccccccccccccccaaaaaccccaacccccccccccaaaaaacaaaaacccccccccccccaacccccccaaaaaacccccccccccaaaaaaaacaaaaaccccchhgmmmmssssssrrwwwrrrkkddddaaaccccc\r\nabcccccccccccccccccccccccccaaaaacccccccccccccccccaaaaaaaacccccccccccccccaaaaaaccccccaaaaaccccaaccccccccaaacccaaaaaaccccgggmmmmmmllllrrrrrrrkkkeedaaaaccccc\r\nabcccccccccccaaccccccccccccaaaaaacccccccccccccccaaaaaaaaacccccccccccccccaaaaaaccccaaaaaaacccaaaacccccccaaccccaaaaaaccccggggmmmmllllllrrrrrkkkkeedaaaaacccc\r\nabcccccccccccaaacaacaaaccccaaaaaaccccccccccccccaaaaaaaaaacccccccccccccccaaaaaaccccaaaaaaaaccaaaacccccccccccccaaaaaccccccgggggglllllllllrrkkkkeeeaaaaaacccc\r\nabcccccccccccaaaaaacaaaacccaaaaaaccccccccccccccaaacaaaaaaccccccccccccccccaaaaaccccaaaaaaaaccaaaacccccccccccaaccaaaccccccgggggggggffflllkkkkkkeeeaaaaaacccc\r\nabaccccccccaaaaaaaccaaaacccccaaacccccccccccccccccccaaaaaacaccccccccaaccccaaaacccccccaaacacccccccccccccccaaaaaccccccccccccccgggggffffflllkkkkeeeccaaacccccc\r\nabaccccccccaaaaaaaccaaacccccccccccccccccaaaccccccccaaacaaaaaccccccaaacccccccccccccaaaacccccccccccccccccccaaaaaccccccccccccccccccaffffffkkkeeeeeccaaccccccc\r\nabaaaccccccccaaaaaaccccccccccccccccccccaaaaaacccccccaaaaaaaacaaaacaaacccccccccaaaaaacccccccccccccccccccccaaaaaccccccccccccccccccccaffffffeeeeecccccccccccc\r\nabaacccccccccaacaaaccccccccccccccccccccaaaaaaccccccccaaaaaccaaaaaaaaacccccccccaaaaaaaaccccccccccaaccccccaaaaacccccccccccccccccccccaaaffffeeeecccccccccccaa\r\nabaacccccccccaaccccccccccccccccaaccccccaaaaacaaccaacccaaaaacaaaaaaaaacccccccccaaaaaaaaccccccaaacaacccccccccaacccccccccccccccccccccaaaccceaecccccccccccccaa\r\nabaacccccccccccccccccccccccccccaaaaaacccaaaaaaaaaaaccaaacaaccaaaaaaaaaaaaacccccaaaaaaacccccccaaaaaccccccccccccccccccccccccccccccccaaacccccccccccccccaaacaa\r\nabcccccccccccccccccccccccccccccaaaaaccccaacaacaaaaacccaaccccccaaaaaaaaaaaacccccaaaaacccccccccaaaaaaaccccccccccccccccccccccccccccccaaacccccccccccccccaaaaaa\r\nabcccccccccccccccccccccccccccaaaaaaaccccccccaaaaaaaaccccccccccaaaaaaaaaaccccccaaaaaaccccccccaaaaaaaaccccccccccccccccccccccccccccccccccccccccccccccccaaaaaa";
    }
}