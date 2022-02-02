// using System;

// namespace dotnet
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Hello World!2222");
//         }
//     }
// }



using System;
using System.Runtime.InteropServices;

namespace CppBind
{
    class Program
    {
        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern void PrintHelloWorld();

        static void Main(string[] args)
        {
            PrintHelloWorld();
        }
    }
}