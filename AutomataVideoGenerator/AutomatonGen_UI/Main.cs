using AutomataVideoGenerator.Automatons.GPUCompute;
using System.Windows.Forms;

namespace AutomatonGen_UI
{
    public partial class Main : Form
    {
        GenericBSN automaton;
        Bitmap image;
        public Main()
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
    }
}
