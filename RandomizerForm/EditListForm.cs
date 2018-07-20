using System.Collections;
using System.Windows.Forms;

namespace Randomizer
{
    public partial class EditListForm : Form
    {
        public EditListForm()
        {
            InitializeComponent();
        }

        public string[] RichTextBoxLines
        {
            get
            {
                return this.itemsRichTextBox.Lines;
            }
        }

        public void SetSource(IList source)
        {
            if (source != null)
            {
                foreach (var item in source)
                {
                    this.itemsRichTextBox.Text += item.ToString() + '\n';
                }
            }
        }
    }  
}
