namespace MinesweeperGame
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
            this.lebFlagNumber = new System.Windows.Forms.Label();
            this.lebTimer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lebFlagNumber
            // 
            this.lebFlagNumber.AutoSize = true;
            this.lebFlagNumber.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lebFlagNumber.ForeColor = System.Drawing.Color.Lime;
            this.lebFlagNumber.Location = new System.Drawing.Point(564, 9);
            this.lebFlagNumber.Name = "lebFlagNumber";
            this.lebFlagNumber.Size = new System.Drawing.Size(33, 35);
            this.lebFlagNumber.TabIndex = 1;
            this.lebFlagNumber.Text = "0";
            // 
            // lebTimer
            // 
            this.lebTimer.AutoSize = true;
            this.lebTimer.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lebTimer.ForeColor = System.Drawing.Color.Lime;
            this.lebTimer.Location = new System.Drawing.Point(287, 9);
            this.lebTimer.Name = "lebTimer";
            this.lebTimer.Size = new System.Drawing.Size(33, 35);
            this.lebTimer.TabIndex = 2;
            this.lebTimer.Text = "0";
            this.lebTimer.Click += new System.EventHandler(this.lebTimer_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = global::MinesweeperGame.Properties.Resources.pngegg__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(417, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 38);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(866, 756);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lebTimer);
            this.Controls.Add(this.lebFlagNumber);
            this.ForeColor = System.Drawing.Color.Chocolate;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lebFlagNumber;
        private System.Windows.Forms.Label lebTimer;
        private System.Windows.Forms.Button button1;
    }
}

