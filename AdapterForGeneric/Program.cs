using System;

namespace AdapterForGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector2i(1, 2);
            v[0] = 0;
            var vv = new Vector2i(3, 2);

            var result = v + vv;
        }
    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i(params int[] values) : base(values)
        {
            
        }
    }
}