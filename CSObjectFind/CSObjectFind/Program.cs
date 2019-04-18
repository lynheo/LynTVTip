using System;
using System.Collections.Generic;

namespace CSObjectFind
{
    public class TestObject
    {
        public string Name;
    }

    class Program
    {
        static void Foo1()
        {
            var f1 = new TestObject() { Name = "Lyn" };
            var f2 = new TestObject() { Name = "Visual Studio" };
            var f3 = new TestObject() { Name = "Debugger" };
        }

        static List<TestObject> Foo2()
        {
            var l1 = new List<TestObject>();
            var t1 = new TestObject() { Name = "Lyn" };
            var t2 = new TestObject() { Name = "Visual Studio" };
            var t3 = new TestObject() { Name = "Debugger" };
            l1.Add(t1);
            l1.Add(t2);
            l1.Add(t3);
            return l1;
        }

        static void Main(string[] args)
        {
            Foo1();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();

            var list = Foo2();
            Console.ReadLine();
        }
    }
}
