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
    }
}
