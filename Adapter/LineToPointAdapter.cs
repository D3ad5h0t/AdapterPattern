using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Adapter
{
    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int _count = 0;
        private static Dictionary<int, List<Point>> _cache = new Dictionary<int, List<Point>>();

        private int _hash;
        
        public LineToPointAdapter(Line line)
        {
            _hash = line.GetHashCode();
            if (_cache.ContainsKey(_hash)) return;
            
            Console.WriteLine($"{++_count}: Generating points for line" 
                              + $" [{line.Start.X},{line.Start.Y}]-" 
                              + $"[{line.End.X},{line.End.Y}] (no caching)");

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);

            var points = new List<Point>();

            if (right - left == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            } else if (line.End.Y - line.Start.Y == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }
            
            _cache.Add(_hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _cache[_hash].GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}