using Fractals;

namespace FractauUI
{
    public partial class MainForm : Form
    {
        Mandelbrot mandelbrot = new Mandelbrot(2000, 100);

        public MainForm()
        {
            InitializeComponent();
            reDraw();
        }

        private void reDraw()
        {
            mandelbrot.update();
            DisplayBox.Image = mandelbrot.getImage();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
