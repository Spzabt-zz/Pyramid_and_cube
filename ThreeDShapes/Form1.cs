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

namespace ThreeDShapes
{
    public partial class Form1 : Form
    {
        private readonly CubeRotation _cube;
        private Graphics _graphics;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            StartPosition = FormStartPosition.CenterScreen;
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            _cube = new CubeRotation(200);
            var timer = new Timer();
            timer.Tick += (s, e) => { Refresh(); };
            timer.Interval = 17;
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TranslateTransform(Width / 2f, Height / 2f);
            _cube.Draw(_graphics);
        }
    }
}