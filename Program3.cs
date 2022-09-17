using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab3
{
    class Program 
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            System.Console.WriteLine("Введіть число для перевірки: ");
            string numberToCheck = Console.ReadLine();
            bool isTrue = true;


            for (int letterIndex = 0; letterIndex < numberToCheck.Length / 2; letterIndex++) 
            {
                if (numberToCheck[letterIndex] == numberToCheck[numberToCheck.Length - 1 - letterIndex])
                {
                    continue;
                }
                else {
                    isTrue = false;
                    break;
                }
            }


            if (isTrue) {
                System.Console.WriteLine("Введене число читається однаково зліва на право і з права на ліво");
            }
            else {
                System.Console.WriteLine("Введене число НЕ читається однаково зліва на право і з права на ліво");
            }
        }
    }
}