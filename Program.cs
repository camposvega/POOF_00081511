﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOF_00081511
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
            Manage.Instance.MainForm = new Form1();
            Application.Run(Manage.Instance.MainForm);
        }
    }
}