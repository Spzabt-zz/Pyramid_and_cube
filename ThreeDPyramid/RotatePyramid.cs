using System;
using System.Collections.Generic;
using System.Drawing;

namespace ThreeDPyramid
{
    public class RotatePyramid
    {
        private PVector[] _vertices;
        private int[][] _faces;
        private readonly int[] _order = new int[4];
        private readonly float[] _d = new float[4];
        private readonly PointF[] _borders = new PointF[4];
        private readonly double[] _numberZ = new double[4];
        private double _delta = Math.PI / 180;
        private double _phi = Math.PI / 180;
        private double _positionX = 0, _positionY = 0, _positionZ = 0;
        private double _numberX, _nY, _nZ;
        private const double LoN = 0;
        private readonly Color _colorF = Color.Aquamarine;
        private readonly Matrix _matrix;
        private static float _angle = 0.0f;
        private readonly int _size;
        private readonly Form1 _form1;

        public RotatePyramid(int size, Form1 form1)
        {
            _size = size;
            _form1 = form1;
            _matrix = new Matrix();
            CubeVertices();
            CubeFaces();
        }

        private void CubeVertices()
        {
            _vertices = new PVector[4];
            _vertices[0] = new PVector(0.5f, 0.5f, 0.5f);
            _vertices[1] = new PVector(0.5f, -0.5f, -0.5f);
            _vertices[2] = new PVector(-0.5f, 0.5f, -0.5f);
            _vertices[3] = new PVector(-0.5f, -0.5f, 0.5f);
        }

        private void CubeFaces()
        {
            _faces = new[]
            {
                new[] {0, 1}, new[] {0, 2},
                new[] {0, 3}, new[] {1, 2},
                new[] {1, 3}, new[] {2, 3}
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

            PVector[] projected = new PVector[4];
            int index = 0;
            //float distance = 2.0f;
            //float z = 0f;
            foreach (var node in _vertices)
            {
                PVector rotated = _matrix.MatMul(rotationX, node);
                rotated = _matrix.MatMul(rotationY, rotated);
                rotated = _matrix.MatMul(rotationZ, rotated);
                /*z = 1.0f / (distance - rotated.Z);
                float z = (node.Z+node.Z+node.Z)/3;
                float[][] projection =
                {
                    new[] {1.0f, 0.0f, 0.0f},
                    new[] {0.0f, 1.0f, 0.0f},
                    //new[] {z, 0.0f, 0 },
                    //new[] {0.0f, z, 0}
                };

                PVector projected2D = _matrix.MatMul(projection, rotated);
                projected2D.Scale(_size);
                _form1.GetX().Text = "X: " + projected2D.X;
                _form1.GetY().Text = "Y: " + projected2D.Y;
                _form1.GetZ().Text = "Z: " + projected2D.Z;
                projected[index] = projected2D;*/
                _form1.GetX().Text = "X: " + rotated.X;
                _form1.GetY().Text = "Y: " + rotated.Y;
                _form1.GetZ().Text = "Z: " + rotated.Z;
                rotated.Scale(_size);
                projected[index] = rotated;
                index++;
            }

            for (int i = 0; i < 4; i++)
            {
                _borders[i].X = projected[i].X;
                _borders[i].Y = projected[i].Y;
            }

            _d[0] = (projected[0].Z + projected[1].Z + projected[2].Z) / 3;
            _d[1] = (projected[0].Z + projected[1].Z + projected[3].Z) / 3;
            _d[2] = (projected[1].Z + projected[2].Z + projected[3].Z) / 3;
            _d[3] = (projected[0].Z + projected[2].Z + projected[3].Z) / 3;

            PVector.AreaSort(_order, _d, 4, 0);
            PVector.StabilizationPoints(_form1.GetMouseX(), _form1.GetMouseY(), _positionX, _positionY, _positionZ,
                projected, _numberX, _nY, _nZ, LoN, _numberZ);

            List<PointF[]> area = new List<PointF[]>
            {
                new PointF[] {_borders[0], _borders[1], _borders[2]},
                new PointF[] {_borders[0], _borders[1], _borders[3]},
                new PointF[] {_borders[1], _borders[2], _borders[3]},
                new PointF[] {_borders[0], _borders[2], _borders[3]}
            };
            
            List<Color> colorsFigure = new List<Color>
            {
                _colorF, _colorF, _colorF, _colorF
            };

            for (int i = 0; i < 4; i++)
            {
                if (_numberZ[_order[i]] >= 0)
                {
                    _positionX = projected[i].X;
                    _positionY = projected[i].Y;
                    _positionZ = projected[i].Z;

                    int color1 = (int) (double) colorsFigure[_order[i]].A;
                    int color2 = (int) (colorsFigure[_order[i]].R * _numberZ[_order[i]]);
                    int color3 = (int) (colorsFigure[_order[i]].G * _numberZ[_order[i]]);
                    int color4 = (int) (colorsFigure[_order[i]].B * _numberZ[_order[i]]);
                    
                    Color glass = Color.FromArgb(color1, color2, color3, color4);
                    graphics.FillPolygon(new SolidBrush(glass), area[_order[i]]);
                    graphics.DrawPolygon(Pens.White, area[_order[i]]);
                    graphics.FillEllipse(Brushes.White, (int) Math.Round(projected[_order[i]].X) - 4,
                        (int) Math.Round(projected[_order[i]].Y) - 4, 8, 8);
                }
                if (_numberZ[_order[i]] <= 0)
                {
                    _positionX = projected[i].X;
                    _positionY = projected[i].Y;
                    _positionZ = projected[i].Z;

                    int color1 = (int) Math.Abs((double) colorsFigure[_order[i]].A);
                    int color2 = (int) Math.Abs(colorsFigure[_order[i]].R * _numberZ[_order[i]]);
                    int color3 = (int) Math.Abs(colorsFigure[_order[i]].G * _numberZ[_order[i]]);
                    int color4 = (int) Math.Abs(colorsFigure[_order[i]].B * _numberZ[_order[i]]);
                    
                    Color glass = Color.FromArgb(color1, color2, color3, color4);
                    graphics.FillPolygon(new SolidBrush(glass), area[_order[i]]);
                    graphics.DrawPolygon(Pens.White, area[_order[i]]);
                    graphics.FillEllipse(Brushes.White, (int) Math.Round(projected[_order[i]].X) - 4,
                        (int) Math.Round(projected[_order[i]].Y) - 4, 8, 8);
                }
            }
            
            /*foreach (var node in projected)
                graphics.FillEllipse(Brushes.White, (int) Math.Round(node.X) - 6,
                    (int) Math.Round(node.Y) - 6, 12, 12);*/
            
            /*foreach (var edge in _faces)
                Connect(edge, projected, graphics);*/

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