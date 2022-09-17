using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab1 
{
    class Program
    {
        public static void Main()
        {   
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            

            System.Console.WriteLine("Введіть секунди для форматування: ");
            int secondsAmount = int.Parse(Console.ReadLine());
            System.Console.WriteLine($"Секунди: {secondsAmount}");

            int hours;
            int minutes;
            int seconds;

            hours = secondsAmount / 3600;
            secondsAmount -= hours * 3600;
            minutes = secondsAmount / 60;
            secondsAmount -= minutes * 60;
            seconds = secondsAmount;


            Console.WriteLine($"Результат: {hours} год. {minutes} хв. {seconds} сек");
        }
    }
}

