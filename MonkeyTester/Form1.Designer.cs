namespace MonkeyTester
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
            this.btnTest = new System.Windows.Forms.Button();
            this.txtbxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(58, 18);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(151, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test!";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // txtbxOutput
            // 
            this.txtbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxOutput.Location = new System.Drawing.Point(12, 47);
            this.txtbxOutput.Multiline = true;
            this.txtbxOutput.Name = "txtbxOutput";
            this.txtbxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbxOutput.Size = new System.Drawing.Size(260, 203);
            this.txtbxOutput.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtbxOutput);
            this.Controls.Add(this.btnTest);
            this.Name = "Form1";
            this.Text = "Tester - Monkey Chasm Traversal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtbxOutput;
    }
}

