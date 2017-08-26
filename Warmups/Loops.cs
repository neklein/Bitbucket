using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            //starting with a loop
            string str1 = "";
            
            for (int i = 0; i < n; i++)
            {
                str1 += str;
            }
            
            return str1;
        }

        public string FrontTimes(string str, int n)
        {
            string str1 = "";
            for (int i = 0; i < n; i++)
            {
                if (str.Length <= 3)
                {
                    str1 += str;
                }
                else
                {
                    string str2 = str.Substring(0, 3);
                    str1 += str2;
                }
            }
            return str1;
        }

        public int CountXX(string str)
        {

            int xx = 0;
            for(int i = 0; i < str.Length; i++)
            {
                i = str.IndexOf("xx", i);

                if (i == -1)
                {
                    break;
                }

                else
                {
                    xx++;
                }

            }
            return xx;
        }
            public bool DoubleX(string str)
        {
            bool TwoXes = false;
            int Count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int XX = str.IndexOf("xx", i);
                i = str.IndexOf("x", i);
                if (XX != i)
                {
                    break;
                }
                if (i == -1)
                {
                    break;
                }
                if (XX == i)
                {
                    TwoXes = true;
                    break;
                }              
            }
            return TwoXes;
        }

        public string EveryOther(string str)
        {
            string str1 = "";
            for (int i = 0; i  < str.Length; i = i + 2)
            {
                str1 += str[i];
            }
            return str1;
        }

        public string StringSplosion(string str)
        {
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                str1 += str.Substring(0, (i+1));
            }
            return str1;
        }

        public int CountLast2(string str)
        {   
            //Declare a variable to hold the count of strings that match the last 2
            //Use a loop to count through the string
            //Compare Substrings
            int Count = 0;
            for (int i = 0; i < (str.Length - 2); i++)
            {   
              
                int Last2 = str.Length - 2;
                string str1 = str.Substring(i, 2);
                string str2 = str.Substring(Last2, 2);
                if (str1 == str2)
                {
                    Count++;
                }
            }
            return Count;
        }

        public int Count9(int[] numbers)
        {
            int Counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    Counter++;
                }
            }
            return Counter;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool Count9 = false;
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    Count9 = true;
                }
            }
            return Count9;
        }

        public bool Array123(int[] numbers)
        {
            //Starting with a bool. 
            //Trying an if method to find 1 or 2 or 3
            //What about a new array of {1, 2, 3}?
            bool Count123 = false;
            //I initialized a couple of arrays hoping they will be equivalent
            //not working - see loop
           // int[] Count = new int[3];
            //int[] Count1 = new int[] { 1, 2, 3 };
            //Then loop through the array looking at each element

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                
                
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    Count123 = true;                    
                }
               //Even with the debugging console, these appear to be equal.
                //Yet, the "if" statement says "false"
            }
             
            return Count123;
        }

        public int SubStringMatch(string a, string b)
        {
            //First initialize and int to count the times the substrings equate
            int Counter = 0;

            //run a loop to look through each string comparing them
            for (int i = 0; i < b.Length - 1; i++)
            {
                //create two substrings
                string ASubstring = a.Substring((i), 2);
                string BSubstring = b.Substring((i), 2);
                //Compare with "if"
                if (ASubstring == BSubstring)
                {
                    Counter++;
                }
                //not sure how to get it to work if strings are not the same length
      
            }
            return Counter;
        }

        public string StringX(string str)
        {

            //Since I'm not checking the first or last items, I will just eliminate them outright
            string StringToCheck = str.Substring(1, (str.Length - 2));
            string FirstChar = str.Substring(0, 1);
            string LastChar = str.Substring((str.Length - 1), 1);

            //I will loop through, but won't look at the first or last elements
            for (int i = 0; i < StringToCheck.Length; i++)
            {
                //use an if to cycle through cases in which there are no "x"s
                if (StringToCheck[i] != 'x')
                {
                    FirstChar += StringToCheck[i];
                }
            }
            return FirstChar + LastChar;
        }

        public string AltPairs(string str)
        {
            int StrLngth = str.Length;
            int ModulusOf4 = str.Length % 4;
            int MultiplesOf4 = (str.Length - ModulusOf4) / 4;

            string str2 = "";
            string str3 = "";
          
            for (int i = 0; i <= (MultiplesOf4); i++)
            {
                //I think I need an if statement for when i++ ends
                if ((4*i) == (StrLngth - 1))
                {
                    str3 = str.Substring(StrLngth - 1);
                    break;
                }
                if((4*i) == str.Length)
                {
                    break;
                }

                str2 += str.Substring((4*i), 2);
                
            }
            return str2 + str3;
 
        }

        public string DoNotYak(string str)
        {
            string NoYak = "";
            
            for (int i = 0; i < str.Length; i++)
            {
                int IndexYak = str.IndexOf("yak");
                if (IndexYak == -1)
                {
                    NoYak = str;
                }
                else
                {
                    NoYak = str.Remove(IndexYak, 3);
                }
            }
            return NoYak;
        }

        public int Array667(int[] numbers)
        {
            int Count = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    Count++;
                }
                if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    Count++;
                }
            }
            return Count;
        }

        public bool NoTriples(int[] numbers)
        {
            bool TripleCheck = false;
            if (numbers.Length <= 2)
            {

                TripleCheck = true;
            }
            if (numbers.Length > 2)
            {
                for (int i = 0; i < numbers.Length - 2; i++)
                {

                    if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                    {
                        TripleCheck = false;
                        break;
                    }
                    else
                    {
                        TripleCheck = true;
                    }
                }

            }
            return TripleCheck;

        }

        public bool Pattern51(int[] numbers)
        {
            bool Pattern = false;
            for(int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers [i + 1] == numbers[i] + 5 && numbers[i + 2] == numbers[i] - 1)
                {
                    Pattern = true;
                    break;
                }
            }
            return Pattern;
        }

    }
}
