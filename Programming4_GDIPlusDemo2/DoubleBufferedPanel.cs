using System.Windows.Forms;

namespace GDIPlus_Demo_2
{
    public sealed class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}