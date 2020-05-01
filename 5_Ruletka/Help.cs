using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_Ruletka
{
    class Help
    {
        //
        //Генератор случайного числа от 0 до 36
        public static int GetRand()
        {
            Random rnd = new Random();
            int val = rnd.Next(0, 36);
            return val;
        }

        //
        //Инициализация массива, устанавливающего соответствие между числом и цветом
        public static string InitPlaces()
        {
            string path = "C:\\Users\\User\\С@Code\\Studing\\5_Ruletka\\5_Ruletka\\PlaceColors.txt";
            string str;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    str = sr.ReadToEnd();
                }
                return str;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //
        //Сопоставление выбранного поля и поля выпавшего на рулетке
        public static bool Compare(int num, int color, byte mode, char select)
        {
            bool res = false;
            int a;
            switch (mode)
            {
                //1-set: 1_1-12; 2_13-24; 3_25-36
                case 1:
                    a = select * 12 - num;
                    res = (a >= 0 && a < 12);
                    break;
                //2-pair: 1_1-18; 2_19-36
                case 2:
                    a = select * 18 - num;
                    res = (a >= 0 && a < 18);
                    break;
                //3-div2: 0_Even; 1_Odd
                case 3:
                    res = (num % 2 == select);
                    break;
                //4-color: 0_Green; 1_Red; 2_Black
                case 4:
                    res = (color == select);
                    break;
            }

            return res;
        }



    }

    /*
    interface Keks
    {
        void Work();
    }
    class Serega : Keks
    {
        public void Work()
        {
            MessageBox.Show("dhcfeuvefuivluqf");
        }
    }
    */
}
