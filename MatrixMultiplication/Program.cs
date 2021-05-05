using System;

namespace MatrixMultiplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var matrix = new Matrix(new double[,]{
                    {34, 23, 54, 66},
                    {54, 344, 78, 98},
                    {34, 87, 24, 666},
                    {51, 21, 4, 6}
                });

                for (int i = 0; i < matrix.InnerMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.InnerMatrix.GetLength(1); j++)
                    {
                        Console.Write(matrix.InnerMatrix[i,j] + "\t");
                    }
                    Console.WriteLine();
                }
                
                Console.WriteLine("\n*\n");

                var res = matrix.MultiplyByCoordinates(new double[] {
                    54, 65, 33, 76
                });
                
                Console.WriteLine("\n=\n");
                
                foreach (var t in res)
                    Console.WriteLine(t);
            }
            catch (Exception)
            {
                return;
            }

            Console.ReadLine();
        }
    }
}