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

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            //Compensating for strange rotation - probably a mistake somewhere.
            if (InputBox.Text.ToUpper() == "W")
            {
                mandelbrot.step(-0.5f, 0);
            }
            if (InputBox.Text.ToUpper() == "S")
            {
                mandelbrot.step(0.5f, 0);
            }
            if (InputBox.Text.ToUpper() == "A")
            {
                mandelbrot.step(0, -0.5f);
            }
            if (InputBox.Text.ToUpper() == "D")
            {
                mandelbrot.step(0, 0.5f);
            }

            if (InputBox.Text.ToUpper() == "Q")
            {
                mandelbrot.multiplyZoom(-2f);
            }
            if (InputBox.Text.ToUpper() == "E")
            {
                mandelbrot.multiplyZoom(2);
            }

            InputBox.Clear();
            reDraw();
        }
    }
}
