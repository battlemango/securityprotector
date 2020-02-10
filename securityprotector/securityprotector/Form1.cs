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
        private IconRadioGroup mIconRadioGroup;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "SecurityProtector";
            initViews();
        }

        private void initViews()
        {
            mDragNDropPanel = new DragNDropPanel();
            mDragNDropPanel.Dock = DockStyle.Left;
            mDragNDropPanel.Top = 5;
            mDragNDropPanel.Left = 10;
            mDragNDropPanel.Width = 120;
            mDragNDropPanel.Height = 300;
            this.Controls.Add(mDragNDropPanel);

            mIconRadioGroup = new IconRadioGroup();
            //radioGp.Dock = DockStyle.None;
            mIconRadioGroup.Top = 0;
            mIconRadioGroup.Left = 150;
            mIconRadioGroup.Width = 150;
            mIconRadioGroup.Height = 300;

            this.Controls.Add(mIconRadioGroup);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = mIconRadioGroup.getSelectedRadioName();
            if(type == CommonConstants.FOLDER_TYPE_EXTENTION)
            {
                mDragNDropPanel.removeFileExtention();
            }
            else
            {
                mDragNDropPanel.changeFolderName(mIconRadioGroup.getSelectedRadioName());
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
