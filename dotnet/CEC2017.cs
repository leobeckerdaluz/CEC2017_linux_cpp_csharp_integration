using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CppBind
{
    public class CEC2017
    {
        [DllImport(@"../cpp/libcec2017_functions.so", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void cec17_test_func(double *x, double *f, int nx, int mx, int func_num);
        
        
        static void Main(string[] args)
        {
            for(int f=1; f<11; f++){
                if(f==2)    continue;


                Console.WriteLine("-----------------------");
                Console.WriteLine("Function {0}", f);
            
                double fx_min = Double.MaxValue;
                double i_min = Double.MaxValue;
                double j_min = Double.MaxValue;

                for(int i=-100; i<100; i++){
                    for(int j=-100; j<100; j++){
                        
                        double[] popul = {i, j};
                        int func_id = f;

                        double fx_final = FO(popul, func_id);
                        if (fx_final < fx_min){
                            fx_min = fx_final;
                            i_min = i;
                            j_min = j;
                        }
                    }
                }

                Console.WriteLine("fx: {0}", fx_min);
                Console.WriteLine("x1: {0}", i_min);
                Console.WriteLine("x2: {0}", j_min);
            }
        }



        static double FO(double[] pop, int func_id)
        {
            double[] fx = new double[] { 0, 0, 0, 0 };
            
            double[] parameters = pop;
            int nx = parameters.Length;
            int mx = 1;

            unsafe
            {
                fixed (double* x = parameters)
                {
                    fixed (double* f = fx)
                    {
                        cec17_test_func(x, f, nx, mx, func_id);
                    }
                }
            }   
            
            return fx[0];

            // private int D = 30;
            // private double[] Os;
            // private double[] Mr;


            
            // double[] rsParameters = ShiftAndRotate(parameters, Os, Mr, 1);
            // double fx = Math.Pow(rsParameters[0], 2);
            // double sum = 0;
            // int i = 0;
            // for (i = 1; i < rsParameters.Length - 1; i++)
            // {
            //    sum += Math.Pow(rsParameters[i], 2);
            // }

            // fx += Math.Pow(10, 6) * sum;
            // fx += 100;
            
            
        }
    }
}