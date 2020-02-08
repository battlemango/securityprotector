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
        private ArrayList mRadioButtonList;
        private RadioButton mSelectedRadioButton;

        public IconRadioGroup()
        {
            this.Text = "type";
            mRadioButtonList = new ArrayList();
            setRadioButtons();
        }

        public RadioButton getSelectedRadioButton()
        {
            return mSelectedRadioButton;
        }

        private void setRadioButtons()
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = 1;
            tlp.RowCount = 6;

            tlp.Dock = DockStyle.Fill;

            RadioButton radioRecycle = new RadioButton();
            radioRecycle.Text = CommonConstants.FOLDER_TYPE_RECYCLE;
            radioRecycle.Click += new EventHandler(radioButtonClicked);
            tlp.Controls.Add(radioRecycle);
            mRadioButtonList.Add(radioRecycle);

            RadioButton radioNetwork = new RadioButton();
            radioNetwork.Text = CommonConstants.FOLDER_TYPE_NETWORK;
            radioNetwork.Click += new EventHandler(radioButtonClicked);
            tlp.Controls.Add(radioNetwork);
            mRadioButtonList.Add(radioNetwork);

            this.Controls.Add(tlp);
            initChecked();
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
