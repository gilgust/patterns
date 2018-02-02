using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BitmapProject
{
    public partial class Form1 : Form
    {
        private readonly BitmapPool bitmapsList;
        public Form1()
        {
            InitializeComponent();
            bitmapsList = new BitmapPool();
        }

        private void GetPictureB_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JPG | *.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            bitmapsList.GetOriginal(openFileDialog1.FileName);
                            pictureBoxOriginal.Image = bitmapsList.ListBitmaps[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }

                pictureBoxForSaving.Image.Save(sfd.FileName, format);
            }
        }

            private void GetNegative_Click(object sender, EventArgs e)
        {
            pictureBoxForSaving.Image = bitmapsList.ListBitmaps[1];
        }

        private void TurnLeft_Click(object sender, EventArgs e)
        {
            pictureBoxForSaving.Image = bitmapsList.ListBitmaps[2];
        }

        private void TurnRight_Click(object sender, EventArgs e)
        {
            pictureBoxForSaving.Image = bitmapsList.ListBitmaps[3];
        }
    }
}
