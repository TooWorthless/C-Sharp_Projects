using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab6 
{
    class Program
    {
        public static int Main() 
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;



            System.Console.WriteLine();
            System.Console.WriteLine("Введіть 1 щоб ввести число\nВведіть 2 щоб ввести строку\nВведіть 3 щоб ввести дробове число\nВведіть 4 щоб ввести строку з комою");
            System.Console.WriteLine();
            


            int dataTypeNumber = 0;
            try 
            {
                dataTypeNumber = int.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"{ex}\nIncorrect entered number!");
                return 0;
            }
            System.Console.WriteLine();


            string dataType = new string("");
            if (dataTypeNumber >= 1 && dataTypeNumber <= 4)
            {
                if (dataTypeNumber == 1)
                {
                    dataType = "integer";
                }
                else if (dataTypeNumber == 2)
                {
                    dataType = "string";
                }
                else if (dataTypeNumber == 3)
                {
                    dataType = "double";
                }
                else if (dataTypeNumber == 4)
                {
                    dataType = "doubleString";
                }
                else
                {
                    System.Console.WriteLine("Error(Incorrect entered value)!");
                }
            }
            else
            {
                System.Console.WriteLine("Error(Incorrect entered value)!");
                return 0;
            }


            System.Console.WriteLine("Введіть значення:");
            string data = Console.ReadLine();
            System.Console.WriteLine();


            try
            {
                enteredDataChecker(dataType, ref data);

                System.Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            return 0;
        }


        static void enteredDataChecker(string dataType, ref string data)
        {
            string[] letters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            string[] numbers = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string[] stringArrToCheck = stringToArray(data.ToLower());


            bool isCorrectSymbolChecker(string symbol, string[] checkingArray)
            {
                string letterToCheck = symbol.ToLower();
                for(int checkingArrayIndex = 0; checkingArrayIndex < checkingArray.Length; checkingArrayIndex++)
                {
                    if (symbol == checkingArray[checkingArrayIndex])
                    {
                        return true;
                    }
                }
                return false;
            }


            if (dataType == "integer")
            {
                for(int numberIndex = 0; numberIndex < data.Length; numberIndex++)
                {
                    if(!isCorrectSymbolChecker(stringArrToCheck[numberIndex], numbers)) 
                    {
                        throw new Exception("Error(Incorrect entered data)!");
                    }
                }
                int number = int.Parse(data);

                sequenceReverser(ref number);
                data = number.ToString();
            }
            else if (dataType == "string")
            {   
                for(int letterIndex = 0; letterIndex < data.Length; letterIndex++)
                {
                    if(!isCorrectSymbolChecker(stringArrToCheck[letterIndex], letters))
                    {
                        throw new Exception("Error(Incorrect entered data)!");
                    }
                }

                sequenceReverser(ref data);

            }
            else if (dataType == "double")
            {
                string splitSymbol = "";

                if( isCorrectSymbolChecker(stringArrToCheck[0], numbers)==true && isCorrectSymbolChecker(stringArrToCheck[data.Length-1], numbers)==true )
                {
                    int notNumbersAmount = 0;

                    for(int numberIndex = 1; numberIndex < data.Length-1; numberIndex++)
                    {
                        if(!isCorrectSymbolChecker(stringArrToCheck[numberIndex], numbers))
                        {   
                            if(notNumbersAmount == 0)
                            {
                                notNumbersAmount = 1; 
                                splitSymbol = stringArrToCheck[numberIndex];
                                continue;
                            }
                            else
                            {
                                throw new Exception("Error(Incorrect entered data)!");
                            }
                        }
                    }
                }
                double doubNumber = double.Parse(data);
                sequenceReverser(ref doubNumber, splitSymbol);
                data = doubNumber.ToString();
            }
            else if (dataType == "doubleString")
            {   
                string splitSymbol = "";

                if( isCorrectSymbolChecker(stringArrToCheck[0], letters)==true && isCorrectSymbolChecker(stringArrToCheck[data.Length-1], letters)==true )
                {
                    int notLettersAmount = 0;

                    for(int letterIndex = 1; letterIndex < data.Length-1; letterIndex++)
                    {
                        if(!isCorrectSymbolChecker(stringArrToCheck[letterIndex], letters))
                        {   
                            if(notLettersAmount == 0)
                            {
                                notLettersAmount = 1; 
                                splitSymbol = stringArrToCheck[letterIndex];
                                continue;
                            }
                            else
                            {
                                throw new Exception("Error(Incorrect entered data)!");
                            }
                        }
                    }

                    string[] dataArr = data.Split(splitSymbol); 
                    sequenceReverser(ref dataArr[0]);
                    sequenceReverser(ref dataArr[1]);
                    data = dataArr[0] + splitSymbol + dataArr[1];
                }
                else
                {
                    throw new Exception("Error(Incorrect entered data)!");
                }
            }
        }


        static void sequenceReverser(ref int data, int index=0)
        {
            string tempStringData = data.ToString();
            string[] tempData = stringToArray(tempStringData);
            int stringDataLength = tempData.Length;

            if( index < stringDataLength / 2 ) 
            {
                string firstTempLetter = tempData[index];
                tempData[index] = tempData[stringDataLength - index - 1];
                tempData[stringDataLength - index - 1] = firstTempLetter;
                data = int.Parse(arrayToString(tempData));
                index++;
                sequenceReverser(ref data, index);
            }
        }
        static void sequenceReverser(ref string data, int index=0)
        {
            string[] tempData = stringToArray(data);
            int stringDataLength = tempData.Length;
            if( index < stringDataLength / 2) 
            {
                string firstTempLetter = tempData[index];
                tempData[index] = tempData[stringDataLength - index - 1];
                tempData[stringDataLength - index - 1] = firstTempLetter;
                data = arrayToString(tempData);
                index++;
                sequenceReverser(ref data, index);
            }
        }
        static void sequenceReverser(ref double data, string splitSymbol)
        {
            string tempData = data.ToString();
            string[] tempDataArr = tempData.Split(splitSymbol);
            sequenceReverser(ref tempDataArr[0]);
            sequenceReverser(ref tempDataArr[1]);

            data = double.Parse(tempDataArr[0] + splitSymbol + tempDataArr[1]);
        }




        static string[] stringToArray(string str)
        {
            string[] result = new string[str.Length];
            for (int index = 0; index < str.Length; index++)
            {
                result[index] = str[index].ToString();
            }
            return result;
        }
        static string arrayToString(string[] arr)
        {
            string result = new string("");
            for (int index = 0; index < arr.Length; index++)
            {
                result += arr[index];
            }
            return result;
        }
    }
}