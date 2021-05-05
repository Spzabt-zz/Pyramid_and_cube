using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeDPyramid
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private readonly RotatePyramid _pyramid;
        private int _mouseX = 50, _mouseY = 50;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Pyramidka";
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = Color.Black;
            this.showX.ForeColor = Color.White;
            this.showY.ForeColor = Color.White;
            this.showZ.ForeColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            _pyramid = new RotatePyramid(200, this);
            this.Paint += Form1_Paint;
            var timer = new Timer();
            timer.Tick += (s, e) => { Refresh(); };
            timer.Interval = 17;
            timer.Start();
        }

        public Label GetX() { return showX; }

        public Label GetY() { return showY; }

        public Label GetZ() { return showZ; }

        public int GetMouseX() { return _mouseX; }
        
        public int GetMouseY() { return _mouseY; }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TranslateTransform(Width / 2f, Height / 2f);
            _pyramid.Draw(_graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Location = new Point (e.X, e.Y);
            _mouseX = e.X;
            _mouseY = e.Y;
        }
    }
}