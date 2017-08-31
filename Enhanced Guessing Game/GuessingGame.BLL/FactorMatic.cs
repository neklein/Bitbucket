namespace Factorizor.BLL
{
    public class FactorMatic
    {
        private readonly int baseNumber;
        private readonly int[] factors;
        private readonly bool isPrime;
        private readonly bool isPerfect;

        public FactorMatic(int number)
        {
            baseNumber = number;
            int numOfFactors = 0;
            int SumOfFactors = -baseNumber;

            for (int i = 1; i <= baseNumber; i++)
            {
                if (baseNumber % i == 0)
                {
                    numOfFactors++;
                    SumOfFactors += i;

                }

            }
            if (numOfFactors == 2) isPrime = true;
            if (SumOfFactors == baseNumber) isPerfect = true;

            int counter = 0;
            factors = new int[numOfFactors];

            for (int i = 1; i <= baseNumber; i++)
            {
                if (baseNumber % 2 == 0)
                    factors[counter++] = i;
            }
        }

        public int [] getFactors()
        {
            return factors;
        }

        public bool IsPrime()
        {
            return isPrime;
        }

        public bool IsPerfect()
        {
            return isPerfect;   
        }
    }

}