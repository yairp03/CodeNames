using System.ComponentModel;
using System.Windows.Forms;

namespace CodeNames
{
    public partial class CardLabel : Label
    {
        public int r;
        public int c;
        public bool revealed;

        public CardLabel(int r, int c)
        {
            InitializeComponent();

            this.r = r;
            this.c = c;
        }

        public CardLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
