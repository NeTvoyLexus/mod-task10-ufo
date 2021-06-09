using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static System.Math;
using System.Drawing.Drawing2D;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(Form1_Paint);
        }
        

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            double x1 = 10, y1 = 10, x2 = 400, y2 = 370, step = 1;
            int degree = 12;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red, 1);
            g.DrawEllipse(new Pen(Color.Black, 2), (int)x1, (int)y1, 2, 2);
            g.DrawEllipse(new Pen(Color.Black, 2), (int)x2, (int)y2, 2, 2);
            GraphicsState gs;
            gs = g.Save();
            double error = Abs(x1 - x2) + Abs(y1 - y2);
            double angle = atan((y2 - y1) / (x1 - x2), degree);
            while (true)
            {
                y1 -= step * sin(angle, degree);
                x1 += step * cos(angle, degree);
                g.DrawEllipse(pen, (int)x1, (int)y1, 1, 1);
                if (Abs(x1 - x2) + Abs(y1 - y2) > error)
                {
                    g.DrawString("Error: " + error.ToString(), new Font("Arial", 18), new SolidBrush(Color.Black), 300, 10);
                    break;
                }
                else
                {
                    error = Abs(x1 - x2) + Abs(y1 - y2);
                }
            }
            g.Restore(gs);
            
        }

        static int fact(int x)
        {
            if (x <= 0) return 1;
            return x * fact(x - 1);
        }
        double cos(double x, int degree)
        {
            double res = 0;
            for (int i = 1; i < degree + 1; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / fact(2 * i - 2);
            }
            return res;
        }
        double sin(double x, int degree)
        {
            double res = 0;
            for (int i = 1; i < degree + 1; i++)
            {
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / fact(2 * i - 1);
            }
            return res;
        }
        double atan(double x, int degree)
        {
            double res = 0;
            for (int i = 1; i < degree + 1; i++)
                res += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);

            return res;
        }
    }
}