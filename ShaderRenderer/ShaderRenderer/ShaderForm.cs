using System.Drawing.Imaging;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ShaderRenderer
{
    public partial class ShaderForm : Form
    {
        private PictureBox pictureBox;
        private Bitmap bmp;
        private Color fillColor = Color.Blue; // Initial color to fill the image with
        private Timer timer;

        public ShaderForm()
        {
            InitializeComponents();
            InitializeImage();

            // Create a timer
            timer = new Timer();
            timer.Interval = 1; // Update interval in milliseconds (e.g., every second)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeComponents()
        {
            this.Text = "Shader Image Display";

            // Create a PictureBox to display the image
            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBox);
        }

        private void InitializeImage()
        {
            int width = 800; // Width of the image
            int height = 600; // Height of the image

            // Create a blank image with the specified width and height
            bmp = new Bitmap(width, height);

            // Fill the entire bitmap with the initial color
            FillImage(bmp, fillColor);

            // Display the image in a PictureBox
            pictureBox.Image = bmp;
        }

        private void FillImage(Bitmap bmp, Color color)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, color);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the color of the image
            fillColor = Color.FromArgb(
                fillColor.A,
                (fillColor.R + 10) % 256, // Update R component (example: increasing by 10)
                (fillColor.G + 5) % 256,  // Update G component (example: increasing by 5)
                (fillColor.B + 3) % 256); // Update B component (example: increasing by 3)

            // Fill the image with the updated color
            FillImage(bmp, fillColor);

            // Refresh the PictureBox to display the updated image
            pictureBox.Refresh();
        }
    }
}