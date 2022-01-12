using System;
using System.Collections.Generic;

namespace OTUS_Homework_17_Delegates
{
    public static class IEnumerableExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter)
            where T: class
        {
            if (getParameter == null)
                throw new ArgumentNullException(nameof(getParameter));

            T maxItem = default;
            float max = getParameter(maxItem);

            foreach (T current in e)
            {
                float value = getParameter(current);

                if (max < value)
                {
                    maxItem = current;
                    max = value;
                }
            }

            return maxItem;
        }
    }
}
