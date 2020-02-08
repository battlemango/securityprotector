using securityprotector.main;
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
        private DragNDropPanel mDragNDropPanel;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            initViews();

        }

        private void initViews()
        {
            mDragNDropPanel = new DragNDropPanel();
            mDragNDropPanel.Dock = DockStyle.Left;
            mDragNDropPanel.Top = 5;
            mDragNDropPanel.Left = 10;
            mDragNDropPanel.Width = 200;
            mDragNDropPanel.Height = 300;
            this.Controls.Add(mDragNDropPanel);



            IconRadioGroup radioGp = new IconRadioGroup();
            //radioGp.Dock = DockStyle.None;
            radioGp.Top = 0;
            radioGp.Left = 200;
            radioGp.Width = 150;
            radioGp.Height = 300;

            this.Controls.Add(radioGp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mDragNDropPanel.changeFolderName(CommonConstants.FOLDER_TYPE_RECYCLE);
        }
    }
}
