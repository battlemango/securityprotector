using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securityprotector.main.view
{
    class DragNDropPanel : Panel
    {
        private String mSelectedFilePath;
        private Label mLabel;
        private Random mRnd = new Random();

        public DragNDropPanel()
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(dragEnter);
            this.DragDrop += new DragEventHandler(dragDrop);

            mLabel = new Label();
            mLabel.AutoSize = true;
            mLabel.Top = 85;
            mLabel.Left = 15;
            this.Controls.Add(mLabel);
            setLabel();

            setfolderimg();
        }

        private void setLabel()
        {
            if (String.IsNullOrEmpty(mSelectedFilePath))
            {
                mLabel.Text = "drag here";
            }
            else
            {
                mLabel.Text = Path.GetFileName(mSelectedFilePath);
            }
        }

        private void setfolderimg()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.None;
            pictureBox.Top = 15;
            pictureBox.Left = 15;
            pictureBox.Width = 100;
            pictureBox.Height = 100;
            this.Controls.Add(pictureBox);

            Bitmap sourceImage = Properties.Resources.folder;
            Size resize = new Size(70, 70);
            Bitmap resizeImage = new Bitmap(sourceImage, resize);
            pictureBox.Image = resizeImage;
        }


        private void dragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                Console.WriteLine(file);
                mSelectedFilePath = file;
                setLabel();
                break;
            }
        }

        public void removeFileExtention()
        {
            if (String.IsNullOrEmpty(mSelectedFilePath))
            {
                string message = "please drag file";
                CommonUtils.showMessageBox("warning", message);
                return;
            }

            String directoryName = Path.GetDirectoryName(mSelectedFilePath);
            String newFileName = Path.GetFileNameWithoutExtension(mSelectedFilePath);

            FileInfo fi = new FileInfo(mSelectedFilePath);
            if (fi.Exists)
            {
                Console.WriteLine("Exists");
                try
                {
                    fi.MoveTo(directoryName + "\\" + newFileName); //이미있으면 에러
                    mLabel.Text = "drag here";
                    CommonUtils.showMessageBox("wow", "file name changed");
                }
                catch (Exception e)
                {
                    //mLabel.Text = "something is wrong";
                    CommonUtils.showMessageBox("warning", "이미 확장자 없거나 다른 이유로 성공못함");
                }

            }
            else
            {
                string message = "it doesn't file, please drag file";
                CommonUtils.showMessageBox("warning", message);
            }
        }

        public void changeFolderName(String iconType)
        {
            if (String.IsNullOrEmpty(mSelectedFilePath))
            {
                string message = "please drag folder";
                CommonUtils.showMessageBox("warning", message);
                return;
            }

            String folderName = CommonConstants.FOLDER_NAME_RECYCLE;
            switch (iconType)
            {
                case CommonConstants.FOLDER_TYPE_RECYCLE:
                    folderName = CommonConstants.FOLDER_NAME_RECYCLE;
                    break;
                case CommonConstants.FOLDER_TYPE_NETWORK:
                    folderName = CommonConstants.FOLDER_NAME_NETWORK;
                    break;
                case CommonConstants.FOLDER_TYPE_COMPUTER:
                    folderName = CommonConstants.FOLDER_NAME_COMPUTER;
                    break;
                case CommonConstants.FOLDER_TYPE_CONTROLLER:
                    folderName = CommonConstants.FOLDER_NAME_CONTROLLER;
                    break;
                case CommonConstants.FOLDER_TYPE_INTERNET:
                    folderName = CommonConstants.FOLDER_NAME_INTERNET;
                    break;
                case CommonConstants.FOLDER_TYPE_PRINTER:
                    folderName = CommonConstants.FOLDER_NAME_PRINTER;
                    break;
                case CommonConstants.FOLDER_TYPE_NORMAL:
                    folderName = "normal" + mRnd.Next(1000);
                    break;
            }

            String directoryName = Path.GetDirectoryName(mSelectedFilePath);
            
            //FileInfo fileRename = new FileInfo(mSelectedFilePath);

            DirectoryInfo di = new DirectoryInfo(mSelectedFilePath);

            if (di.Exists)
            {
                Console.WriteLine("Exists");
                try
                {
                    di.MoveTo(directoryName + "\\" + folderName); //이미있으면 에러
                    mLabel.Text = "drag here";
                    CommonUtils.showMessageBox("wow", "folder name changed");
                }
                catch(Exception e)
                {
                    //mLabel.Text = "something is wrong";
                    CommonUtils.showMessageBox("warning", "같은 이름의 폴더를 선택한듯");
                }
                
            }
            else
            {
                string message = "it doesn't folder, please drag folder";
                CommonUtils.showMessageBox("warning", message);
            }
            
        }
    }
}
