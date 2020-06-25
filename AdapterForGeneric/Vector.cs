using System;

namespace AdapterForGeneric
{
    public abstract class Vector<TSelf, T, TD> 
        where TD : IInteger, new()
        where TSelf : Vector<TSelf, T, TD>, new()
    {
        protected T[] Data;

        public Vector()
        {
            Data = new T[new TD().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new TD().Value;
            Data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                Data[i] = values[i];
            }
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new TD().Value;
            result.Data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                result.Data[i] = values[i];
            }

            return result;
        }
        
        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public T X
        {
            get => Data[0];
            set => Data[0] = value;
        }
    }
}