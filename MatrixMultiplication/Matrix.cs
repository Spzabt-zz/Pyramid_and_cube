using System;

namespace MatrixMultiplication
{
    public class Matrix
    {
        private double[,] _matrix;

        public double[,] InnerMatrix => _matrix;

        public static Matrix RotateX(int angle) {
            double rad = angle * Math.PI / 180;
            return new Matrix(new double[,]{
                    { 1, 0, 0, 0},
                    { 0, Math.Cos(rad), -Math.Sin(rad), 0},
                    { 0, Math.Sin(rad), Math.Cos(rad), 0},
                    { 0, 0, 0, 1},
                }
            );
        }
        
        public static Matrix RotateY(int angle) { 
            double rad = angle * Math.PI / 180;
            return new Matrix(new double[,]{
                    { Math.Cos(rad), 0, Math.Sin(rad), 0},
                    { 0, 1, 0, 0},
                    { -Math.Sin(rad), 0, Math.Cos(rad), 0},
                    { 0, 0, 0, 1},
                }
            );
        }

        public static Matrix RotateZ(int angle) {
            double rad = angle * Math.PI / 180;
            return new Matrix(new double[,]{
                    { Math.Cos(rad), -Math.Sin(rad), 0, 0},
                    { Math.Sin(rad), Math.Cos(rad), 0, 0},
                    { 0, 0, 1, 0},
                    { 0, 0, 0, 1},
                }
            );
        } 

        public void MultiplyMatrices(Matrix customMatrix) {
            var temp = new double[4, 4];

            // matrix * customMatrix
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    temp[i, j] = 0;
                    for (int k = 0; k < 4; k++) {
                        temp[i, j] += _matrix[i, k] * customMatrix._matrix[k, j];
                    }
                }
            }

            this._matrix = temp;
        }

        public double[] MultiplyByCoordinates(double[] coords) {
            foreach (var c in coords)
                Console.WriteLine(c);

            var temp = new double[4];

            for (int i = 0; i < 4; i++) {
                temp[i] = 0;
                for (int j = 0; j < 4; j++) {
                    temp[i] += coords[j] * _matrix[i, j]; 
                }
            }

            return temp;
        }

        public Matrix() {
            _matrix = new double[,] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1},
            };
        }

        public Matrix(double[,] matrix) {
            this._matrix = matrix;
        }
    }
}