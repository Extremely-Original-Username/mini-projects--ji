namespace FractauUI
{
    partial class MainForm
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
            DisplayBox = new PictureBox();
            InputBox = new TextBox();
            InputLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DisplayBox).BeginInit();
            SuspendLayout();
            // 
            // DisplayBox
            // 
            DisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DisplayBox.Location = new Point(12, 12);
            DisplayBox.Name = "DisplayBox";
            DisplayBox.Size = new Size(531, 463);
            DisplayBox.SizeMode = PictureBoxSizeMode.Zoom;
            DisplayBox.TabIndex = 0;
            DisplayBox.TabStop = false;
            // 
            // InputBox
            // 
            InputBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InputBox.Location = new Point(549, 42);
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(239, 31);
            InputBox.TabIndex = 1;
            InputBox.TextChanged += InputBox_TextChanged;
            // 
            // InputLabel
            // 
            InputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(549, 14);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(54, 25);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Input";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 487);
            Controls.Add(InputLabel);
            Controls.Add(InputBox);
            Controls.Add(DisplayBox);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DisplayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox DisplayBox;
        private TextBox InputBox;
        private Label InputLabel;
    }
}
