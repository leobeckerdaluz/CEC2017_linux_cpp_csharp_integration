# Configure our Required Version
cmake_minimum_required(VERSION 3.0)

# Define the name of our project
project(cec2017_functions)

# Define the output library to be a shared file (.so or .dll) and output it as "(lib)hello-cpp.so"
add_library(cec2017_functions SHARED CEC2017.cpp CEC2017.h)