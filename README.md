## Tutorial

### Baseado em:
https://medium.com/@xaviergeerinck/how-to-bind-c-code-with-dotnet-core-157a121c0aa6

### Passos:
Somente com os fontes e o CMakeList.txt, executar os seguintes comandos:

#### 1.Configure the MakeFile
cmake .

#### 2.Build with all cores available
- MacOS: 
    - make -j$(sysctl hw.ncpu | cut -d: -f2)
- Linux: Build with all cores available
    - make -j$(grep -c ^processor /proc/cpuinfo)