using System;
using System.Windows.Forms;

namespace CompilersScannerGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Compilers TINY Language Scanner";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Input Code Is Empty, Please Enter Your Code");
            }
            else
            {
                richTextBox1.Text = Scanner.Scan(textBox1.Text);
                MessageBox.Show("Made By :" + "\n" + "Ammar Moataz 18P6278" + "\n" + "Ali Hesham 18P7355" + "\n" + "Ahmed Adham 18P9139" + "\n" + "Abdulrahman Saeed 18P8700" + "\n" + "Mohamed Mamdouh 18P8906" + "\n" + "Abdelrahman Tarek 18P7159");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
