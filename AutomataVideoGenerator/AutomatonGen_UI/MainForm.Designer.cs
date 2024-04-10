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
            panel1 = new Panel();
            ModelLabel = new Label();
            ModelListBox = new ComboBox();
            StartStopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).BeginInit();
            ToolPanel.SuspendLayout();
            panel1.SuspendLayout();
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
            ToolPanel.Controls.Add(panel1);
            ToolPanel.Controls.Add(StartStopButton);
            ToolPanel.Dock = DockStyle.Right;
            ToolPanel.Location = new Point(538, 0);
            ToolPanel.Margin = new Padding(0);
            ToolPanel.Name = "ToolPanel";
            ToolPanel.Size = new Size(340, 544);
            ToolPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(ModelLabel);
            panel1.Controls.Add(ModelListBox);
            panel1.Location = new Point(3, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 41);
            panel1.TabIndex = 3;
            // 
            // ModelLabel
            // 
            ModelLabel.AutoSize = true;
            ModelLabel.Location = new Point(3, 8);
            ModelLabel.Name = "ModelLabel";
            ModelLabel.Size = new Size(67, 25);
            ModelLabel.TabIndex = 1;
            ModelLabel.Text = "Model:";
            // 
            // ModelListBox
            // 
            ModelListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModelListBox.FormattingEnabled = true;
            ModelListBox.Location = new Point(76, 5);
            ModelListBox.Name = "ModelListBox";
            ModelListBox.Size = new Size(249, 33);
            ModelListBox.TabIndex = 0;
            ModelListBox.SelectedIndexChanged += ModelListBox_SelectedIndexChanged;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayImageBox;
        private Panel ToolPanel;
        private Button StartStopButton;
        private Panel panel1;
        private Label ModelLabel;
        private ComboBox ModelListBox;
    }
}