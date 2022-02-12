using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.Net.Http;
using System.Drawing.Imaging;

namespace Adobe_Icon_Generator
{
    public partial class Form1 : Form
    {
        Color borderColor;
        Color fillColor;
        Color firstBorderColor;
        Color firstFillColor;
        Color fontColor;
        string path;
        int Usage;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(100);
            reload();
            Usage++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usage++; 
            try
            {
                Font customFont;
                fontDialog1.ShowDialog();
                customFont = fontDialog1.Font;
                label1.Font = customFont;
                reload();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usage++;
            FontColorDialog.ShowDialog();
            fontColor = FontColorDialog.Color;
            label1.ForeColor = fontColor;
            reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Usage++;
            BoderColorDialog.ShowDialog();
            borderColor = BoderColorDialog.Color;
            panel1.BackColor = borderColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            firstBorderColor = Color.FromArgb(255, 234, 119, 255);
            firstFillColor = Color.FromArgb(255, 42, 0, 52);
            panel1.BackColor = firstBorderColor;
            panel2.BackColor = firstFillColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FillColorDialog.ShowDialog();
            fillColor = FillColorDialog.Color;
            panel2.BackColor = fillColor;
            Usage++;
        }
        public void reload()
        {
            if (Usage < 3)
            {
                borderColor = firstBorderColor;
                fillColor = firstFillColor;
            }
            panel1.BackColor = borderColor;
            panel2.BackColor = fillColor;
            label1.Text = textBox1.Text;
            int x = (panel2.Size.Width - label1.Size.Width) / 2;
            int y = (panel2.Size.Height - label1.Size.Height) / 2;
            label1.Location = new Point(x, y);
        }

        public void center()
        {
            int x = (panel2.Size.Width - label1.Size.Width) / 2;
            int y = (panel2.Size.Height - label1.Size.Height) / 2;
            label1.Location = new Point(x, y);
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButton1)
            {
                Application.Exit();
            }
            else if (e.Button == toolBarButton2)
            {
                Process.Start(Application.ExecutablePath);
            }
            else if (e.Button == toolBarButton6)
            {
                if (Usage > 0)
                {
                    if (MessageBox.Show("Are you sure you want to start over?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        textBox1.Text = "";
                        label1.Font = new System.Drawing.Font("Adobe Clean", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        label1.Text = "Pr";
                        label1.ForeColor = firstBorderColor;
                        panel1.BackColor = firstBorderColor;
                        panel2.BackColor = firstFillColor;
                        borderColor = firstBorderColor;
                        fillColor = firstFillColor;
                        center();
                        Usage = 0;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (e.Button == toolBarButton3)
            {
                //GENERATION CODE
                int width = panel1.Size.Width;
                int height = panel1.Size.Height;
                Bitmap bm = new Bitmap(width, height);
                panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                path = saveFileDialog1.FileName;
                bm.Save(path, ImageFormat.Png);

                string FolderPath;
                FolderPath = Path.GetDirectoryName(path);
                Finish frmReady = new Finish(path, FolderPath);
                frmReady.Show();
                //bm.Save(@"C:\Users\Eric\Desktop\test.bmp", ImageFormat.);
            }
            else
            {
                
                AboutBox1 frmHelp = new AboutBox1();
                frmHelp.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Usage > 0)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
;