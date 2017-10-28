using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {

        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "0";
        }

        private void textBoxresult_TextChanged(object sender, EventArgs e)
        {
            textBoxresult.ReadOnly = true;
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBoxresult.Text = String.Empty;
        }

        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += " x ";
            operation = '*';
            //textBoxresult.Text = string.Empty;
        }



        private void buttonequal_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += " + ";
            operation = '+';
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += " - ";
            operation = '-';
        }

        private void buttondivide_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += " : ";
            operation = '/';
        }
        


        
       
    }
}
