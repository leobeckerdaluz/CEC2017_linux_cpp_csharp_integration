# Before run script.sh ==> chmod +x script.sh

rm -r CMakeCache.txt

cmake .

# Compile to Linux
make -j$(grep -c ^processor /proc/cpuinfo)

# Compile to Linux
# - make -j$(sysctl hw.ncpu | cut -d: -f2)