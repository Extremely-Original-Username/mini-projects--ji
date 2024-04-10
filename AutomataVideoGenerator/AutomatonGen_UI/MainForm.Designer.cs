namespace AutomatonGen_UI
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
            DisplayImageBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).BeginInit();
            SuspendLayout();
            // 
            // DisplayImageBox
            // 
            DisplayImageBox.Location = new Point(20, 20);
            DisplayImageBox.Name = "DisplayImageBox";
            DisplayImageBox.Size = new Size(400, 400);
            DisplayImageBox.SizeMode = PictureBoxSizeMode.CenterImage;
            DisplayImageBox.TabIndex = 0;
            DisplayImageBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 444);
            Controls.Add(DisplayImageBox);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayImageBox;
    }
}