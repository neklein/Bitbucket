using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            bool CheckForTrouble = false;
            if (aSmile == true && bSmile == true)
            {
                CheckForTrouble = true;
            }
            if (aSmile == false && bSmile == false)
            {
                CheckForTrouble = true;
            }
            return CheckForTrouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool SleepIn = false;
            if (isWeekday == false)
            {
                SleepIn = true;
            }
            if (isVacation == true)
            {
                SleepIn = true;
            }
            return SleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int Sum = a + b;
            if (a == b)
            {
                Sum = 2 * (a + b);
            }
            return Sum;
        }
        
        public int Diff21(int n)
        {
            int Diff = Math.Abs(n - 21);
            if (n > 21)
            {
                Diff = 2 * (n - 21);
            }
            return Diff;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool Trouble = false;
            if (isTalking == true && hour < 7)
            {
                Trouble = true;
            }
            if (isTalking == true && hour > 20)
            {
                Trouble = true;
            }
            return Trouble;
        }
        
        public bool Makes10(int a, int b)
        {
            bool Is10 = true;
            if ( !(a == 10 || b == 10 || a + b == 10))
            {
                Is10 = false;
            }
            return Is10;
        }
        
        public bool NearHundred(int n)
        {
            bool Hundred = true;
            int HowClose100 = Math.Abs(n - 100);
            int HowClose200 = Math.Abs(n - 200);
            if (!(HowClose100 <= 10 || HowClose200 <= 10))
            {
                Hundred = false;
            }
            return Hundred;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool IsPosNeg = true;
            if (!(a < 0 || b < 0))
            {
                IsPosNeg = false;

            }
            return IsPosNeg;
        }
        
        public string NotString(string s)
        {
            string s1 = "not " + s;
            if (s.Length >= 3 && s.Substring(0, 3) == "not")
            {
                s1 = s;
            }
            return s1;
        }
        
        public string MissingChar(string str, int n)
        {
            string WithoutChar = str.Remove(n, 1);
            return WithoutChar;
        }
        
        public string FrontBack(string str)
        {
            string IsFrontAndBack = str;
            if (str.Length > 2)
            {
                string str1 = str.Substring(0, 1);
                string str2 = str.Substring((str.Length - 1), 1);
                string str3 = str.Substring(1, str.Length - 2);
                IsFrontAndBack = str2 + str3 + str1;
            }
            if(str.Length == 2)
            {
                string str1 = str.Substring(0, 1);
                string str2 = str.Substring(1, 1);
                IsFrontAndBack = str2 + str1;
            }
            return IsFrontAndBack;
        }
        
        public string Front3(string str)
        {
            string StrFront = str + str + str;
            if (str.Length > 3)
            {
                StrFront = str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
            }
            return StrFront;
        }
        
        public string BackAround(string str)
        {
            string FrontAndBack = str.Substring(str.Length - 1, 1) + str + str.Substring(str.Length - 1, 1);
            return FrontAndBack;
        }
        
        public bool Multiple3or5(int number)
        {
            bool MultipleCheck = true;
            if (!(number % 3 == 0 || number % 5 == 0))
            {
                MultipleCheck = false;
            }
            return MultipleCheck;
        }
        
        public bool StartHi(string str)
        {
            bool IsItHi = false;
            if (str.Length > 2 && str.Substring(0, 3) == "hi ")
            {
                IsItHi = true;

            }
            if (str.Length > 2 && str.Substring(0, 3) == "hi,")
            {
                IsItHi = true;
            }
            if (str.Length == 2 && str.Substring(0,2) == "hi")
            {
                IsItHi = true;
            }
            return IsItHi;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            bool HotAndCold = false;
            if (temp1 < 0 && temp2 > 100)
            {
                HotAndCold = true;
            }
            if(temp1 > 100 && temp2 < 0)
            {
                HotAndCold = true;
            }
            return HotAndCold;
        }
        
        public bool Between10and20(int a, int b)
        {
            bool IsBetween = true;
            if (!(a <= 20 && a >= 10 || b <= 20 && b >= 10))
            {
                IsBetween = false;
            }
            return IsBetween;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool DoesHaveTeen = true;
            if (!(a <= 19 && a >= 13 || b <= 19 && b >= 13 || c <= 19 && c >= 13))
            {
                DoesHaveTeen = false;
            }
            return DoesHaveTeen;

        }

        public bool SoAlone(int a, int b)
        {
           bool IsAlone = true;
            if (!(a <= 19 && a >= 13 || b <= 19 && b >= 13))
            {
                IsAlone = false;
            }
            if (a <= 19 && a >= 13 && b <= 19 && b >= 13)
            {
                IsAlone = false;
            }
            return IsAlone;

        }

        public string RemoveDel(string str)
        {
            string str1 = str;
            if (str.Substring(1,3) == "del")
            {
                str1 = str.Remove(1, 3);
            }
            return str1;
        }
        
        public bool IxStart(string str)
        {
            bool DoesHaveIx = false;
            if (str.Substring(1,2) == "ix")
            {
                DoesHaveIx = true;
            }
            return DoesHaveIx;
        }
        
        public string StartOz(string str)
        {
            string HasOz = "";
            
            if (str.Substring(0, 1) == "o")
            {
                HasOz = "o";
            }
            if (str.Length > 1)
            {
                if (str.Substring(1, 1) == "z")
                {
                    HasOz = "z";
                }

                if (str.Substring(0, 2) == "oz")
                {
                    HasOz = "oz";
                }
            }
            return HasOz;
        }

        public int Max(int a, int b, int c)
        {
            int MaxOfNumbers = 0;
            if (a > b && a > c)
            {
                MaxOfNumbers = a;
            }
            if (b > a && b > c)
            {
                MaxOfNumbers = b;
            }
            if (c > b && c > a)
            {
                MaxOfNumbers = c;
            }
            return MaxOfNumbers;
        }

        public int Closer(int a, int b)
        {
            int OneIsCloser = 0;
            int AbsA = Math.Abs(a - 10);
            int AbsB = Math.Abs(b - 10);
            if (AbsA < AbsB)
            {
                OneIsCloser = a;
            }
            if(AbsA > AbsB)
            {
                OneIsCloser = b;
            }
            return OneIsCloser;
        }
        
        public bool GotE(string str)
        {
            int CountEs = 0;
            bool HowManyEs = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    CountEs++;
                }
                if (CountEs >= 1 && CountEs <= 3)
                {
                    HowManyEs = true;
                }
                else
                {
                    HowManyEs = false;
                }

            }
            return HowManyEs;

        }
        
        public string EndUp(string str)
        {
            string FirstPart = "";
            string UpperCase = str.ToUpper();
            if(str.Length > 3)
            {
                FirstPart = str.Substring(0, str.Length - 3);
                string LastPart = str.Substring(str.Length - 3, 3);
                UpperCase = LastPart.ToUpper();
            }
            return FirstPart + UpperCase;
        }
        
        public string EveryNth(string str, int n)
        {
            string str1 = str.Substring(0,1);
            for (int i = 0; i < str.Length - n; i += n)
            {
                str1 += str[i + n];
            }
            return str1;
        }
    }
}
