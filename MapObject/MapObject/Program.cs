using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MapObject
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMap());
        }
    }
}
