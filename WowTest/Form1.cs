using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WowTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var view32 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                            RegistryView.Registry32))
            {
                using (var clsid32 = view32.OpenSubKey(@"Software\Classes\CLSID\", false))
                {
                    // actually accessing Wow6432Node 
                    Console.WriteLine("Wow6432Node");
                }
            }

            using (var view64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                            RegistryView.Registry64))
            {
                using (var clsid64 = view64.OpenSubKey(@"Software\Classes\CLSID\", true))
                {

                    Console.WriteLine("64bit");
                }
            }
        }

    }
}
