using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool Isit6 = true;
            if (!(numbers [0] == 6 || numbers[numbers.Length - 1] == 6))
            {
                Isit6 = false;
            }
            return Isit6;
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool AreSame = false;
            if (numbers[0] == numbers[numbers.Length - 1])
            {
                AreSame = true;
            }
            return AreSame;
        }
        public int[] MakePi(int n)
        {
            //tough one - found a solution on stackoverflow
            //first I need Pi(self evident)
            double pi = Math.PI;

            //Pi is the form of a double, so I want to get it into a string to remove the "." in 3.14
            string str = pi.ToString().Remove(1, 1);

            //next I convert to an array of characters because I can convert a character to a string
            //I can take that mini string and parse it to an integer (since I am dealing with pi)

            char[] chararray = str.ToCharArray();
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                //I tried to set numbers[i] = str[i], but it gave an odd value - why?
                numbers[i] = int.Parse(chararray[i].ToString());
            }
            return numbers;

        
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            bool CompareEnd = true;
            if (!(a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]))
            {
                CompareEnd = false;
            }
            return CompareEnd;
        }
        
        public int Sum(int[] numbers)
        {
            int SumNumbers = 0;
            for (int i = 0; i <numbers.Length; i++)
            {
                SumNumbers += numbers[i];
            }
            return SumNumbers;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] NewNumbers = new int[numbers.Length];
             NewNumbers[NewNumbers.Length - 1] = numbers[0];
            for (int i = 0; i < NewNumbers.Length - 1; i++)
            {
                NewNumbers[i] = numbers[i + 1];
            }
            return NewNumbers;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] NewNumbers = new int[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                NewNumbers[i] = numbers[(numbers.Length - 1) - i];
            }
            return NewNumbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int[] TheHigherOne = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] < numbers[numbers.Length - 1])
                {
                    TheHigherOne[i] = numbers[numbers.Length - 1];
                }
                if (numbers[0] > numbers[numbers.Length - 1])
                {
                    TheHigherOne[i] = numbers[0];
                }
            }
            return TheHigherOne;

        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] MiddleTwo = new int[2];
            MiddleTwo[0] = a[1];
            MiddleTwo[1] = b[1];
            return MiddleTwo;
        }
        
        public bool HasEven(int[] numbers)
        {
            bool CheckForEven = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    CheckForEven = true;
                    break;
                }
            }
            return CheckForEven;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] NewArray = new int[2 * numbers.Length];
            NewArray[NewArray.Length - 1] = numbers[numbers.Length - 1];
            return NewArray;
        }
        
        public bool Double23(int[] numbers)
        {
            bool CheckForNumbers = true;
            int CountTwo = 0;
            int CountThree = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    CountTwo++;
                }
                if (numbers[i] == 3)
                {
                    CountThree++;
                }
            }
            if (!(CountTwo == 2 || CountThree == 2))
            {
                CheckForNumbers = false;
            }
            return CheckForNumbers;
        }

        public int[] Fix23(int[] numbers)
        {
            int[] NewArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                NewArray[i] = numbers[i];
            }
            for (int i = 0; i < numbers.Length - 1; i++)
            { 
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    NewArray[i + 1] = 0;
                }

            }
            return NewArray;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            bool IsUnlucky = true;
            if (!(numbers[0] == 1 && numbers[1] == 3 
                || numbers[1] == 1 && numbers [2] == 3 
                || numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3))
            {
                IsUnlucky = false;
            }
            return IsUnlucky;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] CombinedArray = new int[a.Length + b.Length];
                int[] NewArray = new int[2];
            for (int i = 0; i < a.Length; i++)
            {
                CombinedArray[i] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                CombinedArray[a.Length + i] = b[i];
            }
            NewArray[0] = CombinedArray[0];
            NewArray[1] = CombinedArray[1];
            return NewArray;
        }


    }
}
