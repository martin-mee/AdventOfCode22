using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal class Route
    {
        internal int index { get; set; }
        internal List<Point> points { get; set; }

        internal Route(int index, List<Point> points)
        {
            this.index = index;
            this.points = points;
        }
    }
}
