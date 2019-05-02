using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemBox.Crack
{
    internal sealed class GXRandom
    {
        public GXRandom() : this(Environment.TickCount)
        {
        }

        public GXRandom(int int_3)
        {
            int num = 161803398 - Math.Abs(int_3);
            RandomArray[55] = num;
            int num2 = 1;
            for (int i = 1; i < 55; i++)
            {
                int num3 = 21 * i % 55;
                RandomArray[num3] = num2;
                num2 = num - num2;
                if (num2 < 0)
                {
                    num2 += int.MaxValue;
                }
                num = RandomArray[num3];
            }
            for (int j = 1; j < 5; j++)
            {
                for (int k = 1; k < 56; k++)
                {
                    RandomArray[k] -= RandomArray[1 + (k + 30) % 55];
                    if (RandomArray[k] < 0)
                    {
                        RandomArray[k] += int.MaxValue;
                    }
                }
            }
            int_1 = 21;
        }
        private double method_0()
        {
            if (++int_0 >= 56)
            {
                int_0 = 1;
            }
            if (++int_1 >= 56)
            {
                int_1 = 1;
            }
            int num = RandomArray[int_0] - RandomArray[int_1];
            if (num < 0)
            {
                num += int.MaxValue;
            }
            RandomArray[int_0] = num;
            return (double)num * 4.6566128752457969E-10;
        }
        public int Next()
        {
            return (int)(method_0() * 2147483647.0);
        }
        public int Next(int int_3)
        {
            if (int_3 < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "Max value is less then min value.");
            }
            if (int_3 == 0)
            {
                return 0;
            }
            return (int)(method_0() * (double)int_3);
        }
        public int Next(int int_3, int int_4)
        {
            if (int_3 > int_4)
            {
                throw new ArgumentOutOfRangeException("minValue", "Min value is greater then max value.");
            }
            if (int_3 == int_4)
            {
                return int_3;
            }
            return (int)(method_0() * (double)(int_4 - int_3)) + int_3;
        }
        public void NextBytes(byte[] byte_0)
        {
            if (byte_0 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            for (int i = 0; i < byte_0.Length; i++)
            {
                byte_0[i] = (byte)(method_0() * 256.0);
            }
        }
        public double NextDouble()
        {
            return method_0();
        }
        private int int_0;
        private int int_1;
        private int[] RandomArray = new int[56];
    }
}
