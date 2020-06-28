using System;
using System.Reflection;
using System.Runtime.InteropServices;
using NativeLibraryManager;

namespace CoreNativeTest
{
    internal class Program
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct Foo
        {
            public int number;
            public string some_string;
        }
        
        [DllImport("TestLib")]
        private static extern void hello();
        
        [DllImport("TestLib")]
        private static extern void string_func(string some_string);
        
        [DllImport("TestLib")]
        private static extern void foo_func(Foo foo);
    
        private static void Main(string[] args)
        {
            var accessor = new ResourceAccessor(Assembly.GetExecutingAssembly());
            var libManager = new LibraryManager(
                new LibraryItem(Platform.MacOs, Bitness.x64,
                    new LibraryFile("libTestLib.dylib", accessor.Binary("libTestLib.dylib"))),
                new LibraryItem(Platform.Windows, Bitness.x64, 
                    new LibraryFile("TestLib.dll", accessor.Binary("TestLib.dll"))),
                new LibraryItem(Platform.Linux, Bitness.x64,
                    new LibraryFile("libTestLib.so", accessor.Binary("libTestLib.so"))));
            
            libManager.LoadNativeLibrary();
            
            hello();
            string_func("Oleg");
            foo_func(new Foo {some_string = "dude", number = 5});
            
            Console.WriteLine("Hello from C#!");
        }
    }
}