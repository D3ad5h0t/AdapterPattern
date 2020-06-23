using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Security.AccessControl;
using MoreLinq;
using static System.Console;

namespace Adapter
{
    class Program
    {
        private static readonly List<VectorObject> _vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1, 1, 10, 10),
            new VectorRectangle(3, 3, 6, 6)
        };
        
        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }
        
        static void Main(string[] args)
        {
            DrawPoints();
            DrawPoints();
        }

        private static void DrawPoints()
        {
            foreach (var vectorObject in _vectorObjects)
            {
                foreach (var line in vectorObject)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
    }
}