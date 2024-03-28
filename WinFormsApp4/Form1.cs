namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private Color currentColor = Color.Black;
        private bool isDrawing = false;
        private Point previousPoint;
        private Bitmap drawingSurface = new Bitmap(800, 600);
        private Pen pen = new Pen(Color.Black, 4); // Deklarera en global penna med en standard f�rg och tjocklek

        public Form1()
        {
            InitializeComponent();
            InitializeDrawingSurface();
        }

        private void InitializeDrawingSurface()
        {
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    g.DrawLine(pen, previousPoint, e.Location);
                }
                previousPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingSurface, Point.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                pen.Color = currentColor; // Uppdatera pennans f�rg n�r anv�ndaren v�ljer en ny f�rg fr�n dialogrutan
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeDrawingSurface();
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ange �nskad pennans tjocklek (i pixlar):", "�ndra pennans tjocklek", "4");

            int penWidth;
            if (int.TryParse(input, out penWidth))
            {
                pen.Width = penWidth; // Uppdatera tjockleken f�r den globala pennan
                pictureBox1.Invalidate(); // Uppdatera PictureBox f�r att visa �ndringar i tjocklek p� ritomr�det
            }
            else
            {
                MessageBox.Show("Ogiltig inmatning. Ange ett giltigt heltal f�r tjocklek.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
