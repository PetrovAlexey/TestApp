using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void ShowList(IEnumerable<List<string>> textList)
        {
            foreach (var list in textList)
            {
                list.ForEach(i => Console.Write("{0} ", i));
                Console.WriteLine("\n");
            }
        }

        private static void Main(string[] args)
        {
            var textService = new TextService.TextService();
            var temp = new List<string> {"ток", "рост", "кот", "торс", "Кто", "фывап", "рок"};
            var result = textService.ParseList(temp);
            ShowList(result);
        }
    }
}
