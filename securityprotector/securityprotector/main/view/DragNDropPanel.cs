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

        public DragNDropPanel()
        {
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(dragEnter);
            this.DragDrop += new DragEventHandler(dragDrop);
            //BackColor = Color.Black;

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
                //File.SetAttributes(file, FileAttributes.NotContentIndexed);
                //이름 바꾸기
                //   FileInfo fileRename = new FileInfo(file);
                // if (fileRename.Exists)
                //{
                //    fileRename.MoveTo(file + "bb"); //이미있으면 에러
                //}
            }
        }
    }
}
