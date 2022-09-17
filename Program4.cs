using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab4 
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            System.Console.WriteLine("Введіть кількість елементів масиву: ");
            int arrLength = int.Parse(Console.ReadLine());
            if (arrLength >= 1) 
            {
                if(arrLength != 1)
                {
                    int[] arr = new int[arrLength];
                
                    for( int arrElemIndex = 0; arrElemIndex < arrLength; arrElemIndex++ ) 
                    {
                        System.Console.WriteLine($"Введіть {arrElemIndex+1}-й елемент масиву: ");
                        int tempArrElem = int.Parse(Console.ReadLine());

                        arr[arrElemIndex] = tempArrElem;
                    }
                    
                    showArray(arr);
                    Array.Sort(arr);
                    showArray(arr);


                    double d = (arr[1] * 1.0) / arr[0];
                    int p = arr[1] - arr[0];

                    bool isArifmetic = false;
                    bool isGeometric = false;


                    for( int sortedArrElemIndex = 2; sortedArrElemIndex < arrLength; sortedArrElemIndex++ ) 
                    {
                        if( !isArifmetic && !isGeometric ) 
                        {
                            if (arr[sortedArrElemIndex] - arr[sortedArrElemIndex-1] == p)
                            {
                                isArifmetic = true;
                            }
                            else if ((arr[sortedArrElemIndex] * 1.0) / arr[sortedArrElemIndex-1] == d) 
                            {
                                isGeometric = true;
                            }
                            else 
                            {
                                break;
                            }
                        }
                        else if(isArifmetic) 
                        {
                            if( arr[sortedArrElemIndex] - arr[sortedArrElemIndex-1] == p) 
                            {
                                continue;
                            }
                            else
                            {
                                isArifmetic = false;
                                break;
                            }
                        }
                        else if(isGeometric)
                        {
                            if( (arr[sortedArrElemIndex]*1.0) / arr[sortedArrElemIndex-1] == d )
                            {
                                continue;
                            }
                            else
                            {
                                isGeometric = false;
                                break;
                            }
                        }
                    }


                    if (isArifmetic || isGeometric)
                    {
                        if (isArifmetic) {
                            System.Console.WriteLine($"Введений масив чисел - це арифметична прогресія. p = {p}");
                        }
                        else if (isGeometric) 
                        {
                            System.Console.WriteLine($"Введений масив чисел - це геометрична прогресія. d = {d}");
                        }
                    }
                    else 
                    {
                        System.Console.WriteLine("Введений масив чисел - це звичайний набір чисел");
                    }

                }
                else
                {
                    System.Console.WriteLine("Введений масив чисел не є прогресією");
                }
            }
            else
            {
                System.Console.WriteLine("Введена довжина не є корректною");
            }
        }


        static void showArray(int[] arr)
        {
            for(int index = 0; index < arr.Length; index++) 
            {
                System.Console.Write(arr[index] + " ");
            }
            System.Console.WriteLine();
        }
    }

}
