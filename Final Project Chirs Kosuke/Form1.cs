using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_Chirs_Kosuke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        Random num = new Random();
        int rand;
        Button[,] buttongrid = new Button[10, 10];
        Button[,] buttongrid2 = new Button[10, 10];
        String[,] grid = new String[10, 10];
        bool gamestart = false;



        private void Form1_Load(object sender, EventArgs e)
        {
            buttongrid = new Button[10, 10]
            { { button1, button2,button3,button4,button5,button6,button7,button8,button9,button10 },
              { button11, button12, button13,button14,button15,button16,button17,button18,button19,button20,},
              { button21, button22,button23,button24,button25,button26,button27,button28,button29,button30 },
              { button31, button32,button33,button34,button35,button36,button37,button38,button39,button40 },
              { button41, button42,button43,button44,button45,button46,button47,button48,button49,button50 },
              { button51, button52,button53,button54,button55,button56,button57,button58,button59,button60 },
              { button61, button62,button63,button64,button65,button66,button67,button68,button69,button70 },
              { button71, button72,button73,button74,button75,button76,button77,button78,button79,button80 },
              { button81, button82,button83,button84,button85,button86,button87,button88,button89,button90 },
              { button91, button92,button93,button94,button95,button96,button97,button98,button99,button100 },
            };
            buttongrid2 = new Button[8, 8]
            {
              { button102, button103,button104,button105,button106,button107,button108,button109},
              { button110, button111,button112,button113,button114,button115,button116,button117},
              { button118, button119,button120,button121,button122,button123,button124,button125,},
              { button126, button127,button128,button129,button130,button131,button132,button133,},
              { button134, button135,button136,button137,button138,button139,button140,button141,},
              { button142, button143,button144,button145,button146,button147,button148,button149,},
              { button150, button151,button152,button153,button154,button155,button156,button157},
              { button158, button159,button160,button161,button162,button163,button164,button165,},
            };





        }
        bool firstturn = true;
        private void random1()
        {

            rand = num.Next(1, 101);
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    rand = num.Next(1, 101);
                   
                    if (!(buttongrid[i - 1, j].Text == "0" && buttongrid[i + 1, j].Text == "0" && buttongrid[i, j + 1].Text == "0" && buttongrid[i, j - 1].Text == "0" && buttongrid[i - 1, j + 1].Text == "0" && buttongrid[i - 1, j - 1].Text == "0" && buttongrid[i + 1, j - 1].Text == "0" && buttongrid[i + 1, j + 1].Text == "0"))
                    {
                        if (rand > 0 && rand < 46) // bomb
                        {
                            buttongrid[i, j].BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("testing");
                    }
                }
            }
        }


        private void bombcheck()
        {
            int counter = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (buttongrid[i, j].BackColor == Color.Red)
                    {

                    }
                    else
                    {

                        if (buttongrid[i - 1, j].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i + 1, j].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i, j - 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i, j + 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i - 1, j - 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i - 1, j + 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i + 1, j - 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        if (buttongrid[i + 1, j + 1].BackColor == Color.Red)
                        {
                            counter++;
                        }
                        buttongrid[i, j].Text = counter.ToString();
                        counter = 0;
                    }
                }
            }


        }
        private void button166_Click(object sender, EventArgs e) //reset
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    buttongrid[i, j].Text = "";
                    buttongrid[i, j].BackColor = Color.White;
                    button101.Enabled = true;
                }
            }
            button101.PerformClick();
            firstturn = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttongrid2[i, j].Visible = true;
                    buttongrid2[i, j].BackColor = Color.Green;

                }
            }
        }
        
        private void button101_Click(object sender, EventArgs e) //play
        {


            button101.Enabled = false;
            firstturn = true;
            gamestart = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttongrid2[i, j].BackColor = Color.Green;

                }
            }
        }
        private void click(Button a, int i, int j)
        {
            if (gamestart)
            {
                if (firstturn == true)
                {
                    
                    random1();
                    buttongrid[i, j].BackColor = Color.White;
                    buttongrid[i-1, j].BackColor = Color.White;
                    buttongrid[i+1, j].BackColor = Color.White;
                    buttongrid[i, j-1].BackColor = Color.White;
                    buttongrid[i, j+1].BackColor = Color.White;
                    buttongrid[i-1, j+1].BackColor = Color.White;
                    buttongrid[i-1, j-1].BackColor = Color.White;
                    buttongrid[i+1, j+1].BackColor = Color.White;
                    buttongrid[i+1, j-1].BackColor = Color.White;
                    bombcheck();
                    firstturn = false;
                }

                a.Visible = false;
                if (buttongrid[i, j].BackColor == Color.Red)
                {
                    MessageBox.Show("You Lose!");
                    button166.PerformClick();
                }


            }
        }
        private void flag(Button a)
        {
            if (gamestart)
            {
                if (a.BackColor == Color.Yellow)
                {
                    a.BackColor = Color.Green;
                }
                else
                {
                    a.BackColor = Color.Yellow;
                }
            }

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void button102_Click(object sender, EventArgs e)
        {
        }

        private void button103_Click(object sender, EventArgs e)
        {
        }

        private void button104_Click(object sender, EventArgs e)
        {
        }

        private void button105_Click(object sender, EventArgs e)
        {
        }

        private void button106_Click(object sender, EventArgs e)
        {
        }

        private void button107_Click(object sender, EventArgs e)
        {
        }

        private void button108_Click(object sender, EventArgs e)
        {
        }

        private void button109_Click(object sender, EventArgs e)
        {
        }

        private void button102_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void button32_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void button112_Click(object sender, EventArgs e)
        {

        }







        private void button102_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                flag(button102);
            }
            else
                click(button102, 1, 1);
        }

        private void button103_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button103);
            }
            else
                click(button103, 1, 2);
        }

        private void button104_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button104);
            }
            else
                click(button104, 1, 3);
        }

        private void button105_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button105);
            }
            else
                click(button105, 1, 4);
        }

        private void button106_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button106);
            }
            else
                click(button106, 1, 5);
        }

        private void button107_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button107);
            }
            else
                click(button107, 1, 6);
        }

        private void button108_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button108);
            }
            else
                click(button108, 1, 7);
        }

        private void button109_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button109);
            }
            else
                click(button109, 1, 8);
        }
        private void button110_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button110);
            }
            else
                click(button110, 2, 1);
        }

        private void button110_Click(object sender, EventArgs e)
        {

        }

        private void button110_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button110);
            }
            else
                click(button110, 2, 1);
        }

        private void button111_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button111);
            }
            else
                click(button111, 2, 2);

        }


        private void button112_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button112);
            }
            else
                click(button112, 2, 3);
        }

        private void button113_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button113);
            }
            else
                click(button113, 2, 4);
        }

        private void button114_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button114);
            }
            else
                click(button114, 2, 5);
        }

        private void button115_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button115);
            }
            else
                click(button115, 2, 6);
        }

        private void button116_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button116);
            }
            else
                click(button116, 2, 7);
        }

        private void button117_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button117);
            }
            else
                click(button117, 2, 8);
        }

        private void button118_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button118);
            }
            else
                click(button118, 3, 1);
        }

        private void button119_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button119);
            }
            else
                click(button119, 3, 2);
        }

        private void button120_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button120);
            }
            else
                click(button120, 3, 3);
        }

        private void button121_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button121);
            }
            else
                click(button121, 3, 4);
        }

        private void button122_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button122);
            }
            else
                click(button122, 3, 5);
        }

        private void button123_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button123);
            }
            else
                click(button123, 3, 6);
        }

        private void button124_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button124);
            }
            else
                click(button124, 3, 7);
        }

        private void button125_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button125);
            }
            else
                click(button125, 3, 8);
        }

        private void button126_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button126);
            }
            else
                click(button126, 4, 1);
        }

        private void button127_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button127);
            }
            else
                click(button127, 4, 2);
        }

        private void button128_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button128);
            }
            else
                click(button128, 4, 3);
        }

        private void button129_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button129);
            }
            else
                click(button129, 4, 4);
        }

        private void button130_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button130);
            }
            else
                click(button130, 4, 5);
        }

        private void button131_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button131);
            }
            else
                click(button131, 4, 6);
        }

        private void button132_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button132);
            }
            else
                click(button132, 4, 7);
        }

        private void button133_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button133);
            }
            else
                click(button133, 4, 8);
        }

        private void button134_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button134);
            }
            else
                click(button134, 5, 1);
        }

        private void button135_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button135);
            }
            else
                click(button135, 5, 2);
        }

        private void button136_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button136);
            }
            else
                click(button136, 5, 3);
        }

        private void button137_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button137);
            }
            else
                click(button137, 5, 4);
        }

        private void button138_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button138);
            }
            else
                click(button138, 5, 5);
        }

        private void button139_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button139);
            }
            else
                click(button139, 5, 6);
        }

        private void button140_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button140);
            }
            else
                click(button140, 5, 7);
        }

        private void button141_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button141);
            }
            else
                click(button141, 5, 8);
        }

        private void button142_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button142);
            }
            else
                click(button142, 6, 1);
        }

        private void button143_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button143);
            }
            else
                click(button143, 6, 2);
        }

        private void button144_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button144);
            }
            else
                click(button144, 6, 3);
        }

        private void button145_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button145);
            }
            else
                click(button145, 6, 4);
        }

        private void button146_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button146);
            }
            else
                click(button146, 6, 5);
        }

        private void button147_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button147);
            }
            else
                click(button147, 6, 6);
        }

        private void button148_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button148);
            }
            else
                click(button148, 6, 7);
        }

        private void button149_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button149);
            }
            else
                click(button149, 6, 8);
        }

        private void button150_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button150);
            }
            else
                click(button150, 7, 1);
        }

        private void button152_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button152);
            }
            else
                click(button152, 7, 3);
        }

        private void button153_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button153);
            }
            else
                click(button153, 7, 4);
        }

        private void button154_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button154);
            }
            else
                click(button154, 7, 5);
        }

        private void button155_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button155);
            }
            else
                click(button155, 7, 6);
        }

        private void button156_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button156);
            }
            else
                click(button156, 7, 7);
        }

        private void button151_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button151);
            }
            else
                click(button151, 7, 2);
        }

        private void button157_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button157);
            }
            else
                click(button157, 7, 8);
        }

        private void button158_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button158);
            }
            else
                click(button158, 8, 1);
        }

        private void button159_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button159);
            }
            else
                click(button159, 8, 2);
        }

        private void button160_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button160);
            }
            else
                click(button160, 8, 3);
        }

        private void button161_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button161);
            }
            else
                click(button161, 8, 4);
        }

        private void button162_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button162);
            }
            else
                click(button162, 8, 5);
        }

        private void button163_Click(object sender, EventArgs e)
        {

        }

        private void button163_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button163);
            }
            else
                click(button163, 8, 6);
        }

        private void button164_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button164);
            }
            else
                click(button164, 8, 7);
        }

        private void button165_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                flag(button165);
            }
            else
                click(button165, 8, 8);
        }


    }
}

