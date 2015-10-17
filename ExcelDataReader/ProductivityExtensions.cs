namespace ExcelReportLoader
{
    using System;
    using System.Collections.Generic;

    internal static class ProductivityExtensions
    {
        public const string DefaultSeparator = ", ";

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }

            return collection;
        }

        public static IDictionary<string, R> AddEntries<R>(this IDictionary<string, R> dict, params Func<string, R>[] entries)
        {
            entries.ForEach(e => 
            {
                var key = e.Method.GetParameters()[0].Name;
                var value = e(null);
                dict.Add(key, value);
            });

            return dict;
        }

        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = DefaultSeparator)
        {
            return string.Join(separator, collection);
        }

        public static string Formatted(this string format, params object[] insertees)
        {
            return string.Format(format, insertees);
        }

        public static T Print<T>(this T obj, bool writeLine = true)
        {
            Console.Write(obj);

            if(writeLine)
            {
                Console.WriteLine();
            }

            return obj;
        }
    }
}