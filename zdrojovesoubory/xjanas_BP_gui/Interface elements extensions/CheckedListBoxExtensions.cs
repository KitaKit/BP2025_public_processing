using System.Windows.Forms;

namespace GenotypeApp.Interface_elements_interaction
{
    internal static class CheckedListBoxExtensions
    {
        public static void CheckAllCheckedListBoxItems(this CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
               checkedListBox.SetItemChecked(i, true);
        }
    }
}
