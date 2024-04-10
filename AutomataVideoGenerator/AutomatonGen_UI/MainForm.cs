using AutomataVideoGenerator.Automatons.GPUCompute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatonGen_UI
{
    public partial class MainForm : Form
    {
        GenericBSN automaton;
        Bitmap image;
        System.Windows.Forms.Timer timer;

        public MainForm()
        {
            automaton = new GenericBSN(40, 40, GenericBSN.defaults.GameOfLife);

            InitializeComponent();

            reDrawMainImage();

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(update);
        }

        private void update(object sender, EventArgs e)
        {
            automaton.update();
            reDrawMainImage();
        }

        private void reDrawMainImage()
        {
            image = automaton.getImage(10);
            DisplayImageBox.Image = image;
        }

        private void DisplayImageBox_Click(object sender, EventArgs e)
        {

        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Interval = 100;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
