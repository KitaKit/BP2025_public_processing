using System.Windows.Forms;

namespace GenotypeApp
{
    public partial class GenotypeApplicationMainWindow : Form
    {
        private void SetElementsEnableState(bool state, params Control[] controls)
        {
            foreach (var c in controls)
                c.Enabled = state;
        }
    }
}