using System;

namespace Задача_1
{
    public class Program : Functions
    {
        private static int[] InputArrayForFraction(int[] arrayearly)
        {
            for (int i= 0; i < 2; i++)
            {
                arrayearly[i] = int.Parse(Console.ReadLine());
                if (i == 0)
                    Console.WriteLine("/");
            }

            return arrayearly;
        }

        private static int[] DifferenceFractions(int[] fraction1, int[] fraction2)
        {
            int temp;
            int[] result = new int[2];

            temp = fraction2[1];
            fraction2[1] = fraction2[0];
            fraction2[0] = temp;

            for (int i = 0; i < 2; i++)
            {
                result[i] = fraction1[i] * fraction2[i];          
            }

            return result;
        }

        private static void CheckCut(int[] arrayearly)
        {
            if (arrayearly[0] % arrayearly[1] == 0)
            {
                Console.WriteLine(arrayearly[0] / arrayearly[1]);
            }

            int max = arrayearly[0];
            for (int i = 0; i < 2; i++)
            {
                if (arrayearly[i] > max)
                {
                    max = arrayearly[i];
                }
            }

            for (int i = 1; i < max; i++)
            {
                if (arrayearly[0] % i == 0 && arrayearly[1] % i == 0)
                {
                    arrayearly[0] /= i;
                    arrayearly[1] /= i;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (arrayearly[0] % arrayearly[1] == 0)
                    break;

                Console.WriteLine(arrayearly[i]);
                if (i == 0)
                    Console.WriteLine("/");
            }
        }

        public static void Main(string[] args)
        {
            int[] fraction1 = new int[2];
            int[] fraction2 = new int[2];
            fraction1 = InputArrayForFraction(fraction1);
            Console.WriteLine();
            fraction2 = InputArrayForFraction(fraction2);
            int [] result = DifferenceFractions(fraction1, fraction2);
            Console.WriteLine();
            CheckCut(result);
        }
    }
}
