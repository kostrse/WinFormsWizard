/*
© 2005, 2011 MAY-MART. All rights reserved.
The code is originally based on TSWizard library (http://www.codeproject.com/KB/dialog/tswizard.aspx).
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MayMart.WinFormsWizard.Controls
{
    public class BevelLine : Control
    {
        private Pen _darkPen = new Pen(SystemColors.ControlDark);
        //private Pen _lightPen = new Pen(SystemColors.ControlLightLight);

        protected override void OnPaint(PaintEventArgs e)
        {
            if ((e.ClipRectangle.Top <= 0) && (e.ClipRectangle.Bottom >= 0))
                e.Graphics.DrawLine(_darkPen, e.ClipRectangle.Left, 0, e.ClipRectangle.Right, 0);

            //if ((e.ClipRectangle.Top <= 1) && (e.ClipRectangle.Bottom >= 1))
            //    e.Graphics.DrawLine(_lightPen, e.ClipRectangle.Left, 1, e.ClipRectangle.Right, 1);

            base.OnPaint(e);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            if (_darkPen != null)
                _darkPen.Dispose();

            _darkPen = new Pen(SystemColors.ControlDark);

            //if (_lightPen != null)
            //    _lightPen.Dispose();

            //_lightPen = new Pen(SystemColors.ControlLightLight);

            base.OnSystemColorsChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (_darkPen != null)
                _darkPen.Dispose();

            //if (_lightPen != null)
            //    _lightPen.Dispose();

            base.Dispose(disposing);
        }
    }
}

