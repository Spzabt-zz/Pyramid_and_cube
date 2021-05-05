using System;

namespace ThreeDPyramid
{
    public class PVector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public PVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PVector()
        {
        }

        public void Scale(int size)
        {
            X *= size;
            Y *= size;
            Z *= size;
        }

        private static bool FlagsSort(int i, int planeNumber, int[] order)
        {
            bool flag = true;
            for (int j = 0; j < planeNumber; j++)
            {
                if (order[j] == i)
                {
                    flag = false;
                }
            }

            return flag;
        }

        public static void AreaSort(int[] order, float[] d, int faceCount, int faceNumber)
        {
            double k = 1000;
            for (int i = 0; i < 4; i++)
            {
                if (FlagsSort(i, faceNumber, order))
                {
                    if (d[i] < k)
                    {
                        k = d[i];
                        order[faceNumber] = i;
                    }
                }
            }

            faceCount--;
            faceNumber++;

            if (faceCount > 0)
            {
                AreaSort(order, d, faceCount, faceNumber);
            }
        }

        public static void StabilizationPoints(int mouseX, int mouseY, double positionX, double positionY,
            double positionZ, PVector[] view, double coordinateX, double coordinateY,
            double coordinateZ, double deltaN, double[] numberZ)
        {
            double lenght2X = mouseX, l2Y = mouseY, l2Z = 0;
            double lenght1X = positionX, l1Y = positionY, l1Z = 0;


            double deltaX = lenght2X - lenght1X;
            double deltaY = l2Y - l1Y;
            double deltaZ = l2Z - l1Z;


            double number = Math.Sqrt(Math.Abs((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ)));

            deltaX /= number;
            deltaY /= number;
            deltaZ /= number;

            coordinateX = view[0].Y * (view[1].Z - view[2].Z) + view[1].Y * (view[2].Z - view[0].Z) +
                          view[2].Y * (view[0].Z - view[1].Z);
            coordinateY = view[0].Z * (view[1].X - view[2].X) + view[1].Z * (view[2].X - view[0].X) +
                          view[2].Z * (view[0].X - view[1].X);
            coordinateZ = view[0].X * (view[1].Y - view[2].Y) + view[1].X * (view[2].Y - view[0].Y) +
                          view[2].X * (view[0].Y - view[1].Y);

            deltaN = Math.Sqrt(Math.Abs((coordinateX * coordinateX) + (coordinateY * coordinateY) +
                                        (coordinateZ * coordinateZ)));
            coordinateX /= Math.Abs(deltaN);
            coordinateY /= Math.Abs(deltaN);
            coordinateZ /= Math.Abs(deltaN);

            numberZ[0] = (coordinateX * deltaX) + (coordinateY * deltaY) + (coordinateZ * deltaZ);

            coordinateX = view[0].Y * (view[1].Z - view[3].Z) + view[1].Y * (view[3].Z - view[0].Z) +
                          view[3].Y * (view[0].Z - view[1].Z);
            coordinateY = view[0].Z * (view[1].X - view[3].X) + view[1].Z * (view[3].X - view[0].X) +
                          view[3].Z * (view[0].X - view[1].X);
            coordinateZ = view[0].X * (view[1].Y - view[3].Y) + view[1].X * (view[3].Y - view[0].Y) +
                          view[3].X * (view[0].Y - view[1].Y);

            deltaN = Math.Sqrt(Math.Abs((coordinateX * coordinateX) + (coordinateY * coordinateY) +
                                        (coordinateZ * coordinateZ)));
            coordinateX /= Math.Abs(deltaN);
            coordinateY /= Math.Abs(deltaN);
            coordinateZ /= Math.Abs(deltaN);

            numberZ[1] = (coordinateX * deltaX) + (coordinateY * deltaY) + (coordinateZ * deltaZ);

            coordinateX = view[1].Y * (view[2].Z - view[3].Z) + view[2].Y * (view[3].Z - view[1].Z) +
                          view[3].Y * (view[1].Z - view[2].Z);
            coordinateY = view[1].Z * (view[2].X - view[3].X) + view[2].Z * (view[3].X - view[1].X) +
                          view[3].Z * (view[1].X - view[2].X);
            coordinateZ = view[1].X * (view[2].Y - view[3].Y) + view[2].X * (view[3].Y - view[1].Y) +
                          view[3].X * (view[1].Y - view[2].Y);

            deltaN = Math.Sqrt(Math.Abs((coordinateX * coordinateX) + (coordinateY * coordinateY) +
                                        (coordinateZ * coordinateZ)));
            coordinateX /= Math.Abs(deltaN);
            coordinateY /= Math.Abs(deltaN);
            coordinateZ /= Math.Abs(deltaN);

            numberZ[2] = (coordinateX * deltaX) + (coordinateY * deltaY) + (coordinateZ * deltaZ);

            coordinateX = view[0].Y * (view[2].Z - view[3].Z) + view[2].Y * (view[3].Z - view[0].Z) +
                          view[3].Y * (view[0].Z - view[2].Z);
            coordinateY = view[0].Z * (view[2].X - view[3].X) + view[2].Z * (view[3].X - view[0].X) +
                          view[3].Z * (view[0].X - view[2].X);
            coordinateZ = view[0].X * (view[2].Y - view[3].Y) + view[2].X * (view[3].Y - view[0].Y) +
                          view[3].X * (view[0].Y - view[2].Y);

            deltaN = Math.Sqrt(Math.Abs((coordinateX * coordinateX) + (coordinateY * coordinateY) +
                                        (coordinateZ * coordinateZ)));
            coordinateX /= Math.Abs(deltaN);
            coordinateY /= Math.Abs(deltaN);
            coordinateZ /= Math.Abs(deltaN);

            numberZ[3] = (coordinateX * deltaX) + (coordinateY * deltaY) + (coordinateZ * deltaZ);
        }
    }
}