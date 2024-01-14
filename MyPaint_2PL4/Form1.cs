using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace MyPaint_2PL4
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Color col1;
        Color col2;
        Font fnt;
        Pen pen;
        Pen eraserPen;
        Point startPoint;
        Point endPoint;
        byte angles;
        float penWidth;
        Bitmap img;
        bool drawing = false;

        private void InitObjects()
        {
            col1 = Color.Black;
            col2 = Color.DarkRed;
            ColorButton.BackColor = col1;
            Color2Button.BackColor = col2;
            fnt = this.Font;
            //fnt = new Font("Arial",12);
            pen = new Pen(col1);
            eraserPen = new Pen(col2);
            startPoint = new Point(0, 0);
            endPoint = new Point(0, 0);
            penWidth = 1;
            img = new Bitmap(PictureBox1.Width,PictureBox1.Height);
            //create graphics
            gr = this.CreateGraphics();
            gr = Graphics.FromImage(img);
            gr.Clear(Color.White);
            PictureBox1.Image = img;
        }
        public Form1()
        {
            InitializeComponent();
            InitObjects();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                col1 = ColorDialog1.Color;
                ColorButton.BackColor = col1;
                pen.Color = col1;
            }
        }

        private void Color2Button_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                col2 = ColorDialog1.Color;
                Color2Button.BackColor = col2;
                eraserPen.Color = col2;
            }

        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            if (FontDialog1.ShowDialog() == DialogResult.OK)
            {
                fnt = FontDialog1.Font;
                FontButton.Text = fnt.Name+" "+fnt.Size+"pt";
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                if (!drawing)
                {
                    drawing = !drawing;
                    startPoint = e.Location;
                }
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (drawing) drawing = false;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                if (LineRadioButton.Checked)
                {
                    gr.DrawLine(pen, startPoint, e.Location);
                }
                else if (NormalLineRadioButton.Checked)
                {
                    gr.DrawLine(pen, startPoint, e.Location);
                    startPoint = e.Location;
                }
                else if (EraserRadioButton.Checked)
                {
                    gr.DrawLine(eraserPen, startPoint, e.Location);
                    startPoint = e.Location;
                }
                RefreshImage();
            }
        }
        private void RefreshImage()
        {
            gr = Graphics.FromImage(img);
            PictureBox1.Image = img;
        }

        private void P1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(P1RadioButton.Checked)
            {
                pen.Width = 1;
                eraserPen.Width = 1;
            }
        }

        private void P2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (P2RadioButton.Checked)
            {
                pen.Width = 5;
                eraserPen.Width = 5;
            }
        }

        private void P3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (P3RadioButton.Checked)
            {
                pen.Width = 10;
                eraserPen.Width = 10;
            }
        }
    }
}
