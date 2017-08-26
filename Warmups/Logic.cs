using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool IsGreatParty = false;
            if (cigars >= 40 && cigars <= 60 && isWeekend == false)
            {
                IsGreatParty = true;
            }
            if (cigars >= 40 && isWeekend == true)
            {
                IsGreatParty = true;
            }
            return IsGreatParty;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int GetTable = 0;
            if (!(yourStyle <= 2 || dateStyle <= 2))
            {
                if (yourStyle > 7)
                {
                    GetTable = 2;
                }
                if (dateStyle > 7)
                {
                    GetTable = 2;
                }
                else
                {
                    GetTable = 1;
                }
            }
            return GetTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool CanPlayOutside = false;
            if(temp >= 60 && temp <= 100 && isSummer == true)
            {
                CanPlayOutside = true;
            }
            if (temp >= 60 && temp <= 90 && isSummer == false)
            {
                CanPlayOutside = true;
            }
            return CanPlayOutside;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int TicketSize = 0;
            if(speed >= 61 && speed <= 80 && isBirthday == false)
            {
                TicketSize = 1;
            }
            if(speed >= 81 && isBirthday == false)
            {
                TicketSize = 2;
            }
            if(speed >= 66 && speed <= 85 && isBirthday == true)
            {
                TicketSize = 1;

            }
            if(speed >= 86 && isBirthday == true)
            {
                TicketSize = 2;
            }
            return TicketSize;

        }
        
        public int SkipSum(int a, int b)
        {
            int GetSum = a + b;
            int GetSum1 = GetSum;
            if(GetSum >= 10 && GetSum <= 19)
            {
                GetSum1 = 20;
            }
            return GetSum1;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string WhenRing = "off";
            if(day > 0 && day < 6 && vacation == false)
            {
                WhenRing = "7:00";
            }
            if (day == 0 && vacation == false)
            {
                WhenRing = "10:00";
            }
            if (day == 6 && vacation == false)
            {
                 WhenRing = "10:00";

            }
            if (day > 0 && day < 6 && vacation == true)
            {
                WhenRing = "10:00";
            }
            return WhenRing;
        }
        
        public bool LoveSix(int a, int b)
        {
            bool IsSix = false;
            if (a == 6)
            {
                IsSix = true;
            }
            if (b == 6)
            {
                IsSix = true;
            }
            if (!(a == 6 || b == 6))
            {
                if (a + b == 6)
                {
                    IsSix = true;
                }
                if (a - b == 6)
                {
                    IsSix = true;
                }
            }
            return IsSix;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool CheckRange = false;
            if (n >= 1 && n <= 10 && outsideMode == false)
            {
                CheckRange = true;
            }
            if (n <= 1 && outsideMode == true)
            {
                CheckRange = true;
            }
            if (n >= 10 && outsideMode == true)
            {
                CheckRange = true;
            }
            return CheckRange;
        }
        
        public bool SpecialEleven(int n)
        {
            bool IsEleven = false;
            if (n % 11 == 0)
            {
                IsEleven = true;
            }
            if (n % 11 == 1)
            {
                IsEleven = true;
            }
            return IsEleven;
        }
        
        public bool Mod20(int n)
        {
            bool IsMod = false;
            if (n % 20 == 1)
            {
                IsMod = true;
            }
            if (n % 20 == 2)
            {
                IsMod = true;
            }
            return IsMod;
        }
        
        public bool Mod35(int n)
        {
            bool IsMod = false;
            if(n % 3 == 0 && n % 5 != 0)
            {
                IsMod = true;
            }
            if (n % 5 == 0 && n % 3 != 0)
            {
                IsMod = true;
            }
            return IsMod;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool WillAnswer = false;
            if (isAsleep == false)
            {
                if (isMorning == true && isMom == true)
                {
                    WillAnswer = true;
                }
                if (isMorning == true && isMom == false)
                {
                    WillAnswer = false;
                }
                if (isMorning == false)
                {
                    WillAnswer = true;
                }
            }
            return WillAnswer;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {

            bool IfPossible = true;
            if(!(a + b == c || a + c == b || b + c == a))
            {
                IfPossible = false;
            }
            return IfPossible;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool CheckOrder = false;
            if (bOk == true && c > b)
            {
                CheckOrder = true;
            }
            if(bOk == false && c > b && b > a)
            {
                CheckOrder = true;
            }
            return CheckOrder;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool CheckOrder = false;
            if (b > a && c > b)
            {
                CheckOrder = true;
            }
            if (equalOk == true)
            {
                if (b == a && c == b)
                {
                    CheckOrder = true;
                }
                if (b == a && c > b)
                {
                    CheckOrder = true;
                }
                if (b > a && c == b)
                {
                    CheckOrder = true;
                }
            }
            return CheckOrder;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool CheckDigit = true;
            string strA = $"{a}";
            string strB = $"{b}";
            string strC = $"{c}";

            string ABC = strA.Substring(strA.Length - 1, 1) + strB.Substring(strB.Length - 1, 1) + strC.Substring(strC.Length - 1, 1);

            for (int i = 0; i < ABC.Length - 2; i++)
            {
                if(!(ABC[i] == ABC[i + 1] || ABC [i] == ABC[i + 2] || ABC[i + 1] == ABC[i + 2]))
                {
                    CheckDigit = false;
                    break;
                }
            }
            return CheckDigit;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int Sum = 0;
            if (noDoubles == true && die1 == die2)
            {
                die1++;
                if (die1 == 7)
                {
                    die1 = 1;
                }
            }
            return Sum = die1 + die2;
        }

    }
}
