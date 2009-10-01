using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {/*
          The Haskell version
          f :: [a] -> [a]
          f [] = []
          f (x:xs) = f ys ++ [x] ++ f zs
             where
               ys = [a | a <- xs, a <= x]
               zs = [b | b <- xs, b > x]
          */

            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                int[] vals = new int[r.Next(0, 20)];
                for (int j = 0; j < vals.Length; j++)
                    vals[j] = r.Next(100);

                var v = vals.AsEnumerable();
                Console.WriteLine("Sorting: " + v.Show());
                Console.WriteLine(" " + QuickSort(vals.AsEnumerable()).Show());
            }
        }

        public static IEnumerable<A> QuickSort<A>(IEnumerable<A> vals)
            where A : IComparable<A>
        {
            if (vals.Skip(1).IsEmpty())
                return vals;
            else
            {
                A pivot = vals.First();
                var rest = vals.Skip(1);
                var left = from x in rest
                           where x.CompareTo(pivot) <= 0
                           select x;

                var right = from x in rest
                            where x.CompareTo(pivot) > 0
                            select x;

                return QuickSort(left).Concat(vals.Take(1)).Concat(right);
            }
        }
    }

    public static class E
    {
        /// <summary>
        /// Test if a sequence is empty.
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsEmpty<A>(this IEnumerable<A> coll)
        {
            return !coll.Any(x => true);
        }

        public static string Show<A>(this IEnumerable<A> coll)
        {
            if (coll.IsEmpty())
                return String.Empty;
            else
                return coll.Select<A, string>(x => x.ToString()).Aggregate((e, acc) => String.Concat(e, ", ", acc));
        }

    }
}
