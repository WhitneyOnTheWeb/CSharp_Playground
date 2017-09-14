using System;

namespace Arrays
{
    class Program
    {
        static void Main()
        {
            int[] pips = new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            for (int count = 0; count < pips.Length; ++count)
                pips[count] = pips[count] + 10;

            Console.ReadKey();
        }
    }
}
