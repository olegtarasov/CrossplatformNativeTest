#ifndef TESTLIB_LIBRARY_H
#define TESTLIB_LIBRARY_H

#if defined DLL_EXPORTS
    #if defined WIN32
        #define LIB_API(RetType) extern "C" __declspec(dllexport) RetType
    #else
        #define LIB_API(RetType) extern "C" RetType __attribute__((visibility("default")))
    #endif
#else
    #if defined WIN32
        #define LIB_API(RetType) extern "C" __declspec(dllimport) RetType
    #else
        #define LIB_API(RetType) extern "C" RetType
    #endif
#endif

#pragma pack(push, 1)
struct Foo
{
  int number;
  const char* some_string;
  int number2;
  const char* another_string;
  int number3;
};
#pragma pack(pop)

LIB_API(void) hello();
LIB_API(void) string_func(const char* some_string);
LIB_API(void) foo_func(Foo foo);

#endif //TESTLIB_LIBRARY_H