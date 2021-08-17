using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1st
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string operation = "";
        decimal old_value = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            setvalue("1");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setvalue("2");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setvalue("3");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setvalue("4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setvalue("5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setvalue("6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setvalue("7");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setvalue("8");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setvalue("9");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setvalue("0");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setvalue(".");
        }
        private void setvalue(string data)
        {
            if(MainText.Text== "+" || MainText.Text=="-" || MainText.Text=="*" || MainText.Text=="/")
            {
                MainText.Text = "";
            }
            MainText.Text = MainText.Text + data;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            old_value =Convert.ToDecimal(MainText.Text);
            operation="+";
            MainText.Text = operation;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            old_value = Convert.ToDecimal(MainText.Text);
            operation = "-";
            MainText.Text = operation;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            old_value = Convert.ToDecimal(MainText.Text);
            operation = "*";
            MainText.Text = operation;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            old_value = Convert.ToDecimal(MainText.Text);
            operation = "/";
            MainText.Text = operation;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            old_value = 0;
            operation = "";
            MainText.Text = "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            old_value = Convert.ToDecimal(MainText.Text);
            decimal square = old_value * old_value;
            MainText.Text =Convert.ToString(square);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            old_value = Convert.ToDecimal(MainText.Text);
            double root = Math.Sqrt(Convert.ToDouble(old_value));
            MainText.Text = Convert.ToString(root);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(MainText.Text=="")
            {
                MessageBox.Show("Empty input");
            }
            else
            {
                decimal new_value = Convert.ToDecimal(MainText.Text);

                switch (operation)
                {
                    case "+":
                        decimal added_value = old_value + new_value;
                        MainText.Text = Convert.ToString(added_value);
                        break;

                    case "-":
                        decimal sub_value = old_value - new_value;
                        MainText.Text = Convert.ToString(sub_value);
                        break;

                    case "*":
                        decimal mul_value = old_value * new_value;
                        MainText.Text = Convert.ToString(mul_value);
                        break;

                    case "/":
                        if (new_value == 0)
                        {
                            MessageBox.Show("Cannot divide by 0.");
                            break;
                        }
                        else
                        {
                            decimal div_value = old_value / new_value;
                            MainText.Text = Convert.ToString(div_value);
                            break;
                        }
                }
            }
            
        }

       
    }
}
