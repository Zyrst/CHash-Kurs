using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift_4
{
    public partial class Form1 : Form
    {
        public string currentString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
            {
                this.textBox1.Text = this.textBox1.Text.Remove(this.textBox1.Text.Length - 1);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
        }
    }
}
