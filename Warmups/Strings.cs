using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return (a + b) + (b + a);
        }

        public string MakeTags(string tag, string content)
        {
            string partstr;
            partstr = "<" + tag + ">";
            partstr = partstr + content + "</" + tag + ">";
            return partstr;
        }

        public string InsertWord(string container, string word) {
            string str1 = container.Remove(2);
            string str2 = container.Remove(0, 2);
            string n = str1 + word + str2;
            
            return n;
        }

        public string MultipleEndings(string str)
        {
            string str1 = str;
            if (str.Length > 2)
            {
                str1 = str.Remove(0, 3);
            }

            string str2 = string.Join(str1, str1, str1);
            return str2;
        }

        public string FirstHalf(string str)
        {
            string str1 = str;
            if (str.Length == 6)
            {
                str1 = str.Remove(3);
            }
            if(str.Length == 10)
            {
                str1 = str.Remove(5);
            }
            return str1;
        }

        public string TrimOne(string str)
        {
            int StrLngth = str.Length - 1;
            string str1 = str.Remove(StrLngth);
            string str2 = str1.Remove(0,1);
            
            return str2;
        }

        public string LongInMiddle(string a, string b)
        {
            string str = a;
            if (a.Length > b.Length)
            {
                str = b + a + b;
            }
            if (a.Length < b.Length)
            {
                str = a + b + a;
            }
            return str;
        }

        public string RotateLeft2(string str)
        {
            //str1 contains first 2 elements; str2 contains the rest.
            //Then those strings are added together with str2 coming first

            string str1 = str;
            string str2 = str1;
            string str3 = str2;
            if (str.Length > 3) 
            {
                str1 = str.Remove(2);
                str2 = str.Remove(0, 2);
                str3 = str2 + str1;
            }
            return str3;
        }

        public string RotateRight2(string str)
        {

            string str1 = str;
            if (str.Length > 2)
            {
                int StrIndex = str.Length - 2;
                string str2 = str.Remove(StrIndex);
                string str3 = str.Remove(0, StrIndex);
                str1 = str3 + str2;
                    }
            return str1;
        }

        public string TakeOne(string str, bool fromFront)
        {
            //If we take the first letter, the answer is true
            string str1 = str;
            int StrIndex = str.Length - 1;
            if (fromFront == true)
            {
                str1 = str.Remove(1);
            }
            if (fromFront == false)
            {
                str1 = str.Remove(0, StrIndex);
            }
            return str1;
        }

        public string MiddleTwo(string str)
        {
            //I should do something with str.Length
            int StrIndex2 = (str.Length / 2) - 1;
            ;
            string str1 = str.Substring(StrIndex2, 2);
            return str1;
        }

        public bool EndsWithLy(string str)
        {
            //We have a bool and are testing for two particular chars within a string. 
            //Try string.Contains
            bool Ly = str.Contains("ly");
            return Ly;
        }

        public string FrontAndBack(string str, int n)
        {
            //Use str.Length with n?
            int n1 = n - 1;
            int StrLngth = str.Length - n;
            string str1 = str.Substring(0, n);
            string str2 = str.Substring(StrLngth);
            string str3 = str1 + str2;
            return str3;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            //use Substrings to find
            string str1 = str;
            if (n < (str.Length - 1))
            {
                str1 = str.Substring(n, 2);
            }
            else
            {
                str1 = str.Substring(0, 2);
            }
            return str1;
        }

        public bool HasBad(string str)
        {
            //use IndexOf with "xx" to locate if it is in the string
            bool Has = true;
            if (str.IndexOf("bad") > 1)
            {
                Has = false;
            }
            if (str.IndexOf("bad") == -1)
            {
                Has = false;
            }           
            return Has;
        }

        public string AtFirst(string str)
        {
            string str1 = str;
            if (str.Length >= 2)
            {
                str1 = str.Substring(0, 2);
            }
            if (str.Length == 1)
            {
                str1 = str.Substring(0, 1) + "@";
            }
            if (str.Length == 0)
            {
                str1 = "@@";
            }
            return str1;
        }

        public string LastChars(string a, string b)
        {
            string str = a;
            if (!(a.Length > 0 || b.Length > 0))
            {
                str = "@@";
            }
            if (a.Length == 0 && b.Length > 0)
            {
                int bLngth = b.Length - 1;
                str = "@" + b.Substring(bLngth, 1);
            }
            if (b.Length == 0 && a.Length > 0)
            {
                str = a.Substring(0, 1) + "@";
            }
            if (a.Length > 0 && b.Length > 0)
            {
                int bLngth = b.Length - 1;
                str = a.Substring(0, 1) + b.Substring(bLngth, 1);
            }
            return str;
        }

        public string ConCat(string a, string b)
        {
            string str = a + b;
            
            if (a.Length > 0 && b.Length > 0)
            {
                int aLngth = a.Length - 1;
                string aLastChar = a.Substring(aLngth, 1);
                string bFirstChar = b.Substring(0, 1);
                if (aLastChar == bFirstChar)
                {
                    string str1 = a.Substring(0, aLngth);
                    str = str1 + b;
                }
            }
            return str;
        }

        public string SwapLast(string str)
        {
            string str4 = str;
            if (str.Length >= 2)
            {
                int strLast = str.Length - 1;
                int strSecondToLast = str.Length - 2;
                string str1 = str.Substring(0, strSecondToLast);
                string str2 = str.Substring(strSecondToLast, 1);
                string str3 = str.Substring(strLast, 1);
                str4 = str1 + str3 + str2;
            }
            return str4;
        }

        public bool FrontAgain(string str)
        {
            //create two new strings; 1 has the first two chars, the other the last two
            bool Match = false;
            string str1 = str.Substring(0, 2);
            int LastChars = str.Length - 2;
            string str2 = str.Substring(LastChars, 2);
            if (str1 == str2)
            {
                Match = true;
            }
            return Match;
        }

        public string MinCat(string a, string b)
        {
            string str = a + b;
            if (a.Length != b.Length)
            {
                if (a.Length > b.Length)
                {
                    int Difference = a.Length - b.Length;
                    string str1 = a.Substring(Difference);
                    str = str1 + b;
                }
                if(b.Length > a.Length)
                {
                    int Difference = b.Length - a.Length;
                    string str1 = b.Substring(Difference);
                    str = a + str1;
                }
                
            }
            return str;
        }

        public string TweakFront(string str)
        {
            string str5 = str;
            if (str.Length > 1)
            {
                string str4 = str.Substring(2);
                string str2 = "";
                string str3 = "";

                if (str.Substring(0, 1) == "a")
                {
                    str2 = str.Substring(0, 1);
                                     
                }
                if (str.Substring(1, 1) == "b")
                {
                    str3 = str.Substring(1, 1);

                }
                str5 = str2 + str3 + str4;
            }
            return str5;
        }

        public string StripX(string str)
        {
            //use if else;
            //use Substring or Remove along with Length to check the first and last characters

            string str4 = str;
            if (str.Length > 1)
            {
                int StrLngth = str.Length - 1;
                
                if (str.Substring(0,1) == "x")
                {
                    str4 = str.Substring(1);
                }
                if (str.Substring(StrLngth, 1) == "x")
                {
                    str4 = str.Substring(0, StrLngth);
                }
                if((str.Substring(0, 1) == "x") && (str.Substring(StrLngth, 1) == "x"))
                {
                    StrLngth = str.Length - 2;
                    str4 = str.Substring(1, StrLngth);
                }

            }
            if (str.Length == 1)
            {
                if (str.Substring(0, 1) == "x")
                {
                    str4 = "";
                }
            }
            return str4;
        }
    }
}
