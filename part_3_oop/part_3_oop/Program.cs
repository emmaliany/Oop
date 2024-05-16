using System;
using System.Collections.Generic;

namespace part_3_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            //CheckLinkedList();
            CheckNumericalExpression();


        }

        public static void PrintIEnumerable(IEnumerable<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
        }

        public static void CheckNumericalExpression()
        {
            NumericalExpression test = new NumericalExpression(-90210);
            Console.WriteLine(test.ToString());
            Console.WriteLine(test.GetValue());
            Console.WriteLine(NumericalExpression.SumLetters(9));
        }

        public static void CheckLinkedList()
        {
            LinkedList test = new LinkedList();
            test.Prepend(5);
            test.Append(8);
            test.Append(4);
            test.Prepend(13);
            test.Pop();
            Console.WriteLine(test.GetMaxNode().Value);
            Console.WriteLine(test.GetMinNode().Value);
            test.PrintList();
            test.Sort();
            test.PrintList();

            test.Prepend(40);
            test.Prepend(2);
            Console.WriteLine(test.GetMaxNode().Value);
            Console.WriteLine(test.GetMinNode().Value);
            PrintIEnumerable(test.ToList());
            
        }
    }
}
