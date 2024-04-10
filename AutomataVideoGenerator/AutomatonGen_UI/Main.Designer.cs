namespace AutomatonGen_UI
{
    partial class Main
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
            DisplayImageBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).BeginInit();
            SuspendLayout();
            // 
            // DisplayImageBox
            // 
            DisplayImageBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DisplayImageBox.Location = new Point(0, 0);
            DisplayImageBox.Name = "DisplayImageBox";
            DisplayImageBox.Size = new Size(400, 400);
            DisplayImageBox.TabIndex = 0;
            DisplayImageBox.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DisplayImageBox);
            Name = "Main";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayImageBox;
    }
}
