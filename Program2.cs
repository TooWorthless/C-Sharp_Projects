using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab2 
{
    class Program 
    {
        public static void Main() 
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            System.Console.WriteLine("Введіть максимальне число nk: ");
            int nk = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Введіть мінімальне число nn: ");
            int nn = int.Parse(Console.ReadLine());


            if (nk >= nn && nn >= 0)
            {
                int k = nn;
                double result = 1.0;


                while( k <= nk )
                {
                    result *= (  (Math.Pow((-1), (k*k - 2*k + 3))*k + 1)  /  (k*k - 2.0)  );
                    k++;
                }


                System.Console.WriteLine(result);
            }
        }
    }
}
