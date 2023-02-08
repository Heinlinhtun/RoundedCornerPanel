using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponents
{
    public class RPanel : Panel
    {
        //Fields
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopCOlor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;

        //DropShadow


        //Constructor
        public RPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(Size.Width, Size.Height);
        }

        //properties
        public int BorderRadius
        { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }
        public float GradientAngle
        { get => gradientAngle; set { gradientAngle = value; this.Invalidate(); } }
        public Color GradientTopColor
        { get => gradientTopCOlor; set { gradientTopCOlor = value; this.Invalidate(); } }
        public Color GradientBottomColor
        { get => gradientBottomColor; set { gradientBottomColor = value; this.Invalidate(); } }



        //Methods
        private GraphicsPath GetRPanelPath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Bitmap shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            DrawShadowSmooth(graphicsPath, 100, 60, shadowBmp);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        //Overridden Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Gradient
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush rBrush = new LinearGradientBrush(this.ClientRectangle, this.GradientTopColor, this.GradientBottomColor, this.gradientAngle);
            Graphics rGraphics = e.Graphics;
            rGraphics.FillRectangle(rBrush, ClientRectangle);


            //BorderRadius
            RectangleF rectangleF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath graphicsPath = GetRPanelPath(rectangleF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else
            {
                this.Region = new Region(rectangleF);
            }
        
        }

        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceCopy;
                double alpha = 0;
                double astep = 0;
                double astepstep = (double)intensity / radius / (radius / 2D);
                for (int thickness = radius; thickness > 0; thickness--)
                {
                    using (Pen p = new Pen(Color.FromArgb((int)alpha, 0, 0, 0), thickness))
                    {
                        p.LineJoin = LineJoin.Round;
                        g.DrawPath(p, gp);
                    }
                    alpha += astep;
                    astep += astepstep;
                }
            }
        }
    }
}
