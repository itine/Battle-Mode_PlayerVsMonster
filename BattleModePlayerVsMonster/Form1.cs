using BattleModePlayerVsMonster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleModePlayerVsMonster
{
    public partial class Form1 : Form
    {
        int playerLevel = -1;

        public Form1()
        {
            InitializeComponent();
        }
        Player player;
        GameEntities db = new GameEntities();
        private static int monster = -1;

        

        private void button30_Click(object sender, EventArgs e)
        {
            monster = 13;
            pictureBox1.BackgroundImage = button30.BackgroundImage;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            monster = 14;
            pictureBox1.BackgroundImage = button29.BackgroundImage;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void nextStepBtn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

            }
            else if (radioButton2.Checked)
            {

            }
            else if (radioButton3.Checked)
            {

            }
            else
               return;
        }

        //set stats
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            player.PlayerLevel = Int32.Parse(textBox7.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            player.Attack = Int32.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            player.Defence = Int32.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            player.SpellPower = Int32.Parse(textBox6.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            player.HPBottleQuantity = Int32.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            player.MPBottleQuantity = Int32.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            player.DiamondQuantity = Int32.Parse(textBox3.Text);
        }

        //монстры варвара
        private void button4_Click_1(object sender, EventArgs e)
        {
            monster = 1;
            pictureBox1.BackgroundImage = button4.BackgroundImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monster = 2;
            pictureBox1.BackgroundImage = button5.BackgroundImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            monster = 3;
            pictureBox1.BackgroundImage = button6.BackgroundImage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            monster = 4;
            pictureBox1.BackgroundImage = button7.BackgroundImage;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            monster = 5;
            pictureBox1.BackgroundImage = button8.BackgroundImage;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            monster = 6;
            pictureBox1.BackgroundImage = button9.BackgroundImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            monster = 7;
            pictureBox1.BackgroundImage = button10.BackgroundImage;
        }

        //монстры паладина
        private void button35_Click(object sender, EventArgs e)
        {
            monster = 8;
            pictureBox1.BackgroundImage = button35.BackgroundImage;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            monster = 9;
            pictureBox1.BackgroundImage = button34.BackgroundImage;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            monster = 10;
            pictureBox1.BackgroundImage = button33.BackgroundImage;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            monster = 11;
            pictureBox1.BackgroundImage = button32.BackgroundImage;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            monster = 12;
            pictureBox1.BackgroundImage = button31.BackgroundImage;
        }

        //монстры мага
        private void button11_Click(object sender, EventArgs e)
        {
            monster = 15;
            pictureBox1.BackgroundImage = button11.BackgroundImage;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            monster = 16;
            pictureBox1.BackgroundImage = button12.BackgroundImage;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            monster = 17;
            pictureBox1.BackgroundImage = button13.BackgroundImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            monster = 18;
            pictureBox1.BackgroundImage = button14.BackgroundImage;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            monster = 19;
            pictureBox1.BackgroundImage = button15.BackgroundImage;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            monster = 20;
            pictureBox1.BackgroundImage = button16.BackgroundImage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            monster = 21;
            pictureBox1.BackgroundImage = button17.BackgroundImage;
        }

        //монстры некроманта
        private void button18_Click(object sender, EventArgs e)
        {
            monster = 22;
            pictureBox1.BackgroundImage = button18.BackgroundImage;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            monster = 23;
            pictureBox1.BackgroundImage = button19.BackgroundImage;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            monster = 24;
            pictureBox1.BackgroundImage = button20.BackgroundImage;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            monster = 25;
            pictureBox1.BackgroundImage = button21.BackgroundImage;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            monster = 26;
            pictureBox1.BackgroundImage = button22.BackgroundImage;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            monster = 27;
            pictureBox1.BackgroundImage = button23.BackgroundImage;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            monster = 28;
            pictureBox1.BackgroundImage = button24.BackgroundImage;
        }


        //монстры разбойницы
        private void button28_Click(object sender, EventArgs e)
        {
            monster = 29;
            pictureBox1.BackgroundImage = button28.BackgroundImage;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            monster = 30;
            pictureBox1.BackgroundImage = button27.BackgroundImage;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            monster = 31;
            pictureBox1.BackgroundImage = button26.BackgroundImage;
        }

        private void button252_Click(object sender, EventArgs e)
        {
            monster = 32;
            pictureBox1.BackgroundImage = button252.BackgroundImage;
        }

        private void button242_Click(object sender, EventArgs e)
        {
            monster = 33;
            pictureBox1.BackgroundImage = button242.BackgroundImage;
        }

        private void button232_Click(object sender, EventArgs e)
        {
            monster = 34;
            pictureBox1.BackgroundImage = button232.BackgroundImage;
        }

        private void button222_Click(object sender, EventArgs e)
        {
            monster = 35;
            pictureBox1.BackgroundImage = button222.BackgroundImage;
        }

       
    }
}
