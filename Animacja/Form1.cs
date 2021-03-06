﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animacja

{
    public partial class Form1 : Form
    {
        private bool _stop;
        string[] tab;
        int interval = 25;
        static int i = 0;



        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            tab = new string[89];
            for (int j = 0; j < tab.Length; j++)
            {
                tab[j] = (j + 1).ToString() + ".png";
            }
            //MessageBox.Show(Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //Pokazuje w jakim środowisku działa program
           

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _stop = false;
            FrqSent();
        }

        private void FrqSent() //funkcja szybkiego wyswietlania obrazow
        {
            while (i <= 88 && !_stop)
            {

                if (i < 88)
                {
                    i = i + 1;
                    Application.DoEvents();
                    pictureBox1.ImageLocation = "../../animacja/mg/" + tab[i]; // Opis ścieżki - wyjście z Debug, wyjście z bin -> wejście do animacja/mg/ + obrazek
                    pictureBox1.Load();
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(interval);
                }
                else
                {
                    i = 0;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stop = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e) //prędkość wyświetlania obrazów
        {
            interval = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e) //funkcja przewijania wyswietlanych obrazow
        {
            i = trackBar2.Value;

            pictureBox1.ImageLocation = "../../animacja/mg/" + tab[i];
            pictureBox1.Load();
            pictureBox1.Refresh();
            System.Threading.Thread.Sleep(interval);
        }
    }
}
