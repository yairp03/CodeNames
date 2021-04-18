using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Utils
    {
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
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void RtlMessageBox(string text, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }
    }
}
