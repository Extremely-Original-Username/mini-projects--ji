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
        public MainForm()
        {
            automaton = new GenericBSN(40, 40, GenericBSN.defaults.GameOfLife);

            InitializeComponent();

            reDrawMainImage();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(update);
            timer.Start();

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
    }
}
