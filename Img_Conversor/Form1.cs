using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Img_Conversor
{
    public partial class Form1 : Form
    {
        public string ImageLink;
        public Form1()
        {
            InitializeComponent();
            ImageFolder();
        }

        //criando pasta onde salvar imagens convertidas
        public void ImageFolder()
        {
            Directory.CreateDirectory(@"D:\folder");
        }

        public void Message()
        {
            MessageBox.Show("Imagem Convertida para: " +
                comboBox1.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = ofd.FileName;
                    ImageLink = ofd.FileName;
                }
            }
        }
        //método para converter imagem
        public void ConvertImage(string selectFormat)
        {
            try
            {
                Image img = Image.FromFile(ImageLink);
                switch (selectFormat)
                {
                    case "PNG":
                        img.Save(@"D:\folder\photo.PNG", ImageFormat.Png);
                        break;
                    case "ICON":
                        img.Save(@"D:\folder\photo.ICON", ImageFormat.Icon);
                        break;
                    case "WMF":
                        img.Save(@"D:\folder\photo.WMF", ImageFormat.Wmf);
                        break;
                    case "GIF":
                        img.Save(@"D:\folder\photo.GIF", ImageFormat.Gif);
                        break;
                    case "TIFF":
                        img.Save(@"D:\folder\photo.TIFF", ImageFormat.Tiff);
                        break;
                    case "EMF":
                        img.Save(@"D:\folder\photo.EMF", ImageFormat.Emf);
                        break;
                    case "BMP":
                        img.Save(@"D:\folder\photo.BMP", ImageFormat.Bmp);
                        break;
                    default :
                        MessageBox.Show("Formato de imagem inválida","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleciona a primeira imagem ");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ImageLink != null)
            {
                ConvertImage(comboBox1.Text);
                Message();
            }
            else 
            {
                MessageBox.Show("Error");
            }
        }
    }
}
