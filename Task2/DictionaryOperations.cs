using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class DictionaryExtensions
    {
        public static SortedDictionary<long, string> ToSortedDictionary(this Dictionary<string, long> inputDictionary)
        {
            SortedDictionary<long, string > result = new SortedDictionary<long, string>();
            foreach (var key in inputDictionary.Keys)
            {
                long value = inputDictionary[key];
                if (result.ContainsKey(value))
                {
                    result[value] += ", " + key;
                }
                else
                {
                    result.Add(value, key);
                }
            }

            return result;
        }
    }
}
