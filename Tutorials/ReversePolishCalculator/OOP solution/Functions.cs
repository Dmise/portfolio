using System;
using System.Collections.Generic;
using System.Text;

namespace RevPol {
    public class Functions {
        static char[] separators = new char[] { ' ', ',' };

        
        static Dictionary<List<string>, List<string>> DataTest = new Dictionary<List<string>, List<string>>() 
        { 
            {new  List<string> {"(","-","2","-","4",")","/","45" } ,new  List<string> {"0","2","-","4","-","45","/" } },           
            {new  List<string> {"34","-", "4", "/","(","5",")" } ,new  List<string> {"34","4","-","5","/" }} 

        };

        static public bool IsItSeparator(char ch) {
            foreach (char separator in separators) {
                if (ch == separator)
                    return true;
            }
            return false;
        }

        static public bool IsStackEqualOrPriority(char input, char stackChar) {
            if (IsOperator(stackChar)) {
                if ((input == '+' || input == '-'))
                    return true;
                else if ((input == '*' || input == '/') && (stackChar == '*' || stackChar == '/'))
                    return true;
                else if ((input == '*' || input == '/') && (stackChar == '-' || stackChar == '+'))
                    return false;
            }
            return false;
        }

        static public bool IsStackEqualOrPriority(string input, string stackChar) {
            if (IsOperator(stackChar)) {
                if ((input == "+" || input == "-"))
                    return true;
                else if ((input == "*" || input == "/") && (stackChar == "*" || stackChar == "/"))
                    return true;
                else if ((input == "*" || input == "/") && (stackChar == "-" || stackChar == "+"))
                    return false;
            }
            return false;
        }

        static public bool IsOperator(char ch) {
            switch (ch) {
                case '+':
                    return true;
                case '-':
                    return true;
                case '*':
                    return true;
                case '^':
                    return true;
                case '/':
                    return true;

            }
            return false;
        }

        static public bool IsOperator(string ch) {
            switch (ch) {
                case "+":
                    return true;
                case "-":
                    return true;
                case "*":
                    return true;
                case "^":
                    return true;
                case "/":
                    return true;

            }
            return false;
        }

        static public bool IsSeparator(char ch) {
            foreach (char sep in separators) {
                if (sep == ch)
                    return true;
            }
            return false;
        }

        static public string MakeStringFromList(List<string> list, string separator) {
            StringBuilder sb = new StringBuilder();
            foreach (string str in list) {
                sb.Append(str);
                sb.Append(separator);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        //Функция не реализована
        static public double ReversePolishCalculator(string input) {
            return 1.11; // заглушка 
        }

        static public double ReversePolishCalculator(List<string> input) {
            List<double> stack = new List<double>();
            int i = 0;
            while (i < input.Count) {
                if (!IsOperator(input[i])) {
                    stack.Add(Convert.ToDouble(input[i]));
                    i++;
                } else {
                    var res = Calculate(stack[stack.Count - 2], stack[stack.Count - 1], input[i]);
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(res);
                    i++;
                }
            }
            return stack[0];
        }

        static double Calculate(double e1, double e2, string oper) {
            switch (oper) {
                case "+":
                    return e1 + e2;
                case "-":
                    return e1 - e2;
                case "/":
                    return e1 / e2;
                case "*":
                    return e1 * e2;
            }
            return double.NaN;
        }

        static public string ConvertToReversePolish(string input) {
            char prev = '\0';
            StringBuilder sbOut = new StringBuilder();
            List<char> stack = new List<char>();

            foreach (char ch in input) {

                //1.Число - добавляем в строку вывода
                if (Char.IsDigit(ch)) {
                    sbOut.Append(ch);
                }
                //2. Открывающая скобка или функция - помещаем в стек
                else if (ch == '(') {
                    stack.Add(ch);

                } else if (IsOperator(ch)) {
                    //унарный + или -
                    if ((ch == '+' || ch == '-') && (prev == '\0' || prev == '(')) {
                        stack.Add(ch);

                    }
                    //пока на вершине префиксная функция ИЛИ операция на вершине стека приоритетнее входящей
                    // ИЛИ операция на вершине стека левоассоциативная с приоритетом как у входящей 
                    // выталкиваем верхний элемент стека в выходную строку
                    else {
                        while (stack.Count != 0 && IsStackEqualOrPriority(ch, stack[stack.Count - 1])) {
                            MoveFromStackToOut();
                        }
                        stack.Add(ch);
                    }
                } else if (ch == ')') {
                    while (stack[^1] != '(') {
                        MoveFromStackToOut();
                    }
                    // удаляем знак '(' из стека
                    stack.RemoveAt(stack.Count - 1);
                }
                prev = ch;
            }
            // когда входная строка закончилась, выталкиваем все символы выходную строку.

            while (stack.Count != 0) {
                MoveFromStackToOut();
            }
            return sbOut.ToString();

            void MoveFromStackToOut() {
                if (stack.Count == 0)
                    return;
                sbOut.Append(stack[^1]);
                stack.RemoveAt(stack.Count - 1);
            }
        }

        static public List<string> ConvertToReveresePolish(List<string> input) {
            var outList = new List<string>();
            List<string> stack = new List<string>();
            string prev = "\0";

            for (int i = 0; i < input.Count; i++) {
                var curMember = input[i];
                //текущий член - число
                if (Char.IsDigit(curMember[0])) {
                    outList.Add(curMember);
                    prev = curMember;
                } else if (input[i] == '('.ToString()) {
                    stack.Add(curMember);
                    prev = curMember;
                }
                  //текущий член - оператор
                  else if (IsOperator(curMember)) {
                    //унарный -   заменяем на "0 - "следующее число"" 
                    if ((curMember == "-") && (prev == "\0" || prev == '('.ToString() || IsOperator(prev))) {
                        outList.Add("0");
                        outList.Add(input[i + 1]);
                        stack.Add(curMember);
                        prev = input[i + 1];
                        i++;
                        continue;
                    }
                    //унарный +
                    else if ((curMember == "+") && (prev == "\0" || prev == '('.ToString() || IsOperator(prev))) {
                        continue;
                    }

                    // до тех пор, пока в стеке лежат более приоритетные и равные функции - выталкиваем их в выходную строку 
                    else {
                        while (stack.Count != 0 && IsStackEqualOrPriority(curMember, stack[stack.Count - 1]))
                            MoveFromStackToOut();
                        stack.Add(curMember);
                    }
                }
                  //обработка закрывающей скобки
                  else if (curMember == ")") {
                    while (stack[^1] != "(") {
                        MoveFromStackToOut();
                    }
                    // удаляем знак '(' из стека
                    stack.RemoveAt(stack.Count - 1);
                }
                prev = curMember;
            }

            while (stack.Count != 0) {
                MoveFromStackToOut();
            }
            return outList;

            void MoveFromStackToOut() {
                if (stack.Count == 0)
                    return;
                outList.Add(stack[^1]);
                stack.RemoveAt(stack.Count - 1);
            }

        }

        static public List<string> Splitt(string str) {
            List<string> resultList = new List<string>();
            string curElem = null;
            for (int i = 0; i < str.Length; i++) {
                char ch = str[i];
                if (IsOperator(ch)) {
                    //если знак появился после цифры
                    if (curElem != null) {
                        resultList.Add(curElem);
                        curElem = null;
                    }
                    resultList.Add(Char.ToString(ch));
                } else if (Char.IsDigit(ch)) {
                    curElem = curElem + Char.ToString(ch);
                    if (i == str.Length - 1) {
                        resultList.Add(curElem);
                        curElem = null;
                    }
                } else if (ch == '(')
                    resultList.Add(Char.ToString(ch));
                else if (ch == ')') {
                    if (curElem != null) {
                        resultList.Add(curElem);
                        curElem = null;
                    }
                    resultList.Add(Char.ToString(ch));
                }

            }

            return resultList;
        }
    }
}
