using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampSecurity.Tests
{
    [TestClass]
    public class CustomEncryptionTests
    {
        [TestMethod]
        public void TestCustomEncryptionShortString()
        {
            var inputValue = "have a nice day";
            var encodedValue = GetEncryptedValue(inputValue);
            Assert.AreEqual(encodedValue, "hae and via ecy numsp 5 6 10");
        }

        [TestMethod]
        public void TestCustomDecryptionShortString()
        {
            var inputValue = "have a nice day.";
            var encodedValue = GetEncryptedValue(inputValue);
            var decodedValue = GetDecryptedValue(encodedValue);
            Assert.AreEqual(inputValue, decodedValue);
        }

        [TestMethod]
        public void TestCustomEncryptionLongString()
        {
            var inputValue = "if man was meant to stay on the ground god would have given us roots";
            var encodedValue = GetEncryptedValue(inputValue);
            Assert.AreEqual(encodedValue, "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau numsp 3 6 9 14 16 20 22 25 31 34 39 43 48 50");
        }

        [TestMethod]
        public void TestCustomDecryptionLongString()
        {
            var inputValue = "if man was meant to stay on the ground god would have given us roots";
            var encodedValue = GetEncryptedValue(inputValue);
            var decodedValue = GetDecryptedValue(encodedValue);
            Assert.AreEqual(inputValue, decodedValue);
        }

        [TestMethod]
        public void TestCustomEncryptionComplexString()
        {
            var inputValue = "ifman wasnu meanm tosts yothp";
            var encodedValue = GetEncryptedValue(inputValue);
            var decodedValue = GetDecryptedValue(encodedValue);
            Assert.AreEqual(inputValue, decodedValue);
        }

        string GetEncryptedValue(string inputValue)
        {
            Console.WriteLine("Input string: {0}", inputValue);
            Console.WriteLine("Before calling encrypt:{0}", DateTime.Now.ToString("O"));
            var stopwath = new Stopwatch();
            stopwath.Start();
            DateTime startTime = DateTime.Now;
            var encodedValue = CustomEncryption.Encrypt(inputValue);
            stopwath.Stop();
            Console.WriteLine("After  calling encrypt:{0}", DateTime.Now.ToString("O"));
            Console.WriteLine("Ticks taken: {0}", stopwath.ElapsedTicks);
            Console.WriteLine("Milliseconds taken: {0}", (DateTime.Now - startTime).TotalMilliseconds);
            Console.WriteLine("Encoded value: " + encodedValue);
            Console.WriteLine();
            return encodedValue;
        }

        string GetDecryptedValue(string inputValue)
        {
            Console.WriteLine("Decrypt Method");
            Console.WriteLine("Input string: {0}", inputValue);
            Console.WriteLine("Before calling decrypt:{0}", DateTime.Now.ToString("O"));
            var stopwath = new Stopwatch();
            stopwath.Start();
            DateTime time1 = DateTime.Now;
            var decodedValue = CustomEncryption.Decrypt(inputValue);
            stopwath.Stop();
            Console.WriteLine("After  calling decrypt:{0}", DateTime.Now.ToString("O"));
            Console.WriteLine("Ticks taken: {0}", stopwath.ElapsedTicks);
            Console.WriteLine("Milliseconds taken: {0}", (DateTime.Now - time1).TotalMilliseconds);
            Console.WriteLine("Decoded value: " + decodedValue);
            return decodedValue;
        }
    }
}
