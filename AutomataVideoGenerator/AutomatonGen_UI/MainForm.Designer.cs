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
            ToolPanel = new Panel();
            StartStopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).BeginInit();
            ToolPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayImageBox
            // 
            DisplayImageBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DisplayImageBox.Location = new Point(12, 12);
            DisplayImageBox.Name = "DisplayImageBox";
            DisplayImageBox.Size = new Size(520, 520);
            DisplayImageBox.SizeMode = PictureBoxSizeMode.CenterImage;
            DisplayImageBox.TabIndex = 0;
            DisplayImageBox.TabStop = false;
            // 
            // ToolPanel
            // 
            ToolPanel.BackColor = SystemColors.ControlLight;
            ToolPanel.Controls.Add(StartStopButton);
            ToolPanel.Dock = DockStyle.Right;
            ToolPanel.Location = new Point(538, 0);
            ToolPanel.Margin = new Padding(0);
            ToolPanel.Name = "ToolPanel";
            ToolPanel.Size = new Size(340, 544);
            ToolPanel.TabIndex = 1;
            // 
            // StartStopButton
            // 
            StartStopButton.Dock = DockStyle.Bottom;
            StartStopButton.Location = new Point(0, 488);
            StartStopButton.Margin = new Padding(5);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(340, 56);
            StartStopButton.TabIndex = 2;
            StartStopButton.Text = "Start / Stop";
            StartStopButton.UseVisualStyleBackColor = true;
            StartStopButton.Click += StartStopButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(ToolPanel);
            Controls.Add(DisplayImageBox);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).EndInit();
            ToolPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayImageBox;
        private Panel ToolPanel;
        private Button StartStopButton;
    }
}