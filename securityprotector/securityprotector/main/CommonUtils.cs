using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace securityprotector.main
{
    class CommonUtils
    {
        public static void showMessageBox(String title, String message)
        {
            SystemSounds.Beep.Play();
            var result = MessageBox.Show(message, title,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Question);
        }
    }
}
