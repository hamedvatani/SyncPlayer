using System.Windows.Forms;

namespace SyncPlayer
{
    public class MyScrollBar : HScrollBar
    {
        private int OldMax;

        public new int LargeChange
        {
            get
            {
                return base.LargeChange;
            }
            set
            {
                OldMax = this.Minimum;
                base.LargeChange = value;
                this.Maximum = OldMax;
            }
        }

        public new int Maximum
        {
            get
            {
                return base.Maximum - this.LargeChange + 1;
            }
            set
            {
                base.Maximum = value + this.LargeChange - 1;
            }
        }

        public MyScrollBar()
        {
            this.Maximum = base.Maximum;
        }
    }
}