using System;
using System.Reflection;
using System.Runtime.InteropServices;
using NativeLibraryManager;

namespace CoreNativeTest
{
    internal class Program
    {
        [DllImport("TestLib")]
        private static extern void hello();
    
        private static void Main(string[] args)
        {
            var accessor = new ResourceAccessor(Assembly.GetExecutingAssembly());
            var libManager = new LibraryManager(
                Assembly.GetExecutingAssembly(),
                new LibraryItem(Platform.MacOs, Bitness.x64,
                    new LibraryFile("libTestLib.dylib", accessor.Binary("libTestLib.dylib"))),
                new LibraryItem(Platform.Windows, Bitness.x64, 
                    new LibraryFile("TestLib.dll", accessor.Binary("TestLib.dll"))),
                new LibraryItem(Platform.Linux, Bitness.x64,
                    new LibraryFile("libTestLib.so", accessor.Binary("libTestLib.so"))));
            
            libManager.LoadNativeLibrary();
            
            hello();
            Console.WriteLine("Hello from C#!");
        }
    }
}