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
                    new LibraryFile("libTestLib.dylib", accessor.Binary("libTestLib.dylib"))));
            
            libManager.LoadNativeLibrary();
            
            hello();
            Console.WriteLine("Hello from C#!");
        }
    }
}