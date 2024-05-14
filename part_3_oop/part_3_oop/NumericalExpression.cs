using System;
using System.Collections.Generic;
using System.Text;

namespace part_3_oop
{
    class NumericalExpression
    {
        private long _number;
        public NumericalExpression(long number)
        {
            _number = number;
        }


        public long GetValue()
        {
            return _number;
        }
        public override string ToString()
        {
            string numberInWords = "";
            string[] digits = { "", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine " };
            string[] teens = { "ten ", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ", "eighteen ", "nineteen " };
            string[] tens = { "", "", "twenty ", "thirty ", "forty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " };
            string[] jumps = { "", "thousand ", "million ", "billion " };

            long number = _number;
            int counter = 1; // represent if current digit is ones (1), tens(2) or hundreds(3) digit

            for (int i = 0; i < _number.ToString().Length; i++)
            {
                long digit = number % 10;
                number /= 10;
                if (i % 3 == 0)  // when to place thousand/million/billion
                {
                    numberInWords = jumps[i / 3] + numberInWords;
                }

                if (counter == 3)
                {
                    if (digit != 0)
                    {
                        numberInWords = digits[digit] + "hundred " + numberInWords;
                    }
                    counter = 0;
                }

                else if (counter == 2 && digit != 0)
                {
                    numberInWords = tens[digit] + numberInWords;
                }

                else if (counter == 1)
                {
                    if (number % 10 == 1)
                    {
                        number /= 10;
                        i++;
                        numberInWords = teens[digit] + numberInWords;
                        counter++;
                    }

                    else if (digit!=0)
                    {
                        numberInWords = digits[digit] + numberInWords;
                    }
                }
                counter++;
            }
            return numberInWords;
        }

        public static long SumLetters(long number)
        {
            long counter = 0;
            for (long i = 1; i <= number; i++)
            {
                NumericalExpression index = new NumericalExpression(i);
                string numberInWords = index.ToString();
                numberInWords = numberInWords.Replace(" ", "");
                counter += numberInWords.Length;

            }
            return counter;
        }

        //polymorphism
        public static long SumLetters(NumericalExpression number)
        {
            return SumLetters(number.GetValue());
        }
    }
}
