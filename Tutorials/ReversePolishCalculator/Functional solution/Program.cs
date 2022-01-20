using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static ReversePolish.Functions;

namespace ReversePolish {
    class Program {
        //global variables
        static char[] separators = new char[] { ' ', ',' };

        static void Main(string[] args) {
            string input = Console.ReadLine();
            var listSplitted = Splitter(input);
            var listReversePolish = ConvertToReveresePolish(listSplitted);
            string strReversePolish = MakeStringFromList(listReversePolish,",");
            double result = ReversePolishCalculator(listReversePolish);
            Console.WriteLine($"Reverse polish:{strReversePolish}");
            Console.WriteLine($"Result:{result}");

        } // Main bracket                

    } //Class Programm
}
