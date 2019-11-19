using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormBigImage : Form
    {
        private string _imagePath = "";
        private string _flashPath = "";

        public FormBigImage()
        {
            InitializeComponent();
        }


        public void SetPathInfo(string imagePath, string flashPath)
        {
            _imagePath = imagePath;
            _flashPath = flashPath;

            if (!string.IsNullOrEmpty(_imagePath))
            {
                axShockwaveFlash1.Visible = false;
                pictureBox1.Visible = true;


                pictureBox1.BringToFront();
                axShockwaveFlash1.SendToBack();

                string path = _imagePath;
                Image imageInfo = Image.FromFile(path);
                this.Width = imageInfo.Width;
                this.Height = imageInfo.Height;
                pictureBox1.Image = imageInfo;
            }

            if (!string.IsNullOrEmpty(_flashPath))
            {
                this.Width = 621;
                this.Height = 362;
                axShockwaveFlash1.Visible = true;
                pictureBox1.Visible = false;
                string path = _flashPath;

                axShockwaveFlash1.Movie = path;
                axShockwaveFlash1.Play();
            }
            imageButtonClose.BringToFront();
        }

        public void SetInfo(string imagePath, string flashPath)
        {
            _imagePath = imagePath;
            _flashPath = flashPath;

            if(!string.IsNullOrEmpty(_imagePath))
            {
                axShockwaveFlash1.Visible = false;
                pictureBox1.Visible = true;


                pictureBox1.BringToFront();
                axShockwaveFlash1.SendToBack();

                string path = Directory.GetCurrentDirectory() + "\\Images\\" + Path.GetFileName(_imagePath);
                Image imageInfo = Image.FromFile(path);
                this.Width = imageInfo.Width;
                this.Height = imageInfo.Height;
                pictureBox1.Image = imageInfo;
            }

            if(!string.IsNullOrEmpty(_flashPath))
            {
                this.Width = 621;
                this.Height = 362;
                axShockwaveFlash1.Visible = true;
                pictureBox1.Visible = false;
                string path = Directory.GetCurrentDirectory() + "\\Flash\\" + Path.GetFileName(_flashPath);

                axShockwaveFlash1.Movie = path;
                axShockwaveFlash1.Play();
            }
            imageButtonClose.BringToFront();
        }

        private void axShockwaveFlash1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void imageButtonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
