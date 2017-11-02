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
            //textBoxresult.ReadOnly = true;
            //InfixToPostFixConverter
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBoxresult.Text = String.Empty;
        }

        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "x";
            operation = '*';
            //textBoxresult.Text = string.Empty;
        }



        private void buttonequal_Click(object sender, EventArgs e)
        {
            string tokens = textBoxresult.Text;

            char[] infix = tokens.ToCharArray(); //splitting the tokens of string
            //textBoxresult.Text = Text.ToString();
            Stack<char> stackOfCalculator = new Stack<char>();
            // for(int i=0;i<infix.Length;i++)
            // {
            //double x = Convert.ToDouble(tokens[i]);
            //stackOfCalculator.Push(infix[i]);
            //}
            //textBoxresult.Text=stackOfCalculator.Pop();

            StringBuilder postfix = new StringBuilder();
            for (int i = 1; i <= infix.Length; i++)
            {
               
                if (infix[i - 1] == ' ' || infix[i - 1] == '.') {
                    continue;
                }
                
                else if (IsOperator(infix[i - 1]))
                {
                  
                    postfix.Append(" ");
                    while (stackOfCalculator.Count() != 0 && stackOfCalculator.Peek() != '(' && (Precedence(infix[i - 1]) <= Precedence(stackOfCalculator.Peek())))
                    {

                        postfix.Append(stackOfCalculator.Peek());
                        stackOfCalculator.Pop();
                        postfix.Append(" ");

                    }
                   
                    stackOfCalculator.Push(infix[i - 1]);

                }
                else if (IsDigit(infix[i - 1]))
                {
   
     
                    postfix.Append(infix[i - 1]);
                    if (i<infix.Length) { 
                    if (IsOperator(infix[i]))
                        {
                            postfix.Append(" ");
                        }
                        else if(IsDigit(infix[i]))
                        {
                            postfix.Append(infix[i]);
                            i += 1;
                        }
                    }
                }

                else if (infix[i - 1] == '(')
                {
                    stackOfCalculator.Push(infix[i - 1]);
                }

                else if (infix[i - 1] == ')')
                {
                    while (stackOfCalculator.Count() != 0 && stackOfCalculator.Peek() != '(')
                    {
                        postfix.Append(stackOfCalculator.Peek());
                        stackOfCalculator.Pop();
                    }
                    stackOfCalculator.Pop();
                }



            }

            while (stackOfCalculator.Count != 0)
            {
                postfix.Append(" ");
                postfix.Append(stackOfCalculator.Peek());
                stackOfCalculator.Pop();
                postfix.Append(" ");
            }

            textBoxresult.Text = postfix.ToString();
            //infixToPostfix(infix);
            //textBoxresult.Text = "55 6 :";
            //string[] elements = postfix.ToString().Split(' ');
            double x = Calculation(textBoxresult.Text);
            //postfix.Append("2");
            //textBoxresult.Text="";
            textBoxresult.Text = x.ToString();
            //textBoxresult.Text=postfix.ToString();



        }

        private void button12_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "+";
            operation = '+';
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "-";
            operation = '-';
        }

        private void buttondivide_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += ":";
            operation = '/';
        }


        public double Calculation(string element)
        {
            Stack<double> stackOfNumbers = new Stack<double>();
            element = textBoxresult.Text;
            string[] elements = element.Split(' ');

            for (int i= 0;i<elements.Length;i++) { 
            
                double result;
                if (double.TryParse(elements[i], out result))
                {
                    stackOfNumbers.Push(result);
                }
                else
                {
                    switch (elements[i])
                    {
                        case "X":
                        case "x":
                            {
                             
                                stackOfNumbers.Push(stackOfNumbers.Pop() * stackOfNumbers.Pop());
                                 break;
                            }
                        case "/":
                        case ":":
                            {
                                result = stackOfNumbers.Pop();
                                stackOfNumbers.Push(stackOfNumbers.Pop() / result);
                                break;
                            }
                        case "^":
                            {
                                result = stackOfNumbers.Pop();
                                stackOfNumbers.Push(Math.Pow(stackOfNumbers.Pop(), result));
                                break;
                            }
                        case "+":
                            {
                                stackOfNumbers.Push(stackOfNumbers.Pop() + stackOfNumbers.Pop());
                                break;
                            }
                        case "-":
                            {
                                result = stackOfNumbers.Pop();
                                stackOfNumbers.Push(stackOfNumbers.Pop() - result);
                                break;
                            }
                    }
                }

            }
            return stackOfNumbers.Pop();
        }

        private bool IsOperator(char operation)
        {
            if (operation == '+' || operation == '-' || operation == 'x' || operation == ':' || operation == '^')

            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDigit(char digit)
        {
             if (digit == '0' || digit == '1' || digit == '2' || digit == '3' || digit == '4' || digit == '5' || digit == '6'
                || digit == '7' || digit == '8' || digit == '9')
            {
                return true;
            }
            else if (digit == '+' || digit == '-' || digit == 'x' || digit == ':' || digit == '^' || digit == '(' || digit == ')')

            {
                return false;
            }
            
            else {
                return false;
            }
        }
        
        private int Precedence(char operation)
            {
                if (operation == '^')
                {
                    return 3;
                }
                else if (operation == 'x' || operation == ':')
                {
                    return 2;
                }
                else if (operation == '+' || operation == '-')
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        private void buttonpower_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += " ^ ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonleftparentheses_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "(";
        }

        private void buttonrightparentheses_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += ")";
        }

        private void buttoncomma_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += ".";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
