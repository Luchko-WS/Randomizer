using System;
using System.Collections;
using System.Windows.Forms;

namespace Randomizer
{
    public partial class MainForm : Form
    {
        bool _listChanged = false;
        FileManager _fileManager;

        public MainForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _fileManager.CurrentFileChanged += _fileManager_CurrentFileChanged;
            _fileManager.FileOpened += _fileManager_FileOpened;
            _fileManager.FileClosed += _fileManager_FileClosed;

            this.chooseItemButton.Click += ChooseItemButton_Click;
            this.shellListButton.Click += ShellListButton_Click;
            this.openFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            this.itemsListBox.KeyDown += ListBox_KeyDown;
            this.FormClosing += MainForm_FormClosing;
            this.createNewListToolStripMenuItem.Click += CreateNewListToolStripMenuItem_Click;
            this.editListToolStripMenuItem.Click += EditListToolStripMenuItem_Click;
            this.saveListToolStripMenuItem.Click += SaveListToolStripMenuItem_Click;
            this.saveListAsToolStripMenuItem.Click += SaveListAsStripMenuItem_Click;
        }

        private void _fileManager_CurrentFileChanged(string newFilename)
        {
            currentFileNaemToolStripStatusLabel.Text = newFilename;
        }

        private void _fileManager_FileOpened(string filename)
        {
            currentFileNaemToolStripStatusLabel.Text = filename;
            this.editListToolStripMenuItem.Enabled = true;
            this.saveListToolStripMenuItem.Enabled = true;
            this.saveListAsToolStripMenuItem.Enabled = true;
        }

        private void _fileManager_FileClosed(string filename)
        {
            currentFileNaemToolStripStatusLabel.Text = filename;
            this.saveListToolStripMenuItem.Enabled = false;
            this.saveListAsToolStripMenuItem.Enabled = false;
            this.editListToolStripMenuItem.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseCurrentList();
        }

        private void ChooseItemButton_Click(object sender, EventArgs e)
        {
            var item = ListRandomizer.SelectObjectFromList(itemsListBox.Items);
            if (item != null) MessageBox.Show(item.ToString());
        }

        private void ShellListButton_Click(object sender, EventArgs e)
        {
            ListRandomizer.ShellList(itemsListBox.Items);
            _listChanged = true;
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentList()) return;

            var res = _fileManager.ReadListFromFileByDialog();
            if(res.IsSuccess && !res.IsCancelled)
            {
                itemsListBox.Items.Clear();
                foreach (var item in res.Data)
                {
                    itemsListBox.Items.Add(item);
                }
                _listChanged = false;
            }
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (itemsListBox.SelectedIndex != -1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        for (int i = itemsListBox.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            itemsListBox.Items.RemoveAt(itemsListBox.SelectedIndices[i]);
                            _listChanged = true;
                        }
                        break;
                }
            }
        }

        private void CreateNewListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentList()) return;
            OpenEditListWindow();
        }

        private void OpenEditListWindow(IList list = null)
        {
            var editListWindow = new EditListForm();
            if (list != null)
            {
                editListWindow.SetSource(list);
            }

            if (editListWindow.ShowDialog() == DialogResult.OK)
            {
                itemsListBox.Items.Clear();
                foreach (var stringLine in editListWindow.RichTextBoxLines)
                {
                    if (stringLine.Trim() != "")
                    {
                        itemsListBox.Items.Add(stringLine.Trim());
                    }
                }

                if (itemsListBox.Items.Count == 0 && !_fileManager.IsFileOpened)
                {
                    this.editListToolStripMenuItem.Enabled = false;
                    this.saveListToolStripMenuItem.Enabled = false;
                    this.saveListAsToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.editListToolStripMenuItem.Enabled = true;
                    this.saveListToolStripMenuItem.Enabled = true;
                    this.saveListAsToolStripMenuItem.Enabled = true;
                }

                _listChanged = true;
            }
        }

        private void EditListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditListWindow(itemsListBox.Items);
        }

        private void SaveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileManager.IsFileOpened)
            {
                SaveInCurrentFile(itemsListBox.Items);
            }
            else
            {
                if (!AskAboutCreatingNewFile()) return;
            }
            _listChanged = false;
        }

        private void SaveListAsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SaveListAsNewFile(itemsListBox.Items)) return;
            _listChanged = false;
        }

        private bool CloseCurrentList()
        {
            if (_listChanged && _fileManager.IsFileOpened)
            {
                var res = AskAboutSavingChangesInFile();
                if (res) _fileManager.CloseCurrentFile();
                return res;
            }
            else if (_listChanged)
            {
                var res = AskAboutCreatingNewFile();
                if (res) _fileManager.CloseCurrentFile();
                return res;
            }
            return true;
        }

        private bool AskAboutCreatingNewFile()
        {
            var result = MessageBox.Show(this, "Чи бажаєте зберегти даний список у новому файлі?", "Збереження списку...",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Yes:
                    return SaveListAsNewFile(itemsListBox.Items);
                case DialogResult.No:
                    return true;
            }
            return false;
        }

        private bool AskAboutSavingChangesInFile()
        {
            var result = MessageBox.Show(this, "Ви бажаєте зберегти зміни в даному файлі?", "Збереження змін...",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Yes:
                    return SaveInCurrentFile(itemsListBox.Items);
                case DialogResult.No:
                    return true;
            }
            return false;
        }

        private bool SaveInCurrentFile(IList items)
        {
            var res = _fileManager.SaveListInCurrentFile(items);
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res.IsSuccess;
        }

        private bool SaveListAsNewFile(IList items)
        {
            var res = _fileManager.SaveListAsNewFileByDialog(items);
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return res.IsSuccess && !res.IsCancelled;
        }
    }
}
