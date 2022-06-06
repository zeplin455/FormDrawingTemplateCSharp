using FormsDrawingTemplate.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDrawingTemplate
{
    public partial class MainForm : Form
    {
        BufferedDrawing drawObj;
        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            drawObj = new BufferedDrawing(this, RenderExample);
        }

        private int degrees = 0;

        private void RenderExample(Graphics g)
        {
            float ellipseSize = 10;

            float FormBounds = Math.Min(this.ClientRectangle.Width, this.ClientRectangle.Height);

            float radius = (FormBounds / 2) - (ellipseSize * 2);

            float locX = radius * (float)Math.Cos(ConvertDegreesToRadians(degrees));
            float locY = radius * (float)Math.Sin(ConvertDegreesToRadians(degrees));

            locX += this.ClientRectangle.Width / 2;
            locY += this.ClientRectangle.Height / 2;

            g.FillEllipse(new SolidBrush(Color.Red), locX, locY, ellipseSize, ellipseSize);

            degrees++;
        }

        private void FrameDrawTimer_Tick(object sender, EventArgs e)
        {
            drawObj.Render();
        }

        public static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return radians;
        }
    }
}
