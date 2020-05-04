using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_Ruletka
{
    public partial class Form1 : Form
    {
        protected string places;
        protected uint bank = 200;
        protected uint bet = 10;
        protected byte betmode = 0;
        protected char betselect;
        protected byte rebuy;
        public Form1()
        {
            InitializeComponent();
            places = Help.InitPlaces();
            textBox2.Text = Convert.ToString(bank);
            textBox3.Text = Convert.ToString(bet);
            //button1.Enabled = false;
        }

        //
        //Установка ставки игроком
        //Ставка х2
        private void button_BetUp_Click(object sender, EventArgs e)
        {
            bet = bet * 2;
            textBox3.Text = Convert.ToString(bet);
        }
        //Ставка х0.5
        private void button_BetDown_Click(object sender, EventArgs e)
        {
            bet = bet / 2;
            textBox3.Text = Convert.ToString(bet);
        }
        //Ставка All_In
        private void button_AllIn_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(bank);
        }
        //Ввод ставки в textBox3
        private void textBox3_Bet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bet = Convert.ToUInt32(textBox3.Text);
            }
            catch
            {
                textBox3.Text = "";
                //textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length-1);
            }

            if (bet > bank)
            {
                textBox3.Text = Convert.ToString(bank);
            }

        }

        //
        //Ставка на Set
        private void button_Set_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            betmode = 1;
            int val = Convert.ToInt32(btn.Text.Substring(btn.Text.Length - 1)) / 2;
            betselect = Convert.ToChar(val);
            rebuy = 2;
            button1.Enabled = true;
        }
        //
        //Ставка на Pair
        private void button_Pair_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            betmode = 2;
            int val = Convert.ToInt32(btn.Text.Substring(btn.Text.Length - 2)) / 18;
            betselect = Convert.ToChar(val);
            rebuy = 1;
            button1.Enabled = true;
        }
        //
        //Ставка на четное/нечетное
        private void button_Div2_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            betmode = 3;
            int val = btn.Text.Length % 2;
            betselect = Convert.ToChar(val);
            rebuy = 1;
            button1.Enabled = true;
        }
        //
        //Ставка на цвет
        private void button_Color_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            betmode = 4;
            if (btn.Text == "R")
            {
                betselect = '1';
            }
            else
            {
                betselect = '2';
            }
            rebuy = 1;
            button1.Enabled = true;
        }

        //
        //
        //Вращение рулетки
        //Кнопка Roll неактивна, пока не выбрано поле для стаки
        private void button_Roll_Click(object sender, EventArgs e)
        {
            int num = Help.GetRand();
            switch (places[num])
            {
                case '0':
                    textBox1.BackColor = Color.Green;
                    break;
                case '1':
                    textBox1.BackColor = Color.Firebrick;
                    break;
                case '2':
                    textBox1.BackColor = Color.Black;
                    break;
            }
            textBox1.Text = $"{num}";

            bool result = Help.Compare(num, places[num], betmode, betselect);

            if (result)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Добавить цвет textBox4 победа Green, поражение Red
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                bank += bet * rebuy;
                textBox2.Text = Convert.ToString(bank);
                textBox4.Text = $"WIN {bet * rebuy}";
                textBox4.BackColor = Color.Green;
            }
            else
            {
                bank -= bet;
                textBox2.Text = Convert.ToString(bank);
                textBox4.Text = $"LOSE {bet}";
                textBox4.BackColor = Color.DarkRed;
            }

            betmode = 0;
            button1.Enabled = false;
        }

    }
}
