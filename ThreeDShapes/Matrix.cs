using System;

namespace ThreeDShapes
{
    class Matrix
    {
        public Matrix() { }

        private float[][] VecToMatrix(PVector v)
        {
            float[][] m = new float[3][];
            for (int i = 0; i < m.Length; i++)
                m[i] = new float[1];
            m[0][0] = v.X;
            m[1][0] = v.Y;
            m[2][0] = v.Z;
            return m;
        }

        private PVector MatrixToVec(float[][] m)
        {
            PVector v = new PVector();
            v.X = m[0][0];
            v.Y = m[1][0];
            if (m.Length > 2)
            {
                v.Z = m[2][0];
            }

            return v;
        }

        public PVector MatMul(float[][] a, PVector b)
        {
            float[][] m = VecToMatrix(b);
            return MatrixToVec(MatMul(a, m));
        }

        private float[][] MatMul(float[][] a, float[][] b)
        {
            int colsA = a[0].Length;
            int rowsA = a.Length;
            int colsB = b[0].Length;
            int rowsB = b.Length;

            if (colsA != rowsB)
                throw new Exception("Cols and rows doesn't match!");

            float[][] result = new float[rowsA][];

            for (int i = 0; i < result.Length; i++)
                result[i] = new float[colsB];

            for (int i = 0; i < rowsA; i++)
            for (int j = 0; j < colsB; j++)
            {
                float sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += a[i][k] * b[k][j];
                }

                result[i][j] = sum;
            }

            return result;
        }
    }
}