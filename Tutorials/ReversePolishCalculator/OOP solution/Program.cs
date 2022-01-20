using System;

namespace RevPol {
    class Program {
        static void Main(string[] args) {
            //добавим входную строку в БД
            DB.SetInput(Console.ReadLine());
            //разобьем строку на элементы
            Splitter.Splitt();
            //соберем лист в виде ОПЗ
            Combiner.CreateData();
            //Выведем данные из БД в
            Printer.RevPol();
            Printer.Splitted();
            Printer.Result();
        }
    }
}