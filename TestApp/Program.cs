using System;
using System.Reflection;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly Asm = Assembly.LoadFrom("TestApp.exe");
            Type T = Asm.GetType("TestApp.Gun", true, true);
            Object Obj = Activator.CreateInstance(T, new Object[] { "9mm" });
            MethodInfo Method = T.GetMethod("StartTest");
            Method.Invoke(Obj, new Object[] { });
            Console.Read();
        }
    }
}
