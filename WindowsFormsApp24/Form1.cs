using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        
        int i = 20;
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            
        }
        Graphics g;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Down)
            {
                g = this.CreateGraphics();
                i++;
               
            }
            if (e.KeyCode == Keys.Up)
            {
                g = this.CreateGraphics();
                i--;
            }
            if (e.KeyCode == Keys.Down)
            {
                g = this.CreateGraphics();
                i++;

            }
            if (e.KeyCode == Keys.Up)
            {
                g = this.CreateGraphics();
                i--;
            }

            Invalidate(new Rectangle(10, 10, 300, 300));
            label1.Text = i.ToString();
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.DimGray,10);
            g.DrawEllipse(pen, 10, 10, 300, 300);
            g.DrawLine(new Pen(Color.DarkViolet, 10), new Point(160, 170), new Point(160, 22));



            PointF PitCenter = new Point(picBoxZoomMap.Width / 2, picBoxZoomMap.Height / 2);
            PointF p = new PointF(PitCenter.X - 20, PitCenter.Y - 250);
            PointF p2 = new PointF(PitCenter.X + 20, PitCenter.Y - 250);

            var AlphaRad = RotDegrees * Math.PI / 180;

            zoomgfx.DrawLine(Pens.Red, PitCenter, new PointF(
            (float)(Math.Cos(AlphaRad) * (p.X - PitCenter.X) - Math.Sin(AlphaRad) * (p.Y - PitCenter.Y) + PitCenter.X),
            (float)(Math.Sin(AlphaRad) * (p.X - PitCenter.X) + Math.Cos(AlphaRad) * (p.Y - PitCenter.Y) + PitCenter.Y)));

            zoomgfx.DrawLine(Pens.Red, PitCenter, new PointF(
            (float)(Math.Cos(AlphaRad) * (p2.X - PitCenter.X) - Math.Sin(AlphaRad) * (p2.Y - PitCenter.Y) + PitCenter.X),
            (float)(Math.Sin(AlphaRad) * (p2.X - PitCenter.X) + Math.Cos(AlphaRad) * (p2.Y - PitCenter.Y) + PitCenter.Y)));



        }
    }
}
