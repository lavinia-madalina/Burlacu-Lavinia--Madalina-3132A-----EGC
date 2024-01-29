namespace OpenTK_winforms_z01 {
    partial class OpenGLWnd {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenGLWnd));
            this.glControlDemo = new OpenTK.GLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTranslateCurrentObject = new System.Windows.Forms.Button();
            this.btnResetObjects = new System.Windows.Forms.Button();
            this.btnDrawObject = new System.Windows.Forms.Button();
            this.btnDrawTriangle = new System.Windows.Forms.Button();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawPoints = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.spinnerZposView = new System.Windows.Forms.NumericUpDown();
            this.spinnerYposView = new System.Windows.Forms.NumericUpDown();
            this.spinnerXposView = new System.Windows.Forms.NumericUpDown();
            this.btnMouse3D = new System.Windows.Forms.Button();
            this.btnMouse2D = new System.Windows.Forms.Button();
            this.lblPointerDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAxes = new System.Windows.Forms.CheckBox();
            this.btnBgReset = new System.Windows.Forms.Button();
            this.btnBgRed = new System.Windows.Forms.Button();
            this.btnBgBlue = new System.Windows.Forms.Button();
            this.btnBgWhite = new System.Windows.Forms.Button();
            this.chkCameraControl = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerZposView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerYposView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerXposView)).BeginInit();
            this.SuspendLayout();
            // 
            // glControlDemo
            // 
            this.glControlDemo.BackColor = System.Drawing.Color.Black;
            this.glControlDemo.Location = new System.Drawing.Point(10, 11);
            this.glControlDemo.Name = "glControlDemo";
            this.glControlDemo.Size = new System.Drawing.Size(562, 406);
            this.glControlDemo.TabIndex = 0;
            this.glControlDemo.VSync = false;
            this.glControlDemo.Paint += new System.Windows.Forms.PaintEventHandler(this.glControlDemo_Paint);
            this.glControlDemo.MouseLeave += new System.EventHandler(this.glControlDemo_MouseLeave);
            this.glControlDemo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControlDemo_MouseMove);
            this.glControlDemo.Resize += new System.EventHandler(this.glControlDemo_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTranslateCurrentObject);
            this.panel1.Controls.Add(this.btnDrawObject);
            this.panel1.Controls.Add(this.btnDrawTriangle);
            this.panel1.Controls.Add(this.btnDrawLine);
            this.panel1.Controls.Add(this.btnDrawPoints);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.spinnerZposView);
            this.panel1.Controls.Add(this.spinnerYposView);
            this.panel1.Controls.Add(this.spinnerXposView);
            this.panel1.Controls.Add(this.btnMouse3D);
            this.panel1.Controls.Add(this.btnMouse2D);
            this.panel1.Controls.Add(this.lblPointerDisplay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkAxes);
            this.panel1.Controls.Add(this.btnBgReset);
            this.panel1.Controls.Add(this.btnBgRed);
            this.panel1.Controls.Add(this.btnBgBlue);
            this.panel1.Controls.Add(this.btnBgWhite);
            this.panel1.Location = new System.Drawing.Point(578, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 406);
            this.panel1.TabIndex = 1;
            // 
            // btnTranslateCurrentObject
            // 
            this.btnTranslateCurrentObject.Location = new System.Drawing.Point(98, 256);
            this.btnTranslateCurrentObject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTranslateCurrentObject.Name = "btnTranslateCurrentObject";
            this.btnTranslateCurrentObject.Size = new System.Drawing.Size(44, 145);
            this.btnTranslateCurrentObject.TabIndex = 22;
            this.btnTranslateCurrentObject.Text = "Translate";
            this.btnTranslateCurrentObject.UseVisualStyleBackColor = true;
            this.btnTranslateCurrentObject.Click += new System.EventHandler(this.btnTranslateCurrentObject_Click);
            // 
            // btnResetObjects
            // 
            this.btnResetObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetObjects.Location = new System.Drawing.Point(587, 479);
            this.btnResetObjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetObjects.Name = "btnResetObjects";
            this.btnResetObjects.Size = new System.Drawing.Size(86, 25);
            this.btnResetObjects.TabIndex = 21;
            this.btnResetObjects.Text = "Reset Objects";
            this.btnResetObjects.UseVisualStyleBackColor = true;
            this.btnResetObjects.Click += new System.EventHandler(this.btnResetObjects_Click);
            // 
            // btnDrawObject
            // 
            this.btnDrawObject.Location = new System.Drawing.Point(5, 346);
            this.btnDrawObject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDrawObject.Name = "btnDrawObject";
            this.btnDrawObject.Size = new System.Drawing.Size(88, 25);
            this.btnDrawObject.TabIndex = 20;
            this.btnDrawObject.Text = "Draw Object";
            this.btnDrawObject.UseVisualStyleBackColor = true;
            this.btnDrawObject.Click += new System.EventHandler(this.btnDrawObject_Click);
            // 
            // btnDrawTriangle
            // 
            this.btnDrawTriangle.Location = new System.Drawing.Point(5, 316);
            this.btnDrawTriangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDrawTriangle.Name = "btnDrawTriangle";
            this.btnDrawTriangle.Size = new System.Drawing.Size(88, 25);
            this.btnDrawTriangle.TabIndex = 19;
            this.btnDrawTriangle.Text = "Draw Triangle";
            this.btnDrawTriangle.UseVisualStyleBackColor = true;
            this.btnDrawTriangle.Click += new System.EventHandler(this.btnDrawTriangle_Click);
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.Location = new System.Drawing.Point(5, 286);
            this.btnDrawLine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(88, 25);
            this.btnDrawLine.TabIndex = 18;
            this.btnDrawLine.Text = "Draw Line";
            this.btnDrawLine.UseVisualStyleBackColor = true;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // btnDrawPoints
            // 
            this.btnDrawPoints.Location = new System.Drawing.Point(5, 256);
            this.btnDrawPoints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDrawPoints.Name = "btnDrawPoints";
            this.btnDrawPoints.Size = new System.Drawing.Size(88, 25);
            this.btnDrawPoints.TabIndex = 17;
            this.btnDrawPoints.Text = "Draw Points";
            this.btnDrawPoints.UseVisualStyleBackColor = true;
            this.btnDrawPoints.Click += new System.EventHandler(this.btnDrawPoints_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 234);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "DepthZval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 211);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "DepthYval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "DepthXval";
            // 
            // spinnerZposView
            // 
            this.spinnerZposView.Location = new System.Drawing.Point(5, 232);
            this.spinnerZposView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.spinnerZposView.Name = "spinnerZposView";
            this.spinnerZposView.Size = new System.Drawing.Size(68, 20);
            this.spinnerZposView.TabIndex = 13;
            this.spinnerZposView.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spinnerZposView.ValueChanged += new System.EventHandler(this.spinnerZposView_ValueChanged);
            // 
            // spinnerYposView
            // 
            this.spinnerYposView.Location = new System.Drawing.Point(5, 210);
            this.spinnerYposView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.spinnerYposView.Name = "spinnerYposView";
            this.spinnerYposView.Size = new System.Drawing.Size(68, 20);
            this.spinnerYposView.TabIndex = 12;
            this.spinnerYposView.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinnerYposView.ValueChanged += new System.EventHandler(this.spinnerYposView_ValueChanged);
            // 
            // spinnerXposView
            // 
            this.spinnerXposView.Location = new System.Drawing.Point(5, 187);
            this.spinnerXposView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.spinnerXposView.Name = "spinnerXposView";
            this.spinnerXposView.Size = new System.Drawing.Size(68, 20);
            this.spinnerXposView.TabIndex = 11;
            this.spinnerXposView.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinnerXposView.ValueChanged += new System.EventHandler(this.spinnerXposView_ValueChanged);
            // 
            // btnMouse3D
            // 
            this.btnMouse3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMouse3D.Location = new System.Drawing.Point(74, 159);
            this.btnMouse3D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMouse3D.Name = "btnMouse3D";
            this.btnMouse3D.Size = new System.Drawing.Size(68, 23);
            this.btnMouse3D.TabIndex = 10;
            this.btnMouse3D.Text = "3D move";
            this.btnMouse3D.UseVisualStyleBackColor = true;
            this.btnMouse3D.Click += new System.EventHandler(this.btnMouse3D_Click);
            // 
            // btnMouse2D
            // 
            this.btnMouse2D.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMouse2D.Location = new System.Drawing.Point(5, 159);
            this.btnMouse2D.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMouse2D.Name = "btnMouse2D";
            this.btnMouse2D.Size = new System.Drawing.Size(68, 23);
            this.btnMouse2D.TabIndex = 9;
            this.btnMouse2D.Text = "2D move";
            this.btnMouse2D.UseVisualStyleBackColor = true;
            this.btnMouse2D.Click += new System.EventHandler(this.btnMouse2D_Click);
            // 
            // lblPointerDisplay
            // 
            this.lblPointerDisplay.AutoSize = true;
            this.lblPointerDisplay.Location = new System.Drawing.Point(3, 390);
            this.lblPointerDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPointerDisplay.Name = "lblPointerDisplay";
            this.lblPointerDisplay.Size = new System.Drawing.Size(0, 13);
            this.lblPointerDisplay.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(98, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Oy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(122, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Oz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(75, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ox";
            // 
            // chkAxes
            // 
            this.chkAxes.AutoSize = true;
            this.chkAxes.Checked = true;
            this.chkAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAxes.Location = new System.Drawing.Point(3, 137);
            this.chkAxes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAxes.Name = "chkAxes";
            this.chkAxes.Size = new System.Drawing.Size(78, 17);
            this.chkAxes.TabIndex = 4;
            this.chkAxes.Text = "Show axes";
            this.chkAxes.UseVisualStyleBackColor = true;
            this.chkAxes.CheckedChanged += new System.EventHandler(this.chkAxes_CheckedChanged);
            // 
            // btnBgReset
            // 
            this.btnBgReset.Location = new System.Drawing.Point(3, 106);
            this.btnBgReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBgReset.Name = "btnBgReset";
            this.btnBgReset.Size = new System.Drawing.Size(139, 27);
            this.btnBgReset.TabIndex = 3;
            this.btnBgReset.Text = "Reset BG";
            this.btnBgReset.UseVisualStyleBackColor = true;
            this.btnBgReset.Click += new System.EventHandler(this.btnBgReset_Click);
            // 
            // btnBgRed
            // 
            this.btnBgRed.ForeColor = System.Drawing.Color.Red;
            this.btnBgRed.Location = new System.Drawing.Point(3, 74);
            this.btnBgRed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBgRed.Name = "btnBgRed";
            this.btnBgRed.Size = new System.Drawing.Size(139, 27);
            this.btnBgRed.TabIndex = 2;
            this.btnBgRed.Text = "Change BG Red";
            this.btnBgRed.UseVisualStyleBackColor = true;
            this.btnBgRed.Click += new System.EventHandler(this.btnBgRed_Click);
            // 
            // btnBgBlue
            // 
            this.btnBgBlue.ForeColor = System.Drawing.Color.Blue;
            this.btnBgBlue.Location = new System.Drawing.Point(3, 42);
            this.btnBgBlue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBgBlue.Name = "btnBgBlue";
            this.btnBgBlue.Size = new System.Drawing.Size(139, 27);
            this.btnBgBlue.TabIndex = 1;
            this.btnBgBlue.Text = "Change BG Blue";
            this.btnBgBlue.UseVisualStyleBackColor = true;
            this.btnBgBlue.Click += new System.EventHandler(this.btnBgBlue_Click);
            // 
            // btnBgWhite
            // 
            this.btnBgWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBgWhite.ForeColor = System.Drawing.Color.White;
            this.btnBgWhite.Location = new System.Drawing.Point(3, 11);
            this.btnBgWhite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBgWhite.Name = "btnBgWhite";
            this.btnBgWhite.Size = new System.Drawing.Size(139, 27);
            this.btnBgWhite.TabIndex = 0;
            this.btnBgWhite.Text = "Change BG White";
            this.btnBgWhite.UseVisualStyleBackColor = true;
            this.btnBgWhite.Click += new System.EventHandler(this.btnBgWhite_Click);
            // 
            // chkCameraControl
            // 
            this.chkCameraControl.AutoSize = true;
            this.chkCameraControl.Location = new System.Drawing.Point(586, 434);
            this.chkCameraControl.Name = "chkCameraControl";
            this.chkCameraControl.Size = new System.Drawing.Size(95, 17);
            this.chkCameraControl.TabIndex = 2;
            this.chkCameraControl.Text = "CameraControl";
            this.chkCameraControl.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(586, 457);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // OpenGLWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 578);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnResetObjects);
            this.Controls.Add(this.chkCameraControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.glControlDemo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OpenGLWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenGL testcase 01";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerZposView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerYposView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerXposView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControlDemo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBgReset;
        private System.Windows.Forms.Button btnBgRed;
        private System.Windows.Forms.Button btnBgBlue;
        private System.Windows.Forms.Button btnBgWhite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAxes;
        private System.Windows.Forms.Label lblPointerDisplay;
        private System.Windows.Forms.Button btnMouse3D;
        private System.Windows.Forms.Button btnMouse2D;
        private System.Windows.Forms.NumericUpDown spinnerXposView;
        private System.Windows.Forms.NumericUpDown spinnerZposView;
        private System.Windows.Forms.NumericUpDown spinnerYposView;
        private System.Windows.Forms.Button btnTranslateCurrentObject;
        private System.Windows.Forms.Button btnResetObjects;
        private System.Windows.Forms.Button btnDrawObject;
        private System.Windows.Forms.Button btnDrawTriangle;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawPoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCameraControl;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

