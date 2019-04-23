using System;
using System.Text;

namespace StringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo0();
            Foo1();
            Foo2();
            Foo3();
            Foo4();
        }

        static void Foo0()
        {
            string str1 = "Lyn";
            string str2 = "Lyn";

            Console.WriteLine(str1 == str2);
        }

        static void Foo1()
        {
            object str = "Lyn";
            Console.WriteLine(str == "Lyn");
        }

        static void Foo2()
        {
            object str1 = "Lyn";
            var str2 = (new StringBuilder().Append('L').Append('y').Append('n')).ToString();
            Console.WriteLine(str1 == str2);
        }

        static void Foo3()
        {
            object str1 = "Lyn";
            object str2 = "Lyn";
            object str3 = "Lyn";

            Console.WriteLine(str1 == str2);
        }

        static void Foo4()
        {
            string str1 = "Lyn";
            var str2 = (new StringBuilder().Append('L').Append('y').Append('n')).ToString();
            Console.WriteLine(str1 == str2);
        }
    }
}
