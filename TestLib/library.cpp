#include "library.h"

#include <iostream>
#include <string>

using std::string;
using std::cout;
using std::endl;

#if defined(_WIN32)
#define OS "Windows"
#elif defined(__linux__)
#define OS "Linux"
#elif defined(__APPLE__)
#define OS "MacOS"
#else
#define OS "Unknown OS"
#endif

void hello() {
    cout << "Hello from " << OS << "!" << endl;
}
void string_func(const char* some_string)
{
    cout << "Hello, " << string(some_string) << "!" << endl;
}
void foo_func(Foo foo)
{
    cout << "Hello, " << string(foo.some_string) << "! Gimme a high " << foo.number << "!" << endl;
}
