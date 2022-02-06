using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class ListExtensions
    {
        public static LinkedList<string> ToLinkedList(this List<string> ourList)
        {
            LinkedList<string> result  = new LinkedList<string>();

            foreach(string currentWord in ourList)
            {
                result.AddLast(currentWord);
            }

            return result;
        }
    }
}
