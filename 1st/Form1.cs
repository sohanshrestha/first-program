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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student.Text = "Sohan";
            
            string typed_text = student.Text;
            string faculty = Fac_name.Text;


            //string Tenis;
            //string FootBall;
            //string BasketBall;

           // if(Table_Tenis.Checked==true)
           // {
           //     Tenis = Table_Tenis.Text;
           //     MessageBox.Show("Tabale Teniss is selected.", "CheckBox");
           // }
           // if (Foot_Ball.Checked == true)
           // {
           //    FootBall = Foot_Ball.Text;
           //     MessageBox.Show("Football is selected.", "CheckBox");
           // }
           // if (Basket_Ball.Checked == true)
           // {
           //     BasketBall = Basket_Ball.Text;
           //     MessageBox.Show("Basketball is selected.", "CheckBox");
           // }
           

            //MessageBox.Show(faculty, "Faculty");
            //MessageBox.Show(typed_text, "Student Name");
            //MessageBox.Show("Test","Sample");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time_label.Text = DateTime.Now.ToString();
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 calculate = new Form2();
            calculate.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 task = new Form3();
            task.ShowDialog();
            this.Show();
        }

        
    }
}
