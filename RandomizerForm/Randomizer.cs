using System;
using System.Collections;

namespace Randomizer
{
    public static class ListRandomizer
    {
        private static Random _rnd = new Random();

        public static object SelectObjectFromList(IList list)
        {
            if (list != null && list.Count > 0)
            {
                int index = _rnd.Next(0, list.Count - 1);
                return list[index];
            }
            return null;
        }

        public static IList ShellList(IList list)
        {
            if (list != null && list.Count != 0)
            {
                int size = list.Count, currIndex = 0;
                for (int i = currIndex; i < size; i++)
                {
                    var index = _rnd.Next(currIndex, list.Count - 1);
                    var tmp = list[currIndex];
                    list[currIndex] = list[index];
                    list[index] = tmp;
                    currIndex++;
                }
                return list;
            }
            return null;
        }
    }
}
