## Utilização das funções CEC2017 C++ em C#

### Baseado em:
https://medium.com/@xaviergeerinck/how-to-bind-c-code-with-dotnet-core-157a121c0aa6

Esse repositório consiste em utilizar funções do CEC2017 desenvolvidas em C++ no projeto dotnet console em C#. 
Para isso, é preciso compilar o código C++ e gerar uma biblioteca dinâmica no formato .so (para linux) ou .dll (para windows) e importar no C#.

### Etapas para compilação:
#### 1) Alteração do arquivo cpp
O Arquivo cpp das funções necessita abrir arquivos da pasta input_data/. Para isso, foi criado uma diretiva #define chamada FUNCTIONS_INPUT_PATH que contém uma string com o path onde a pasta **input_data** está localizada, sem o '/' no fim. Por exemplo: "/home/lbluz/CEC2017_linux_cpp_csharp_integration/cpp"

#### 2) Compilação do cpp
Para compilar o arquivo C++ é preciso dos arquivos .cpp e .h e do CMakeList.txt. Os 2 comandos a serem executados para criar o Makefile e compilar seguem abaixo em 2.1 e 2.2. 
Neste repositório, há um arquivo chamado **script.sh** que contém esses comandos para linux. Antes de executar esse shell script, é necessário executar **chmod +x script.sh** para alterar as permissões do arquivo e só depois executá-lo com **./script.sh**.
 
##### 2.1) Configura o Makefile
cmake .

##### 2.2) Compila com todos os núcleos
- MacOS: 
    - make -j$(sysctl hw.ncpu | cut -d: -f2)
- Linux: Build with all cores available
    - make -j$(grep -c ^processor /proc/cpuinfo)