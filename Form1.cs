using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace matches
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        Panel[] MyPanelArray = new Panel[25];
            int CountSticks = 25;
            int PlayerCount = 0;
            int CompCount = 0;

       


        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Перед вами 25 спичек. Вы и компьютер берёте по очереди 1, " +
                "2 или 3 спички. Если в конце партии последний ход сделали вы, то следующую партию " +
                "начинает компьютер и наоборот. Ваша задача: в конце игры, когда все спички будут " +
                "разобраны, иметь четное количество спичек. В левом верхнем углу отображается ваше " +
                "текущее количество спичек и количество компьютера. В правом верхнем углу счётчик " +
                "ваших побед и побед компьютера.", "Инструкция: ");
            textBox1.Text = "0";
            textBox2.Text = "0";

            MyPanelArray[0] = panel1;
            MyPanelArray[1] = panel2;
            MyPanelArray[2] = panel3;
            MyPanelArray[3] = panel4;
            MyPanelArray[4] = panel5;
            MyPanelArray[5] = panel6;
            MyPanelArray[6] = panel7;
            MyPanelArray[7] = panel8;
            MyPanelArray[8] = panel9;
            MyPanelArray[9] = panel10;
            MyPanelArray[10] = panel11;
            MyPanelArray[11] = panel12;
            MyPanelArray[12] = panel13;
            MyPanelArray[13] = panel14;
            MyPanelArray[14] = panel15;
            MyPanelArray[15] = panel16;
            MyPanelArray[16] = panel17;
            MyPanelArray[17] = panel18;
            MyPanelArray[18] = panel19;
            MyPanelArray[19] = panel20;
            MyPanelArray[20] = panel21;
            MyPanelArray[21] = panel22;
            MyPanelArray[22] = panel23;
            MyPanelArray[23] = panel24;
            MyPanelArray[24] = panel25;
        }

        public void Next(bool player)
        {
            PlayerCount = 0;
            textBox4.Text = 0.ToString();
            textBox3.Text = 0.ToString();
            for (int i = 0; i < 25; i++)
            {
                MyPanelArray[i].BackColor = Color.DeepSkyBlue;
            }

            
            CountSticks = 25;
        }

        public void move(int CountMove, bool player)   //  CountMove - колличество убираемых спичек; player - true(индикатор первого игрока , false индикатор второго игрока)

        {
            try
            {
                for (int i = CountSticks - CountMove; i < CountSticks; i++)
                {
                    if (player)
                        MyPanelArray[i].BackColor = Color.Coral;
                    if (!player)
                        MyPanelArray[i].BackColor = Color.DarkViolet;
                }

            }

            catch { }

            CountSticks -= CountMove;

            if (CountSticks == 0) // проверка на завершение игры
            {

                if (PlayerCount % 2 == 0)

                {
                    
                    textBox4.Text = CompCount.ToString();
                    CompCount = 0;
                    MessageBox.Show("Победил" + label1.Text);
                    textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
                    Next(player);
                    return;
                    
                 }
                
                
               
                else if (PlayerCount % 2 == 1)

                {
                    CompCount = 0;
                    MessageBox.Show("Победил" + label2.Text);
                    textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
                    Next(player);
                    return;
                    
                }
            }
        }

        // Кнопки

        private void button1_Click(object sender, EventArgs e)
        {

            PlayerCount += 1;
            textBox3.Text = PlayerCount.ToString();

            move(1, true);

            moveII();

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (CountSticks > 1)
            {
                PlayerCount += 2;
                textBox3.Text = PlayerCount.ToString();
                move(2, true);

                moveII();
            }
            else {
                MessageBox.Show("Осталась всего одна спичка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CountSticks > 2)
            {
                PlayerCount += 3;
                textBox3.Text = PlayerCount.ToString();

                move(3, true);

                moveII();
            }
            else if (CountSticks == 2)
            {
                MessageBox.Show("Осталось всего две спички");
            }
            else
            {
                MessageBox.Show("Осталась всего одна спичка");
            }
        }
        //Правила ходов компьютера
        private void moveII()
        {
            if (CountSticks == 1)
            {
                CompCount += 1;
                textBox4.Text = CompCount.ToString();
                move(1, false);
                return;
            }
            
            if (CountSticks == 9)
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                return;
                }
            }
            if (CountSticks == 17 || CountSticks == 9 )
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                return;
                }
            }
            if (CountSticks == 13 || CountSticks == 5 )
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                return;
                }
            }
            if (CountSticks == 2)
            {   if (CompCount % 2 == 0)
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }

                else 
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                }
                return;
            }
            if (CountSticks == 3)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }

                else
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                }
                return;
            }
            if (CountSticks == 6)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                }

                else
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }
                return;
            }
            if (CountSticks == 7)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                }

                else
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }
                return;
            }
            if (CountSticks == 10)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }

                else
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                }
                return;
            }
            if (CountSticks == 11)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                }

                else
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }
                return;
            }
            if (CountSticks == 14)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                }

                else
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }
                return;
            }
            if (CountSticks == 15)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                }

                else
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }
                return;
            }
            if (CountSticks == 18)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }

                else
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                }
                return;
            }
            if (CountSticks == 19)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 2;
                    textBox4.Text = CompCount.ToString();
                    move(2, false);
                }

                else
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                }
                return;
            }
            if (CountSticks == 4)
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                    return;
                }
            }
            if (CountSticks == 5)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                return;
                }
            }
            if (CountSticks == 8)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                return;
                }
            }
            if (CountSticks == 12)
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                return;
                }
            }
            if (CountSticks == 13)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                return;
                }
            }
            if (CountSticks == 16)
            {
                if (CompCount % 2 == 0)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                return;
                }
            }
            if (CountSticks == 17)
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 1;
                    textBox4.Text = CompCount.ToString();
                    move(1, false);
                return;
                }
            }
            if (CountSticks == 20)
            {
                if (CompCount % 2 == 1)
                {
                    CompCount += 3;
                    textBox4.Text = CompCount.ToString();
                    move(3, false);
                return;
                }

            }


            if ((CountSticks - 3) % 4 == 0 || (CountSticks - 3) % 4 == 1)
            {
                CompCount += 3;
                textBox4.Text = CompCount.ToString();
                move(3, false);
                return;
            }

            if ((CountSticks - 1) % 4 == 0 || (CountSticks - 1) % 4 == 1)
            {
                CompCount += 1;
                textBox4.Text = CompCount.ToString();
                move(1, false);
                return;
            }


            if ((CountSticks - 2) % 4 == 0 || (CountSticks - 2) % 4 == 1)
            {
                CompCount += 2;
                textBox4.Text = CompCount.ToString();
                move(2, false);
                return;
            }
            
        }
    }
}
