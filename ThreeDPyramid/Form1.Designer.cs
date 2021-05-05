namespace ThreeDPyramid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showX = new System.Windows.Forms.Label();
            this.showY = new System.Windows.Forms.Label();
            this.showZ = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // showX
            // 
            this.showX.Location = new System.Drawing.Point(12, 9);
            this.showX.Name = "showX";
            this.showX.Size = new System.Drawing.Size(100, 17);
            this.showX.TabIndex = 0;
            // 
            // showY
            // 
            this.showY.Location = new System.Drawing.Point(12, 26);
            this.showY.Name = "showY";
            this.showY.Size = new System.Drawing.Size(100, 17);
            this.showY.TabIndex = 1;
            // 
            // showZ
            // 
            this.showZ.Location = new System.Drawing.Point(12, 43);
            this.showZ.Name = "showZ";
            this.showZ.Size = new System.Drawing.Size(100, 17);
            this.showZ.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ThreeDPyramid.Properties.Resources.light;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(60, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 64);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.showZ);
            this.Controls.Add(this.showY);
            this.Controls.Add(this.showX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label showX;
        private System.Windows.Forms.Label showY;
        private System.Windows.Forms.Label showZ;

        #endregion
    }
}