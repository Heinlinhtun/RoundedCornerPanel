namespace RPanel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rPanel1 = new CustomComponents.RPanel();
            this.SuspendLayout();
            // 
            // rPanel1
            // 
            this.rPanel1.BackColor = System.Drawing.Color.White;
            this.rPanel1.BorderRadius = 50;
            this.rPanel1.ForeColor = System.Drawing.Color.Black;
            this.rPanel1.GradientAngle = 45F;
            this.rPanel1.GradientBottomColor = System.Drawing.Color.SkyBlue;
            this.rPanel1.GradientTopColor = System.Drawing.Color.DodgerBlue;
            this.rPanel1.Location = new System.Drawing.Point(546, 191);
            this.rPanel1.Name = "rPanel1";
            this.rPanel1.Size = new System.Drawing.Size(323, 164);
            this.rPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 550);
            this.Controls.Add(this.rPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomComponents.RPanel rPanel1;
    }
}