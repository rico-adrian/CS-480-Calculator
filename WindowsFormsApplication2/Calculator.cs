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

            //textBoxresult.Text = Text.ToString();
            Stack<string> elements = new Stack<string>();
             
            textBoxresult.Text=evalrpn(elements).ToString();


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

        private double evalrpn(Stack<string> stackOfNumbers)
        {
            string[] splittingString = textBoxresult.Text.Split();
            for (int i = 0; i < 3; i++)
            {
                stackOfNumbers.Push(splittingString[i]);
            }
            string elements = stackOfNumbers.Pop();
            double x, y;
            if (!Double.TryParse(elements, out x))
            {
                y = evalrpn(stackOfNumbers);
                x = evalrpn(stackOfNumbers);
                if (elements == "+") x += y;
                else if (elements == "-") x -= y;
                else if (elements == "*") x *= y;
                else if (elements == "/") x /= y;
                else throw new Exception();
            }
            return x;
        }



    }
}
