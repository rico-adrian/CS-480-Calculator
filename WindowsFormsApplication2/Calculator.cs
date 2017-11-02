//Rico Adrian
//CS 480 Lab 03
//Details: Creating calculator software with 5 operators *,-,^,+,-
//by converting infix notation into post fix notation

//import statements
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

        //mostly unused (I was new to c# so I tried out stuffs)
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        public Calculator()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) //adding number 1 to textBoxResult when clicked
        {
            textBoxresult.Text += "1";
        }


        private void button2_Click(object sender, EventArgs e) //adding number 2 to textBoxResult when clicked
        {
            textBoxresult.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e) //adding number 1 to textBoxResult when clicked
        {
            textBoxresult.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e) //adding number 4 to textBoxResult when clicked
        {
            textBoxresult.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e) //adding number 5 to textBoxResult when clicked
        {
            textBoxresult.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)//adding number 6 to textBoxResult when clicked
        {
            textBoxresult.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e) //adding number 71 to textBoxResult when clicked
        {
            textBoxresult.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e) //adding number 8 to textBoxResult when clicked
        {
            textBoxresult.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e) //adding number 9 to textBoxResult when clicked
        {
            textBoxresult.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e) //adding number 0 to textBoxResult when clicked
        {
            textBoxresult.Text += "0";
        }

        //textboxResult for all inputs and outputs of the calculator 
        private void textBoxresult_TextChanged(object sender, EventArgs e)
        {
            textBoxresult.ReadOnly = true;

        }

        //button clear( AC ) to clear all elements on textBoxResult
        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBoxresult.Text = String.Empty;
        }

        //adding string/operand x/* to textBoxResult when clicked
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "x";
            operation = '*';

        }


        //equal button is for output all calculations when clicked 
        private void buttonequal_Click(object sender, EventArgs e)
        {

            //try catch block
            try
            {
              
                string tokens = textBoxresult.Text; //declare variable tokens which is the current elements 
                                                    //on the textboxResult. Will be cleared/changed everytime 
                                                    //this button is clicked
                char[] infix = tokens.ToCharArray(); //splitting the tokens of string into chars
                                                     //this array is basically the infix notation
                Stack<char> stackOfCalculator = new Stack<char>(); //declaring a stack consists of chars
                StringBuilder postfix = new StringBuilder(); //declaring a variable stringbuilder for a place
                                                             //of postfix that is going to be converted from infix
                for (int i = 1; i <= infix.Length; i++)
                {
                   
                    //if character of index n-1 is an operator, pop two elements from the stack, perform the
                    //math operation and push the result into the stack. perform the operation based on 
                    //comparing the precedence order.
                    //append 2 spaces is to make sure the postfix calculation works because it does not work
                    //without a space between them sometimes
                    if (IsOperator(infix[i - 1]))
                    {

                        postfix.Append(" ");
                        while (stackOfCalculator.Count() != 0 && stackOfCalculator.Peek() != '('
                            && (Precedence(infix[i - 1]) <= Precedence(stackOfCalculator.Peek())))
                        {

                            postfix.Append(stackOfCalculator.Peek());
                            stackOfCalculator.Pop();
                            postfix.Append(" ");

                        }


                        stackOfCalculator.Push(infix[i - 1]);

                    }
                    //if character of index n - 1 is a digit or comma, append/add the digit into
                    //the postfix stringbuilder. Statement below it is to make sure spaces are always there
                    //during calculations and the else if statement is to append the next number in case the
                    //next element is a number, meaning it's not a one digit number, or it's a decimal number
                    else if (IsDigit(infix[i - 1]))
                    {
                        postfix.Append(infix[i - 1]);
                        if (i < infix.Length)
                        {
                            if (IsOperator(infix[i])||infix[i]=='('||infix[i]==')')
                            {
                                postfix.Append(" ");
                            }
                            else if (IsDigit(infix[i])&&!IsDigit('.'))
                            {                            
                                postfix.Append(infix[i]);
                                i += 1;
                            }
                            else if (IsDigit('.'))
                            {
                                continue;
                            }
                        }
                    }

                    //if the element of index n-1 is a left parentheses, push it into the stack
                    else if (infix[i - 1] == '(')
                    {
                        stackOfCalculator.Push(infix[i - 1]);

                    }

                    //if the element of index n-1 is a right parentheses. while the stack is not empty 
                    //and the top of the stack is not a left parentheses, append the element on the top of
                    //the stack without removing it by using peek, then pop/remove it.
                    else if (infix[i - 1] == ')')
                    {

                        while (stackOfCalculator.Count() != 0 && stackOfCalculator.Peek() != '(')
                        {
                            postfix.Append(stackOfCalculator.Peek());
                            stackOfCalculator.Pop();
                        }
                        stackOfCalculator.Pop();

                    }
                    else
                    {
                        stackOfCalculator.Pop();
                    }
                  


                }

                //after appending and converting infix into postfix, peek and
                //pop the elements from the stack one by one while stack is not empty
                //and appending spaces between them in case it does not calculate
                while (stackOfCalculator.Count != 0)
                {
                    postfix.Append(" ");
                    postfix.Append(stackOfCalculator.Peek());
                    stackOfCalculator.Pop();
                    postfix.Append(" ");
                }

                //convert the result of the postfix from stringbuilder into string
                //and put them in the textbox
                textBoxresult.Text = postfix.ToString();
                //perform the calculation based on the result of postfix using Calculation method
                //and assign the result into a variable resultOfCalculation
                double resultOfCalculation = Calculation(textBoxresult.Text);
                //convert double into string for the calculation and changing the current element
                textBoxresult.Text = resultOfCalculation.ToString();

            }

            catch (System.InvalidOperationException i)
            {

                MessageBox.Show("Invalid operation");
                Application.Restart();

            }
            catch (System.IO.IOException ex2)
            {
                MessageBox.Show("Invalid input");
                Application.Restart();
            }
            

        }

        //adding a string/operand "addition/+" into textBoxResult when clicked
        private void button12_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "+";
            operation = '+';
        }

        //adding a string/operand "subtraction/-" into textBoxResult when clicked
        private void buttonminus_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += "-";
            operation = '-';
        }

        //adding a string/operand "divide/:" into textBoxResult when clicked
        private void buttondivide_Click(object sender, EventArgs e)
        {
            operand1 = textBoxresult.Text;
            textBoxresult.Text += ":";
            operation = '/';
        }


        //method to perform all the calculations 
        //@param string element which is a postfix expression 
        public double Calculation(string element)
        {   
            //creating a stack with data type double
            //, inside the stack are the values entered into calculator
            //that are to be calculated 
            Stack<double> stackOfNumbers = new Stack<double>();

            //assigning the variable element with the postfix expressions
            element = textBoxresult.Text;
            //splitting the element by a separator 'space' and assign the results into an array
            string[] elements = element.Split(' ');

            //iterating through the array
            for (int i = 0; i < elements.Length; i++) {

                double result; //variable to assign the values from index 0 through length in the elements

                //method tryparse toConverts the string representation of all the numbers in the elements to 
                //its double-precision floating-point number equivalent. 
                //A return value indicates whether the conversion succeeded or failed. (boolean)
                //if it returns true, push the element into the stack
                if (double.TryParse(elements[i], out result))
                {
                    stackOfNumbers.Push(result);
                }

                //if it returns false, create a switch statements to evaluate the postfix expressions
                //if the element is not a digit(an operator)
                else
                {
                    switch (elements[i])
                    {
                        //pop/remove 2 elements and evaluate them based on the operation
                        //the result will be pushed into the stack
                        //it will keep iterating until index elements.length()
                        //in the end, return the final results of computation
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

        //method to check if an element is an operation or not
        //if yes, returns true
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

        //method to check if an element is a digit/comma or not
        //if yes, returns true
        private bool IsDigit(char digit)
        {
            if (digit == '0' || digit == '1' || digit == '2' || digit == '3' || digit == '4' || digit == '5' || digit == '6'
               || digit == '7' || digit == '8' || digit == '9' || digit == '.')
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
        
        //precedence order to decide which operation should be computed first
        //the order from top to bottom goes from ^, x/:, +/- (parentheses are not included in this)
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

        //adding a string/operand "^/power" into textBoxResult when clicked
        private void buttonpower_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += " ^ ";
        }

        //adding a string/operand left parentheses into textBoxResult when clicked
        private void buttonleftparentheses_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += "(";
        }

        //adding a string/operand right parentheses into textBoxResult when clicked
        private void buttonrightparentheses_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += ")";
        }

        //adding a string/operand "./comma" into textBoxResult when clicked
        private void buttoncomma_Click(object sender, EventArgs e)
        {
            textBoxresult.Text += ".";
        }

        //delete clear( DEL ) to delete elements from textBoxResult one by one
        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
            if (textBoxresult.Text.Length > 1)
            {
                textBoxresult.Text = textBoxresult.Text.Remove(textBoxresult.Text.Length - 1);
            }
            else
            {
                textBoxresult.Text = "";
            }
        }
    }
}
