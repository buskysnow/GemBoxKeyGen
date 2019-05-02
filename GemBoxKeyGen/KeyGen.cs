using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemBox.Crack
{
    public static class KeyGen
    {

        public static string KeyAlaphabet = "0123456789ABCDEFGHIGKLMNOPQRSTUVWXYZ";
        public static string CreateSpreadSheetLicense()
        {
            int Year, Month, Day;

            Year = 2099;
            Month = 12;
            Day = 31;

            int Key4 = 0;
            Key4 = (Month + Year * 100) * 100 + Day;
            string KeyData = GuessKey(Key4, 5);

            char[] array = new char[13];
            array[0] = NumberToChar(32);
            string index1_2 = GuessKey(74, 2);
            array[1] = index1_2[0];
            array[2] = index1_2[1];
            //接下来5个字符随机
            for (int i = 0; i < 5; i++)
            {
                Random myRandom = new Random((int)(Guid.NewGuid().GetHashCode() + DateTime.Now.Ticks));
                array[3 + i] = NumberToChar(myRandom.Next(36));
            }
            for (int i = 0; i < KeyData.Length; i++)
            {
                array[8 + i] = KeyData[i];
            }
            //获取原始值
            Random myRandomFirst = new Random((int)(Guid.NewGuid().GetHashCode() + DateTime.Now.Ticks));
            int FisrtChar = myRandomFirst.Next(36);
            GXRandom gxrandom = new GXRandom(FisrtChar * 27961);
            StringBuilder ShortKeyBuilder = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                int num3 = gxrandom.Next(0, 36);
                int num2 = KeyAlaphabet.IndexOf(array[i]) + num3 - 36;
                num2 = num2 < 0 ? num2 + 36 : num2;
                ShortKeyBuilder.Append(NumberToChar(num2));
            }
            ShortKeyBuilder.Insert(0, NumberToChar(FisrtChar));
            string ShortKey = ShortKeyBuilder.ToString();
            char HashCode = GetHash('E' + ShortKey);
            string VaildKeyCode = 'E' + ShortKey + HashCode;
            string RealKeyInput = VaildKeyCode.Substring(0, 4) + '-' + VaildKeyCode.Substring(4, 4) + '-' + VaildKeyCode.Substring(8, 4)
                + '-' + VaildKeyCode.Substring(12, 4);
            return RealKeyInput;
        }
        public static string CreateWordLicense()
        {
            int Year, Month, Day;

            Year = 2099;
            Month = 12;
            Day = 31;

            int Key4 = 0;
            Key4 = (Month + Year * 100) * 100 + Day;
            string KeyData = GuessKey(Key4, 5);

            char[] array = new char[13];
            array[0] = NumberToChar(28);
            string index1_2 = GuessKey(98, 2);
            array[1] = index1_2[0];
            array[2] = index1_2[1];
            //接下来5个字符随机
            for (int i = 0; i < 5; i++)
            {
                Random myRandom = new Random((int)(Guid.NewGuid().GetHashCode() + DateTime.Now.Ticks));
                array[3 + i] = NumberToChar(myRandom.Next(36));
            }
            for (int i = 0; i < KeyData.Length; i++)
            {
                array[8 + i] = KeyData[i];
            }
            //获取原始值
            Random myRandomFirst = new Random((int)(Guid.NewGuid().GetHashCode() + DateTime.Now.Ticks));
            int FisrtChar = myRandomFirst.Next(36);
            GXRandom gxrandom = new GXRandom(FisrtChar * 27961);
            StringBuilder ShortKeyBuilder = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                int num3 = gxrandom.Next(0, 36);
                int num2 = KeyAlaphabet.IndexOf(array[i]) + num3 - 36;
                num2 = num2 < 0 ? num2 + 36 : num2;
                ShortKeyBuilder.Append(NumberToChar(num2));
            }
            ShortKeyBuilder.Insert(0, NumberToChar(FisrtChar));
            string ShortKey = ShortKeyBuilder.ToString();
            char HashCode = GetHash('D' + ShortKey);
            string VaildKeyCode = 'D' + ShortKey + HashCode;
            string RealKeyInput = VaildKeyCode.Substring(0, 4) + '-' + VaildKeyCode.Substring(4, 4) + '-' + VaildKeyCode.Substring(8, 4)
                + '-' + VaildKeyCode.Substring(12, 4);
            return RealKeyInput;
        }
        public static string GuessKey(int num, int length)
        {
            int numlast = num;
            int key = 0;
            StringBuilder keyAppender = new StringBuilder();
            for (int i = 1; i < length; i++)
            {
                key = numlast % 36;
                numlast = numlast / 36;
                keyAppender.Insert(0, NumberToChar(key));
            }
            keyAppender.Insert(0, NumberToChar(numlast));
            return keyAppender.ToString();
        }
        public static char NumberToChar(int num)
        {
            if (num >= 0 && num <= 35)
            {
                return KeyAlaphabet[num];
            }
            throw new ArgumentException("Wrong num value.", "ch");
        }
        public static char GetHash(string string_0)
        {
            int num = 0;
            for (int i = 0; i < string_0.Length; i++)
            {
                int num2 = KeyAlaphabet.IndexOf(string_0[i]);
                if (i % 2 == 1)
                {
                    int num3 = num2 * 2;
                    num += num3 / 36 + num3 % 36;
                }
                else
                {
                    num += num2;
                }
            }
            int int_0 = num % 36;
            if (int_0 > 9)
            {
                return (char)(65 + int_0 - 10);
            }
            return (char)(48 + int_0);
        }
    }
}
