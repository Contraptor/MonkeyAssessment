namespace MonkeyCrossing2
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
            this.btnAddRight = new System.Windows.Forms.Button();
            this.btnAddLeft = new System.Windows.Forms.Button();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnMoveMonkeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddRight
            // 
            this.btnAddRight.Location = new System.Drawing.Point(301, 46);
            this.btnAddRight.Name = "btnAddRight";
            this.btnAddRight.Size = new System.Drawing.Size(75, 32);
            this.btnAddRight.TabIndex = 0;
            this.btnAddRight.Text = "Add Monkey";
            this.btnAddRight.UseVisualStyleBackColor = true;
            this.btnAddRight.Click += new System.EventHandler(this.btnAddRight_Click);
            // 
            // btnAddLeft
            // 
            this.btnAddLeft.Location = new System.Drawing.Point(25, 46);
            this.btnAddLeft.Name = "btnAddLeft";
            this.btnAddLeft.Size = new System.Drawing.Size(75, 32);
            this.btnAddLeft.TabIndex = 1;
            this.btnAddLeft.Text = "Add Monkey";
            this.btnAddLeft.UseVisualStyleBackColor = true;
            this.btnAddLeft.Click += new System.EventHandler(this.btnAddLeft_Click);
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(298, 93);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(35, 13);
            this.lblRight.TabIndex = 2;
            this.lblRight.Text = "label1";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(22, 93);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(35, 13);
            this.lblLeft.TabIndex = 3;
            this.lblLeft.Text = "label2";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(248, 90);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(23, 20);
            this.txt3.TabIndex = 4;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(183, 90);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(23, 20);
            this.txt2.TabIndex = 5;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(118, 90);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(23, 20);
            this.txt1.TabIndex = 6;
            // 
            // btnMoveMonkeys
            // 
            this.btnMoveMonkeys.Location = new System.Drawing.Point(118, 147);
            this.btnMoveMonkeys.Name = "btnMoveMonkeys";
            this.btnMoveMonkeys.Size = new System.Drawing.Size(153, 32);
            this.btnMoveMonkeys.TabIndex = 7;
            this.btnMoveMonkeys.Text = "Move Monkeys";
            this.btnMoveMonkeys.UseVisualStyleBackColor = true;
            this.btnMoveMonkeys.Click += new System.EventHandler(this.btnMoveMonkeys_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 191);
            this.Controls.Add(this.btnMoveMonkeys);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.btnAddLeft);
            this.Controls.Add(this.btnAddRight);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRight;
        private System.Windows.Forms.Button btnAddLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btnMoveMonkeys;
    }
}

