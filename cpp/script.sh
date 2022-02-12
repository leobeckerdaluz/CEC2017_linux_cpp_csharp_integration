# rm -r CMakeCache.txt CMakeFiles/ cmake_install.cmake Makefile

cmake .

make -j$(grep -c ^processor /proc/cpuinfo)



# chmod +x script-name-here.sh