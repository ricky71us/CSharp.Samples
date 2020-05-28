using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CSharp.Samples
{
    public class Closure
    {
        private static int _maxLength;

        public Closure(int maxLength)
        {
            _maxLength = maxLength;
        }


        public void csharp1() 
        {
            Predicate<string> predicate = new Predicate<string>(MatchFourLetterOrFewer);
            IList<string> shortWords = ListUtil.filter<string>(SampleData.Words, predicate);
            ListUtil.DumpData(shortWords);
        }

        private bool MatchFourLetterOrFewer(string item)
        {
            return item.Length <= 4;
        }

        internal static class SampleData
        {
            internal static readonly List<string> Words = new List<string>{ "Philosophy", "Meditation", "Surrender" };
        }
    }

    public static class ListUtil
    {
        public static IList<T> filter<T>(IList<T> source, Predicate<T> predicate)
        {
            List<T> ret = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        internal static void DumpData(IList<string> words)
        {
            Console.WriteLine(words);    
        }
    }
}
