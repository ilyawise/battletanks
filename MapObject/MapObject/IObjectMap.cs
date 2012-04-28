using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MapObject
{
    interface IObjectMap
    {
        void SetPoint(Point point);
        Point GetPoint();
        Bitmap GetImage();
    }
}
