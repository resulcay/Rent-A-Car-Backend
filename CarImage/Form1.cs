using System;
using System.Windows.Forms;

namespace CarImage
{
    public partial class Form1 : Form
    {
        // SqlConnection conn= new SqlConnection("Data Source=(localdb)\mylocal;Initial Catalog=Carrent;Integrated Security=True");
        OpenFileDialog openFilemmm = new OpenFileDialog();
        // ICarImageService asdsd = new ICarImageService();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFilemmm.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFilemmm.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
