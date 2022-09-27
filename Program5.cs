using System;

// Malikov Vadym; Group: PD-22; Option: 11


namespace Lab5
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            int differentRows = 0;
            int differentColumns = 0;


            int rows = 0;
            int columns = 0;


            int[,] array = { { 1, 4, 3, 4 }, { 4, 5, 6, 7 }, { 1, 2, 3, 5 } };


            rows = array.GetUpperBound(0) + 1;
            columns = array.Length / rows;
            System.Console.WriteLine();
            matrixPrinter(array, rows, columns);


            for( int rowIndex = 0; rowIndex < rows; rowIndex++) 
            {
                int[] row = new int[columns];
                for( int elemIndex = 0; elemIndex < columns; elemIndex++ )
                {
                    row[elemIndex] = array[rowIndex, elemIndex];
                }
                if(IsArrayDifferent(row))
                {
                    differentRows++;
                }
            }


            for( int columnIndex = 0; columnIndex < columns; columnIndex++) 
            {
                int[] column = new int[rows];
                for( int elemIndex = 0; elemIndex < rows; elemIndex++ )
                {
                    column[elemIndex] = array[elemIndex, columnIndex];
                }
                if(IsArrayDifferent(column))
                {
                    differentColumns++;
                }
            }


            System.Console.WriteLine($"Кількість рядків з унікальними елементами - {differentRows}\nКількість стовпчиків з унікальними елементами - {differentColumns}");
            System.Console.WriteLine();
        }


        static bool IsArrayDifferent(int[] array)
        {
            bool result = false;
            int arrayLength = array.Length;

            for( int index = 1; index < arrayLength; index++ )
            {

                for( int previousIndex = 0; previousIndex < index; previousIndex++ )
                {
                    if(array[index] != array[previousIndex])
                    {
                        result = true;
                    }
                    else 
                    {
                        result = false;
                        break;
                    }
                }
                if(!result)
                {
                    break;
                }   
            }

            return result;
        }


        static void matrixPrinter(int[,] array, int rows, int cols)
        {
            for(int i = 0; i < rows; i++) 
            {
                for(int j = 0; j < cols; j++)
                {
                    System.Console.Write($"{array[i, j]} ");
                }
                System.Console.Write("\n");
            }
            System.Console.WriteLine();
        }
    }
}