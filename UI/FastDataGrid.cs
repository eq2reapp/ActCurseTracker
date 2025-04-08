using System.Windows.Forms;

namespace ActCurseTracker.UI
{
    public partial class FastDataGrid : DataGridView
    {
        public FastDataGrid()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }
    }
}
