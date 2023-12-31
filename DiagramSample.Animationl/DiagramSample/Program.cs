﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1() {WindowState = FormWindowState.Maximized};
            form.Load += (sender, args) =>
            {
                form.WindowState = FormWindowState.Maximized;
            };

            Application.Run(form);
        }
    }
}
