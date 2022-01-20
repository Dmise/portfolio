using System;
using System.Collections.Generic;
using System.Text;
using static RevPol.Functions;

namespace RevPol {
    static public class Splitter {

        static public void Splitt() {
            //берем из ДБ входящую строку
            //сплитим входящую строку функцией, разработанной в 1 ДЗ.
            //кладем разбитую строку в ДБ
            DB.SetListSplitted(Functions.Splitt(DB.GetInput()));
        }
    }

    static public class Combiner {
        public static void CreateData() {
            
            //создаем лист в ОПЗ
            DB.SetListRevPol(ConvertToReveresePolish(DB.GetListSplitted()));
            //создаем строку в ОПЗ
            DB.SetRevPol(MakeStringFromList(DB.GetListRevPol(), ","));
            //считаем и забисываем ответ (результат вычислений) 
            DB.SetResult(ReversePolishCalculator(DB.GetListRevPol()));
           
        }
    }

    static public class Printer {
        public static void RevPol() {
            Console.WriteLine($"Reverse polish:{DB.GetRevPol()}");
        }
        public static void Splitted() {
            Console.WriteLine($"Splitted list is:{MakeStringFromList(DB.GetListSplitted(), ",")}");          
        }

        public static void Result() {
            Console.WriteLine($"Result:{DB.GetResult()}");
        }
    }

    //условная база данных
    public static class DB {

        static public void SetInput(string input) {
            _input = input;
        }
        static public void SetListSplitted(List<string> list) {
            _listSplitted = list;
        }
        static public void SetListRevPol(List<string> list) {
            _listRevPol = list;
        }
        static public void SetRevPol(string str) {
            _revPol = str;
        }
        static public void SetResult(double res) {
            _result = res;
        }

        static public string GetInput() {
           return  _input;
        }
        static public List<string> GetListSplitted() {
            return _listSplitted;
        }
        static public List<string> GetListRevPol() {
            return _listRevPol;
        }
        static public string GetRevPol() {
            return _revPol ;
        }
        static public double GetResult() {
            return _result;
        }

        static string _input; //входная строка
        static List<string> _listSplitted;
        static List<string> _listRevPol;
        static string _revPol; //запись в виде ОПЗ
        static double _result; //результат вычисления
    }


}
