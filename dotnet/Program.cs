using System;
using System.Runtime.InteropServices;

namespace CppBind
{
    class Program
    {
        [DllImport(@"../cpp/libcec2017_functions.so")]
        public static extern void PrintHelloWorld();

        static void Main(string[] args)
        {
            PrintHelloWorld();
        }
    }
}