using System;

namespace ObjectComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteDeltas(new Foo { X = 123, Y = DateTime.Today, Z = null },
                new Foo { X = 124, Y = DateTime.Today, Z = null });

            WriteDeltas(new Foo { X = 123, Y = DateTime.Today, Z = null },
                        new Foo { X = 123, Y = DateTime.Now, Z = new Dummy() });

            Console.ReadKey();
        }

        static void WriteDeltas<T>(T x, T y)
        {
            Console.WriteLine("----");
            foreach (string delta in PropertyComparer<T>.GetDeltas(x, y))
                Console.WriteLine(delta);

        }
    }
}
