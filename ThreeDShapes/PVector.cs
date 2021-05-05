namespace ThreeDShapes
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

        public PVector() { }

        public void Scale(float size)
        {
            X *= size;
            Y *= size;
            Z *= size;
        }
    }
}