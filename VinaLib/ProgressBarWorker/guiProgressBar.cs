using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VinaLib
{
    public partial class guiProgressBar : Form
    {
        public guiProgressBar()
        {
            InitializeComponent();
        }

        public guiProgressBar(String desc)
        {
            InitializeComponent();

            fld_lblDescription.Text = desc;
        }

        public void Show(String desc)
        {
            fld_lblDescription.Text = desc;
            this.Show();
        }
    }
}