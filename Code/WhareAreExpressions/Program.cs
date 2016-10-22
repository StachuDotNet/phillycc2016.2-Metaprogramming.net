using System;
using System.Linq;
using System.Linq.Expressions;

namespace WhatAreExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isOddFunc1 = new Func<int, bool>(i => i % 2 == 1);
            Func<int, bool> isOddFunc2 = i => i % 2 == 1;
            var isOddFunc3 = new Func<int, bool>(i => i % 2 == 1);

            Predicate<int> isOddFunc4 = new Predicate<int>(i => i % 2 == 1);
            Predicate<int> isOddFunc5 = i => i % 2 == 1;
            var isOddFunc6 = new Predicate<int>(i => i % 2 == 1);



            Expression<Func<int, bool>> isOddExpr = i => i % 2 == 1;



            var collection = Enumerable.Range(1, 15).Select(i => i * i);

            var oddsFunc1 = collection.Where(isOddFunc1);
            var oddsExpr1 = collection.Where(isOddExpr.Compile());


            Console.WriteLine($"Name: {isOddExpr.Name}");
            Console.WriteLine($"Node Type: {isOddExpr.NodeType}");
            Console.WriteLine($"Type: {isOddExpr.Type}");
            Console.WriteLine($"Body: {isOddExpr.Body}");

            Console.WriteLine("Params:");
            foreach (var p in isOddExpr.Parameters.Select((v, i) => new { Index = i, Value = v }))
            {
                Console.WriteLine($"Parameter #: {p.Index}");
                Console.WriteLine($"Parameter Name: {p.Value.Name}");
                Console.WriteLine($"Parameter NodeType: {p.Value.NodeType}");
                Console.WriteLine($"Parameter Type: {p.Value.Type}");
            }

            Console.ReadKey();
        }


        bool IsOdd(int input)
        {
            return input % 2 == 1;
        }
    }
}
