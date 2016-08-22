using System;
using System.Collections.Generic;
using System.Text;

namespace CampSecurity
{
    public class CustomEncryption
    {
        public static string Encrypt(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) return "";
            if (inputString.Length == 1) return inputString;

            var spaceIndexes = new StringBuilder("numsp");
            int noOfSpaces = 0;
            var inputCharsWithOutSpaces = new List<char>();

            for (var i = 0; i < inputString.ToCharArray().Length; i++)
            {
                if (inputString[i] == ' ')
                {
                    spaceIndexes.Append(" ");
                    spaceIndexes.Append(i + 1 - noOfSpaces);
                    noOfSpaces++;
                }
                else
                {
                    inputCharsWithOutSpaces.Add(inputString[i]);
                }
            }

            var sqrt = Math.Sqrt(inputCharsWithOutSpaces.Count);
            var rows = (int)Math.Floor(sqrt);
            var cols = (int)Math.Ceiling(sqrt);

            if (rows * cols < inputCharsWithOutSpaces.Count) rows = cols;

            var inputArray = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var index = row * cols + col;

                    if (index < inputCharsWithOutSpaces.Count)
                    {
                        inputArray[row, col] = inputCharsWithOutSpaces[index];
                    }
                }
            }

            var encodedChars = new List<char>();

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (inputArray[row, col] != '\0')
                    {
                        encodedChars.Add(inputArray[row, col]);
                    }
                }
                encodedChars.Add(' ');
            }

            return string.Join("", encodedChars) + (spaceIndexes.Length == 5 ? "" : spaceIndexes.ToString());
        }

        public static string Decrypt(string encryptedValue)
        {
            if (string.IsNullOrWhiteSpace(encryptedValue)) return "";
            if (encryptedValue.Length == 1) return encryptedValue;

            string[] spaceIndexes = null;
            string encryptedSentence;
            int rows = 0;
            int cols = 0;
            int seperatorIndex = encryptedValue.LastIndexOf("numsp", StringComparison.Ordinal);

            if (seperatorIndex == -1)
            {
                encryptedSentence = encryptedValue;
            }
            else
            {
                encryptedSentence = encryptedValue.Substring(0, seperatorIndex - 1);
                spaceIndexes = encryptedValue.Substring(seperatorIndex + 6).Split(' ');
            }

            // Finding rows and cols in the array.
            foreach (char ch in encryptedSentence)
            {
                if (ch != ' ')
                {
                    if (cols == 0) rows++;
                }
                else
                {
                    cols++;
                }
            }

            cols = cols + 1;

            var inputArray = new char[rows, cols];
            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < encryptedSentence.Length; i++)
            {
                if (encryptedSentence[i] != ' ')
                {
                    inputArray[rowIndex, colIndex] = encryptedSentence[i];
                    rowIndex++;
                }
                else
                {
                    colIndex++;
                    rowIndex = 0;
                }
            }

            var decodedChars = new List<char>();

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (inputArray[row, col] != '\0')
                    {
                        decodedChars.Add(inputArray[row, col]);
                    }
                }
            }

            if (spaceIndexes != null)
            {
                for (var i = 0; i < spaceIndexes.Length; i++)
                {
                    decodedChars.Insert(int.Parse(spaceIndexes[i]) + i - 1, ' ');
                }
            }

            return string.Join("", decodedChars);
        }

        //// Alternative for Encrypt but simillar performance
        //public static string Encrypt1(string inputString)
        //{
        //    if (string.IsNullOrWhiteSpace(inputString)) return "";
        //    if (inputString.Length == 1) return inputString;

        //    var spaceIndexes = new StringBuilder("numsp");
        //    int noOfSpaces = 0;
        //    var inputCharsWithOutSpaces = new List<char>();

        //    for (var i = 0; i < inputString.ToCharArray().Length; i++)
        //    {
        //        if (inputString[i] == ' ')
        //        {
        //            spaceIndexes.Append(" ");
        //            spaceIndexes.Append(i + 1 - noOfSpaces);
        //            noOfSpaces++;
        //        }
        //        else
        //        {
        //            inputCharsWithOutSpaces.Add(inputString[i]);
        //        }
        //    }

        //    var sqrt = Math.Sqrt(inputCharsWithOutSpaces.Count);
        //    var rows = (int)Math.Floor(sqrt);
        //    var cols = (int)Math.Ceiling(sqrt);

        //    if (rows * cols < inputCharsWithOutSpaces.Count) rows = cols;

        //    var inputArray = new char[rows, cols];
        //    int rw = 0;
        //    int cl = 0;
            
        //    for (int i=0; i<inputCharsWithOutSpaces.Count; i++)
        //    {
        //        inputArray[rw, cl] = inputCharsWithOutSpaces[i];
        //        cl++;
        //        if (cl >= cols)
        //        {
        //            cl = 0;
        //            rw++;
        //        }
        //    }
            

        //    var encodedChars = new List<char>();

        //    for (int col = 0; col < cols; col++)
        //    {
        //        for (int row = 0; row < rows; row++)
        //        {
        //            if (inputArray[row, col] != '\0')
        //            {
        //                encodedChars.Add(inputArray[row, col]);
        //            }
        //        }
        //        encodedChars.Add(' ');
        //    }

        //    return string.Join("", encodedChars) + (spaceIndexes.Length == 5 ? "" : spaceIndexes.ToString());
        //}
    }
}