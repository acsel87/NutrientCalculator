using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NC_Library
{
    public static class ScreenShotControl
    {
        public static Bitmap GetImage(Control control)
        {
            Rectangle display = control.Bounds;
            
            Bitmap bm = new Bitmap(display.Width, display.Height);
            //display1.DrawToBitmap(bm, display1.ClientRectangle);

            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(control.PointToScreen(Point.Empty), Point.Empty, display.Size);

            return bm;
        }        
    }
}
