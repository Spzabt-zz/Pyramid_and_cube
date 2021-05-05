using System;
using System.Drawing;
using System.Linq;

namespace ThreeDShapes
{
    class CubeRotation
    {
        private PVector[] _vertices;
        private int[][] _faces;
        private static float _angle = 0.0f;
        private readonly float _size;
        private readonly Matrix _matrix;

        public CubeRotation(float size)
        {
            _size = size;
            _matrix = new Matrix();
            CubeVertices();
            CubeFaces();
        }
        private void CubeVertices()
        {
            _vertices = new PVector[8];
            _vertices[0] = new PVector(-0.5f, -0.5f, -0.5f);
            _vertices[1] = new PVector(0.5f, -0.5f, -0.5f);
            _vertices[2] = new PVector(0.5f, 0.5f, -0.5f);
            _vertices[3] = new PVector(-0.5f, 0.5f, -0.5f);
            _vertices[4] = new PVector(-0.5f, -0.5f, 0.5f);
            _vertices[5] = new PVector(0.5f, -0.5f, 0.5f);
            _vertices[6] = new PVector(0.5f, 0.5f, 0.5f);
            _vertices[7] = new PVector(-0.5f, 0.5f, 0.5f);
        }

        private void CubeFaces()
        {
            _faces = new[]
            {
                new[] {0, 1}, new[] {1, 2}, new[] {2, 3}, new[] {3, 0},
                new[] {4, 5}, new[] {5, 6}, new[] {6, 7}, new[] {7, 4},
                new[] {0, 4}, new[] {1, 5}, new[] {2, 6}, new[] {3, 7}
            };
        }

        public void Draw(Graphics graphics)
        {
            float[][] rotationX =
            {
                new[] {1.0f, 0.0f, 0.0f},
                new[] {0.0f, (float) Math.Cos(_angle), (float) -Math.Sin(_angle)},
                new[] {0.0f, (float) Math.Sin(_angle), (float) Math.Cos(_angle)}
            };

            float[][] rotationY =
            {
                new[] {(float) Math.Cos(_angle), 0.0f, (float) -Math.Sin(_angle)},
                new[] {0.0f, 1.0f, 0.0f},
                new[] {(float) Math.Sin(_angle), 0.0f, (float) Math.Cos(_angle)}
            };

            float[][] rotationZ =
            {
                new[] {(float) Math.Cos(_angle), (float) -Math.Sin(_angle), 0.0f},
                new[] {(float) Math.Sin(_angle), (float) Math.Cos(_angle), 0.0f},
                new[] {0.0f, 0.0f, 1.0f}
            };

            PVector[] projected = new PVector[8];
            int index = 0;
            float distance = 3.0f;
            foreach (var node in _vertices)
            {
                PVector rotated = _matrix.MatMul(rotationY, node);
                rotated = _matrix.MatMul(rotationX, rotated);
                rotated = _matrix.MatMul(rotationZ, rotated);

                float z = 2.0f / (distance - rotated.Z);
                float[][] projection =
                {
                    new[] {z, 0.0f, 0.0f},
                    new[] {0.0f, z, 0.0f}
                };

                PVector projected2D = _matrix.MatMul(projection, rotated);
                projected2D.Scale(_size);
                projected[index] = projected2D;
                index++;
            }

            foreach (var node in projected)
            {
                graphics.FillEllipse(Brushes.White, (int) Math.Round(node.X) - 4,
                    (int) Math.Round(node.Y) - 4, 8, 8);
            }

            foreach (var edge in _faces)
                Connect(edge, projected, graphics);

            _angle += 0.01f;
        }

        private void Connect(int[] face, PVector[] points, Graphics graphics)
        {
            var xy1 = points[face[0]];
            var xy2 = points[face[1]];
            graphics.DrawLine(Pens.White, (int) Math.Round(xy1.X), (int) Math.Round(xy1.Y),
                (int) Math.Round(xy2.X), (int) Math.Round(xy2.Y));
        }
    }
}