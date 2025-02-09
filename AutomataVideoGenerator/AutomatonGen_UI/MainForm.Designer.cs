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
            HeightPanel = new Panel();
            HeightControl = new NumericUpDown();
            HeightLabel = new Label();
            WidthPanel = new Panel();
            WidthControl = new NumericUpDown();
            WidthLabel = new Label();
            ModelPanel = new Panel();
            ModelLabel = new Label();
            ModelListBox = new ComboBox();
            StartStopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DisplayImageBox).BeginInit();
            ToolPanel.SuspendLayout();
            HeightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HeightControl).BeginInit();
            WidthPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WidthControl).BeginInit();
            ModelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayImageBox
            // 
            DisplayImageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            ToolPanel.Controls.Add(HeightPanel);
            ToolPanel.Controls.Add(WidthPanel);
            ToolPanel.Controls.Add(ModelPanel);
            ToolPanel.Controls.Add(StartStopButton);
            ToolPanel.Dock = DockStyle.Right;
            ToolPanel.Location = new Point(538, 0);
            ToolPanel.Margin = new Padding(0);
            ToolPanel.Name = "ToolPanel";
            ToolPanel.Size = new Size(340, 544);
            ToolPanel.TabIndex = 1;
            // 
            // HeightPanel
            // 
            HeightPanel.Controls.Add(HeightControl);
            HeightPanel.Controls.Add(HeightLabel);
            HeightPanel.Location = new Point(178, 59);
            HeightPanel.Name = "HeightPanel";
            HeightPanel.Size = new Size(159, 41);
            HeightPanel.TabIndex = 5;
            // 
            // HeightControl
            // 
            HeightControl.Location = new Point(68, 6);
            HeightControl.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            HeightControl.Name = "HeightControl";
            HeightControl.Size = new Size(88, 31);
            HeightControl.TabIndex = 2;
            HeightControl.Value = new decimal(new int[] { 10, 0, 0, 0 });
            HeightControl.ValueChanged += HeightControl_ValueChanged;
            // 
            // HeightLabel
            // 
            HeightLabel.AutoSize = true;
            HeightLabel.Location = new Point(3, 8);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(69, 25);
            HeightLabel.TabIndex = 1;
            HeightLabel.Text = "Height:";
            // 
            // WidthPanel
            // 
            WidthPanel.Controls.Add(WidthControl);
            WidthPanel.Controls.Add(WidthLabel);
            WidthPanel.Location = new Point(6, 59);
            WidthPanel.Name = "WidthPanel";
            WidthPanel.Size = new Size(159, 41);
            WidthPanel.TabIndex = 4;
            // 
            // WidthControl
            // 
            WidthControl.Location = new Point(62, 6);
            WidthControl.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            WidthControl.Name = "WidthControl";
            WidthControl.Size = new Size(88, 31);
            WidthControl.TabIndex = 2;
            WidthControl.Value = new decimal(new int[] { 10, 0, 0, 0 });
            WidthControl.ValueChanged += WidthControl_ValueChanged;
            // 
            // WidthLabel
            // 
            WidthLabel.AutoSize = true;
            WidthLabel.Location = new Point(3, 8);
            WidthLabel.Name = "WidthLabel";
            WidthLabel.Size = new Size(64, 25);
            WidthLabel.TabIndex = 1;
            WidthLabel.Text = "Width:";
            // 
            // ModelPanel
            // 
            ModelPanel.Controls.Add(ModelLabel);
            ModelPanel.Controls.Add(ModelListBox);
            ModelPanel.Location = new Point(3, 12);
            ModelPanel.Name = "ModelPanel";
            ModelPanel.Size = new Size(334, 41);
            ModelPanel.TabIndex = 3;
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
            HeightPanel.ResumeLayout(false);
            HeightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HeightControl).EndInit();
            WidthPanel.ResumeLayout(false);
            WidthPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WidthControl).EndInit();
            ModelPanel.ResumeLayout(false);
            ModelPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DisplayImageBox;
        private Panel ToolPanel;
        private Button StartStopButton;
        private Panel ModelPanel;
        private Label ModelLabel;
        private ComboBox ModelListBox;
        private Panel WidthPanel;
        private Label WidthLabel;
        private NumericUpDown WidthControl;
        private Panel HeightPanel;
        private NumericUpDown HeightControl;
        private Label HeightLabel;
    }
}