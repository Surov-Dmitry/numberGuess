using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuess
{
    public partial class Form1 : Form
    {
        int min;
        int max;
        int tryCount;
        int num;
        int num1;
        bool weak;
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            min = 0;
            max = 100;
            tryCount = 0;
            num1 = 0;
            weak = false;
            textBox2.Text = Convert.ToString(min);
            textBox3.Text = Convert.ToString(max);
            pictureBox1.Image = new Bitmap(@"img\2YgZ.gif");
            pictureBox2.Visible = false;
            label1.BackColor = Color.LightGreen;
            label2.BackColor = Color.LightGreen;
            label3.BackColor = Color.LightGreen;
            label4.BackColor = Color.LightGreen;
            radioButton1.BackColor = Color.LightGreen;
            radioButton2.BackColor = Color.LightGreen;
            button1.BackColor = Color.LightGreen;
            button2.BackColor = Color.LightGreen;
            button3.BackColor = Color.LightGreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = radioButton2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (int.TryParse(textBox1.Text, out num) && num < max && num > min)
            {
                if (radioButton1.Checked) 
                {
                    if (tryCount == 0) { num1 = rnd.Next(min, max); }  
                    tryCount++;
                    if (num1 == num)
                    {
                        pictureBox2.Image = new Bitmap(@"img\2xxs.gif");
                        pictureBox2.Visible = true;
                        label2.Text = $"You guessed number {num} on the {tryCount} try!";
                        tryCount = 0;
                    }
                    else if (num < num1) { label2.Text = $"Guessed number bigger than {num}."; }
                    else if (num > num1) { label2.Text = $"Guessed number less than {num}."; }
                    if (weak == true) 
                    {
                        pictureBox2.Image = new Bitmap(@"img\2GqA.gif");
                        pictureBox2.Visible = true;
                        label2.Text = $"You lose!!! Number was {num1}";
                        tryCount = 0; weak = false; 
                    }
                    
                    //VICTORY MESSAGE
                }
                else if (radioButton2.Checked) 
                {
                    do
                    {
                        num1 = rnd.Next(min, max);
                        tryCount++;
                    } while (num1 != num);
                    label2.Text = $"You to guess number {num}.\nComputer guessed it on the {tryCount} try!";
                    tryCount = 0;
                    //VICTORY MESSAGE
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            if(tryCount == 0)
            {
                pictureBox2.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(textBox2.Text, out tmp) && tmp < max) { min = tmp; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            if (int.TryParse(textBox3.Text, out tmp) && tmp > min) { max = tmp; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            weak = true;
            button1_Click(sender,e);
        }
    }
}
