using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrugger
{
    public class Shrugger
    {
        public void HandleHotKey()
        {
            SendString(@"¯\_(ツ)_/¯");
        }

        public static void SendString(string s)
        {
            var currentClipText = Clipboard.GetText();
            var currentClipImage = Clipboard.GetImage();
            Clipboard.SetText(s);
            SendKeys.Send("^v");
            Task.Delay(100);
            if(currentClipText != "")
            {
                Clipboard.SetText(currentClipText);
            }
            if(currentClipImage != null)
            {
                Clipboard.SetImage(currentClipImage);
            }
        }
    }
}
