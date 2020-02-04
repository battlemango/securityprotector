using securityprotector.main.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securityprotector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            initViews();

        }

        private void initViews()
        {
            DragNDropPanel dragNDropPanel = new DragNDropPanel();
            dragNDropPanel.Dock = DockStyle.Left;
            dragNDropPanel.Top = 5;
            dragNDropPanel.Left = 10;
            dragNDropPanel.Width = 200;
            dragNDropPanel.Height = 300;
            this.Controls.Add(dragNDropPanel);



            IconRadioGroup radioGp = new IconRadioGroup();
            //radioGp.Dock = DockStyle.None;
            radioGp.Top = 0;
            radioGp.Left = 200;
            radioGp.Width = 150;
            radioGp.Height = 300;

            this.Controls.Add(radioGp);
        }

    }
}
