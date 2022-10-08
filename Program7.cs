using System;

// Malikov Vadym; Group: PD-22; Option: 11

namespace Lab7
{
    class Program
    {
        public static int Main() 
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            int userEnteredNumber = 0;
            System.Console.WriteLine("Введіть число: ");
            try
            {
                userEnteredNumber = int.Parse(System.Console.ReadLine());
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            int[] myArr = numberSeparation(userEnteredNumber);
            MyList<int> list = new MyList<int>();
            for(int myArrIndex = 0; myArrIndex < myArr.Length; myArrIndex++)
            {
                list.addElem(myArr[myArrIndex]);
            }
            MyList<int>.printList(list);


            int listPresentLength = list.getList().Length;
            for( int numberIndex = 0; numberIndex < listPresentLength; numberIndex++ )
            {
                int numbersAmount = 0;
                int[] passedArrPart = new int[numberIndex];
                for( int passedPartOfListNumberIndex = 0; passedPartOfListNumberIndex < numberIndex; passedPartOfListNumberIndex++ )
                {
                    passedArrPart[passedPartOfListNumberIndex] = list.getElem(passedPartOfListNumberIndex);
                }
                if(uniquenessCheck(list.getElem(numberIndex), passedArrPart))
                {
                    for( int listNumberIndex = 0; listNumberIndex < listPresentLength; listNumberIndex++ )
                    {
                        if(list.getElem(numberIndex) == list.getElem(listNumberIndex))
                        {
                            numbersAmount++;
                        }
                    }

                    System.Console.Write($"Кількість цифр '{list.getElem(numberIndex)}' - {numbersAmount}\n");
                }
            }
            System.Console.WriteLine();

            return 0;
        }


        static int[] numberSeparation(int number)
        {
            int digitsAmount = number.ToString().Length;
            int digitIndex = digitsAmount-1;
            int[] resultNumbersArr = new int[digitsAmount];

            while(number > 0)
            {
                int tempNumber = number % 10;
                resultNumbersArr[digitIndex] = tempNumber;
                number = (number - tempNumber) / 10;
                digitIndex--;
            }
            return resultNumbersArr;
        }


        static bool uniquenessCheck(int number, int[] numbers)
        {
            bool isUnique = true;

            for(int numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                if( number == numbers[numberIndex] )
                {
                    isUnique = false;
                }
            }

            return isUnique;
        }
    }


    

    class MyList<myListType>
    {
        private myListType[] list;


        public MyList(){
            this.list = new myListType[0];
        }

        public MyList(myListType[] arr)
        {
            int myListLength = arr.Length;
            this.list = new myListType[myListLength];

            for(int arrElemIndex = 0; arrElemIndex < myListLength; arrElemIndex++)
            {
                this.list[arrElemIndex] = arr[arrElemIndex];
            }
        }


        public myListType[] getList()
        {
            return list;
        }

        public myListType getElem(int elemIndex)
        {
            try
            {
                return this.getList()[elemIndex];
            }
            catch
            {
                return this.getList()[0];
            }
        }

        public myListType deleteLastElem() 
        {
            myListType[] arrFromList = this.getList();
            int newListLength = arrFromList.Length-1;
            myListType[] newArr = new myListType[newListLength];
            for( int elemIndex = 0; elemIndex < newListLength; elemIndex++ )
            {
                newArr[elemIndex] = arrFromList[elemIndex];
            }
            this.setList(newArr);
            return arrFromList[newListLength];
        }

        public void setList(myListType[] arr)
        {
            this.list = arr;
        }

        public void addElem(myListType elem)
        {
            myListType[] arrFromList = this.getList();
            int lastListLength = arrFromList.Length;
            int newListLength = lastListLength+1;
            myListType[] newArr = new myListType[newListLength];

            for( int elemIndex = 0; elemIndex < lastListLength; elemIndex++)
            {
                newArr[elemIndex] = arrFromList[elemIndex];
            }
            newArr[newListLength-1] = elem;

            this.setList(newArr);
        }


        public static void printList(MyList<myListType> listToPrint)
        {
            myListType[] arrFromListToPrint = listToPrint.getList();

            for( int index = 0; index < arrFromListToPrint.Length; index++ )
            {
                System.Console.Write(arrFromListToPrint[index] + " ");
            }
            System.Console.WriteLine();
        }
    }
}