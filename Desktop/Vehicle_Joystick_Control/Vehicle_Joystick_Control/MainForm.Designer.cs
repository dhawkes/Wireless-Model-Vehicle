namespace Vehicle_Joystick_Control
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.leftStickPB = new System.Windows.Forms.PictureBox();
            this.rightStickPB = new System.Windows.Forms.PictureBox();
            this.buttonsTB = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.goBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leftStickPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStickPB)).BeginInit();
            this.SuspendLayout();
            // 
            // leftStickPB
            // 
            this.leftStickPB.BackColor = System.Drawing.SystemColors.Window;
            this.leftStickPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftStickPB.Location = new System.Drawing.Point(12, 12);
            this.leftStickPB.Name = "leftStickPB";
            this.leftStickPB.Size = new System.Drawing.Size(200, 200);
            this.leftStickPB.TabIndex = 0;
            this.leftStickPB.TabStop = false;
            this.leftStickPB.Paint += new System.Windows.Forms.PaintEventHandler(this.leftStickPB_Paint);
            // 
            // rightStickPB
            // 
            this.rightStickPB.BackColor = System.Drawing.SystemColors.Window;
            this.rightStickPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightStickPB.Location = new System.Drawing.Point(237, 12);
            this.rightStickPB.Name = "rightStickPB";
            this.rightStickPB.Size = new System.Drawing.Size(200, 200);
            this.rightStickPB.TabIndex = 1;
            this.rightStickPB.TabStop = false;
            this.rightStickPB.Paint += new System.Windows.Forms.PaintEventHandler(this.rightStickPB_Paint);
            // 
            // buttonsTB
            // 
            this.buttonsTB.BackColor = System.Drawing.SystemColors.Window;
            this.buttonsTB.Enabled = false;
            this.buttonsTB.Location = new System.Drawing.Point(12, 228);
            this.buttonsTB.Name = "buttonsTB";
            this.buttonsTB.ReadOnly = true;
            this.buttonsTB.Size = new System.Drawing.Size(425, 26);
            this.buttonsTB.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // goBT
            // 
            this.goBT.Location = new System.Drawing.Point(12, 270);
            this.goBT.Name = "goBT";
            this.goBT.Size = new System.Drawing.Size(425, 38);
            this.goBT.TabIndex = 3;
            this.goBT.Text = "GO! (Override)";
            this.goBT.UseVisualStyleBackColor = true;
            this.goBT.Click += new System.EventHandler(this.goBT_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(455, 321);
            this.Controls.Add(this.goBT);
            this.Controls.Add(this.buttonsTB);
            this.Controls.Add(this.rightStickPB);
            this.Controls.Add(this.leftStickPB);
            this.Name = "MainForm";
            this.Text = "Joystick -";
            ((System.ComponentModel.ISupportInitialize)(this.leftStickPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightStickPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox leftStickPB;
        private System.Windows.Forms.PictureBox rightStickPB;
        private System.Windows.Forms.TextBox buttonsTB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button goBT;
    }
}

