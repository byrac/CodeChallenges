using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests
{
    [TestClass]
    public class ArraySumEqualizerTests
    {
        [TestMethod]
        public void MustReturnValidIndex()
        {
            int[] numbers = new int[] { 11, 20, 8, 31 };

            var initTime = DateTime.Now;
            Console.WriteLine("Finding the middle index. {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);

            var middleIndex = ArraySumEqualizer.FindMiddleIndexBySum(numbers);

            Console.WriteLine("Finished search. Time: {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);
            Console.WriteLine("Time taken in milli seconds: " + (DateTime.Now - initTime).TotalMilliseconds);
            Console.WriteLine("Index (Array with 1 base index) is : " + middleIndex);

            if (middleIndex > -1)
            {
                Console.WriteLine("Element is :" + numbers[middleIndex-1]);
            }
            Assert.IsTrue(middleIndex > -1);
        }

        [TestMethod]
        public void MustReturnInValidIndex()
        {
            int[] numbers = new int[] { 1, 1, 1, 2, 3, 7, 11, 2, 5, 6, 1, 6, 31, 31 };

            var initTime = DateTime.Now;
            Console.WriteLine("Finding the middle index. {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);

            var middleIndex = ArraySumEqualizer.FindMiddleIndexBySum(numbers);

            Console.WriteLine("Finished search. Time: {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);
            Console.WriteLine("Time taken in milli seconds: " + (DateTime.Now - initTime).TotalMilliseconds);
            Console.WriteLine("Index is : " + middleIndex);

            if (middleIndex > -1)
            {
                Console.WriteLine("Element is: " + numbers[middleIndex-1]);
            }
            Assert.IsTrue(middleIndex == -1);
        }

        [TestMethod]
        public void PerformanceTestTimes()
        {
            PerformanceTest(10);
            PerformanceTest(100);
            PerformanceTest(1000);
            PerformanceTest(10000);
            PerformanceTest(100000);
        }

        public void PerformanceTest(int arraySize)
        {
            Console.WriteLine("Array size. {0}", arraySize);

            int[] randomNumbers = new int[arraySize];
            Random rnd = new Random(1);

            for (int i = 0; i < arraySize; i++)
            {
                randomNumbers[i] =  rnd.Next(20000);
            }

            var initTime = DateTime.Now;
            Console.WriteLine("Finding the middle index. {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);

            var middleIndex = ArraySumEqualizer.FindMiddleIndexBySum(randomNumbers);

            if (middleIndex == -1)
            {
                Console.WriteLine("No such index found.");
            }
            else
            {
                Console.WriteLine("Sum Equalizer Index is : " + middleIndex);
                Console.WriteLine("Value is : " + randomNumbers[middleIndex-1]);
            }

            Console.WriteLine("Finished search. Time: {0:MM/dd/yy H:mm:ss fff}", DateTime.Now);
            Console.WriteLine("Time taken in milli seconds: " + (DateTime.Now - initTime).TotalMilliseconds);
            Console.WriteLine();
        }
    }
}