using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securityprotector.main.view
{
    class IconRadioGroup : GroupBox
    {
        private TableLayoutPanel mTableLayoutPanel;
        private ArrayList mRadioButtonList;
        private RadioButton mSelectedRadioButton;

        public IconRadioGroup()
        {
            mTableLayoutPanel = new TableLayoutPanel();
            mTableLayoutPanel.ColumnCount = 1;
            mTableLayoutPanel.RowCount = 6;
            mTableLayoutPanel.Dock = DockStyle.Fill;
            Controls.Add(mTableLayoutPanel);

            this.Text = "type";
            mRadioButtonList = new ArrayList();
            setRadioButtons();
        }

        public RadioButton getSelectedRadioButton()
        {
            return mSelectedRadioButton;
        }

        public String getSelectedRadioName()
        {
            if(mSelectedRadioButton == null)
            {
                return null;
            }
            return mSelectedRadioButton.Text;
        }

        private void setRadioButtons()
        {
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_NORMAL);

            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_RECYCLE);
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_NETWORK);
            //setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_COMPUTER);
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_INTERNET);
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_CONTROLLER);
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_PRINTER);
            setRadioButton(new RadioButton(), CommonConstants.FOLDER_TYPE_EXTENTION);

            initChecked();
        }

        private void setRadioButton(RadioButton radioButton, String text)
        {
            radioButton.Text = text;
            radioButton.Click += new EventHandler(radioButtonClicked);

            mTableLayoutPanel.Controls.Add(radioButton);
            mRadioButtonList.Add(radioButton);
        }

        private void radioButtonClicked(object sender, EventArgs e)
        {
            foreach(RadioButton radioButton in mRadioButtonList)
            {
                if(radioButton == sender)
                {
                    selectRadioButton(radioButton);
                }
            }
        }

        private void initChecked()
        {
            RadioButton radio = (RadioButton)mRadioButtonList[0];
            radio.Checked = true;
        }

        private void selectRadioButton(RadioButton radio)
        {
            mSelectedRadioButton = radio;
        }
    }
}
