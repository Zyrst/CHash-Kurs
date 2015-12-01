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
            this.textBox1.Text += (1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (2).ToString();
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
    }
}
