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

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1000); 
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate(new Rectangle(10, 10, 300, 300));
        }
        

        static Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }

        Timer timer;
        DateTime time;

        int hours;
        int minutes;
        int seconds;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            
            timer = new Timer();
            timer.Start();
            timer.Tick += Timer_Tick;
            this.Load += Form1_Load;


        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;

            hours = time.Hour;
            minutes = time.Minute;
            seconds = time.Second;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen penForClock = new Pen(Color.DimGray, 10);
            Pen penForMinute = new Pen(Color.DarkViolet, 10);
            Pen penForHour = new Pen(Color.DarkGreen, 10);
            Pen penForSecond = new Pen(Color.DarkOrange, 5);

            penForHour.EndCap = LineCap.ArrowAnchor;
            penForMinute.EndCap = LineCap.ArrowAnchor;

            g.DrawEllipse(penForClock, 10, 10, 300, 300);

            Point newPointMinutes = RotatePoint(new Point(160, 22), new Point(160, 160), minutes*6);
            Point newPointHours = RotatePoint(new Point(160, 22), new Point(160, 160), hours * 30);
            Point newPointSeconds = RotatePoint(new Point(160, 22), new Point(160, 160), seconds * 6);

            g.DrawLine(penForMinute, new Point(160, 160), newPointMinutes);
            g.DrawLine(penForHour, new Point(160, 160), newPointHours);
            g.DrawLine(penForSecond, new Point(160, 160), newPointSeconds);



        }
    }
}
