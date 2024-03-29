﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Image_Processing_Revised_GPC10
{
  public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = @"Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";

            double[,] mean3X3 =
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            
            double[,] modus3X3 =
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 0, 0 }
            };
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {   
                Bitmap bitmap = new Bitmap(openFile.FileName);
                Bitmap resizeBitmap = new Bitmap(bitmap, 352, 240);
                pictureBox1.Image = resizeBitmap;
                
                Bitmap median = new Bitmap(pictureBox1.Image);
                Processing.MedianFiltering(median, 3);
                pictureBox2.Image = median;
                
                label4.Text = "PSNR: " + Processing.MedianFiltering(bitmap, 3);
                
                Bitmap mean = new Bitmap(pictureBox1.Image);
                var meanFilter = Processing.ConvolutionFilter(mean, mean3X3);
                pictureBox3.Image = meanFilter.Item1;

                label6.Text = "PSNR: " + meanFilter.Item2;

                Bitmap modus = new Bitmap(pictureBox1.Image);
                var modusFilter = Processing.ConvolutionFilter(modus, modus3X3);
                pictureBox4.Image = modusFilter.Item1;

                label7.Text = "PSNR: " + modusFilter.Item2;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}