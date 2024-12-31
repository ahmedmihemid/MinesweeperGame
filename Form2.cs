using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class Form2 : Form
    {
        private int Bombs;
        private int Time;
        private int size;
        public Form2()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
          
            Form1 form1 = new Form1(Time,Bombs,size);
            form1.ShowDialog();
            form1.Hide();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            Time=Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
            Bombs= Convert.ToInt32(textBox2.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bombs=100;
            Time=120;
            size=30;

            Form1 form1 = new Form1(Time, Bombs,size);
            form1.ShowDialog();
            form1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            size = Convert.ToInt32(textBox3.Text);

            if(size >50 || size <=1)
            {
                MessageBox.Show(" the size will be number bettwen ( 2 , 50 ) ");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
