namespace CodeChallenge
{
    public class ArraySumEqualizer
    {
        // Finding the index in 1 milli second for 100,000 records.
        public static int FindMiddleIndexBySum(int[] numbers)
        {
            if (numbers.Length == 1) return 1;
            if (numbers.Length == 2) return -1;

            var totalSum = 0;
            var leftSum = 0;

            for (var n = 0; n < numbers.Length; n++)
            {
                totalSum += numbers[n];
            }

            for (var i = 1; i < numbers.Length; i++)
            {
                leftSum += numbers[i-1];

                var rightSum = totalSum - leftSum - numbers[i];

                if (leftSum == rightSum)
                {
                    return i + 1; // i is index in zero based array index.
                }
            }
            return -1;
        }
    }
}
