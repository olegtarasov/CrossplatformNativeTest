cmake_minimum_required(VERSION 3.14)
project(TestLib)

set(CMAKE_CXX_STANDARD 17)

add_library(TestLib SHARED library.cpp library.h)