using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CodeNames
{
    class Utils
    {
        static bool aborted = false;

        public static void AddTextsToPanel(Panel panel, List<string> texts)
        {
            panel.Controls.Clear();
            int y = 20;
            foreach (string text in texts)
            {
                Label label = new Label() { Text = text, Location = new Point(20, y) };
                panel.Controls.Add(label);
                y += 20;
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void RtlMessageBox(string text, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }

        public static void ErrorMessageBox(string text)
        {
            RtlMessageBox(text, "שגיאה", MessageBoxIcon.Error);
        }

        public static void ConnectionAbortMessageBox()
        {
            if (!aborted)
            {
                aborted = true;
                ErrorMessageBox("החיבור לשרת נפסק");
            }
        }
    }
}
