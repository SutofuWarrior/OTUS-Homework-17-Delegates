using System;
using System.Collections.Generic;

namespace OTUS_Homework_17_Delegates
{
    public static class IEnumerableExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter)
            where T: class
        {
            T maxItem = default;
            float max = getParameter(maxItem);

            foreach (T next in e)
            {
                float cur = getParameter(next);

                if (max < cur)
                {
                    maxItem = next;
                    max = cur;
                }
            }

            return maxItem;
        }
    }
}
