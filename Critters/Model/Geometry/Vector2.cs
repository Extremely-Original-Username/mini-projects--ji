using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Geometry
{
    public class Vector2<T>
    {
        public T X {  get; set; } 
        public T Y { get; set; }

        public Vector2()
        {
            randomise();
        }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public void randomise()
        {
            Random r = new Random();

            if (typeof(T) == typeof(float))
            {
                float sign = (r.NextSingle() - 0.5f) * 2;
                X = (T)(object)(r.NextSingle() * sign);
                Y = (T)(object)(r.NextSingle() * sign);
            }
            if (typeof(T) == typeof(int))
            {
                int sign = r.Next() % 2 == 0? 1 : -1;
                X = (T)(object)(r.Next() * sign);
                Y = (T)(object)(r.Next() * sign);
            }
        }
        public void normalise()
        {
            if (typeof(T) == typeof(float))
            {
                // Cast X and Y to float
                float x = (float)(object)X;
                float y = (float)(object)Y;

                // Calculate the magnitude of the vector
                float magnitude = (float)Math.Sqrt(x * x + y * y);

                // Avoid division by zero
                if (magnitude > 0)
                {
                    // Normalize the vector components
                    X = (T)(object)(x / magnitude);
                    Y = (T)(object)(y / magnitude);
                }
            }
            else
            {
                throw new InvalidOperationException("Normalization is only supported for float types");
            }
        }
    }
}
