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
        [DllImport(@"../cpp/libcec2017_functions.so")]
        public unsafe static extern void cec17_test_func(double *x, double *f, int nx, int mx, int func_num);
        


        public static double cec2017_run_function(double[] phenotype, int function_id, int dimension)
        {
            double[] fx = new double[] { 0 };

            unsafe
            {
                fixed (double* x = phenotype)
                {
                    fixed (double* f = fx)
                    {
                        cec17_test_func(x, f, dimension, 1, function_id);
                    }
                }
            }   
            
            return fx[0];
        }



        static void ExtensiveSearch_2D()
        {
            // --------------------------------------------------------------------------------------
            // Extensive Search D=2
            // F1 f(x*) = 100 --> if x* not 0, f(x) is up to 10^8, because F1 is shifted and rotated
            // F2 f(x*) = 200
            // F3 f(x*) = 300
            // F4 f(x*) = 400
            // F5 f(x*) = 500
            // F6 f(x*) = 600
            // F7 f(x*) = 700
            // F8 f(x*) = 800
            // F9 f(x*) = 900
            // F10 f(x*) = 1000
            
            // Iterates functions 1-10 (functions 11-20 min dimension = 10)
            for(int function_id=1; function_id<11; function_id++)
            {
                // Ignores function 2
                if(function_id==2)    
                    continue;
                
                Console.WriteLine("-----------------------");
                Console.WriteLine("Function {0}", function_id);
                
                int dimension_nx = 2;
                double best_fx = Double.MaxValue;
                double[] best_phenotype = new double[dimension_nx];
            
                // Iterates the 2 design variables
                for(int i=-100; i<100; i++)
                {
                    for(int j=-100; j<100; j++)
                    {
                        // Create phenotype
                        double[] phenotype = {i,j};

                        // Compute f(x)
                        double fx = cec2017_run_function(phenotype, function_id, dimension_nx);
                        
                        // Store the result if it's the best so far
                        if (fx < best_fx){
                            best_fx = fx;
                            best_phenotype = phenotype;
                        }
                    }
                }
                
                // Display results
                Console.WriteLine("fx: {0}", best_fx);
                foreach(double xi in best_phenotype)
                {
                    Console.WriteLine("{0},", xi);
                }
            }
        }



        static void Main(){
            ExtensiveSearch_2D();
        }
    }
}