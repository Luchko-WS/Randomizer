using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Randomizer;

namespace CSRandom
{
    /*
     * NOTES: 
     * Cancel button doesn't work.
     * Implement status header with current file.
     * Review openning and closing file logic.
     * Review opening and closing second window logic.
     */

    public partial class MainForm : Form
    {
        bool _fileChanged = false;
        bool _fileOpened = false;
        uint _window = 1;
        string _currentFileName = "";

        public MainForm()
        {
            InitializeComponent();
            this.chooseItemButton.Click += chooseItemButton_Click;
            this.shellListButton.Click += shellListButton_Click;
            this.openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            this.itemsListBox.KeyDown += listBox_KeyDown;
            this.FormClosing += MainForm_FormClosing;
            this.createNewListToolStripMenuItem.Click += createNewListToolStripMenuItem_Click;
            this.editListToolStripMenuItem.Click += editListToolStripMenuItem_Click;
            this.saveListToolStripMenuItem.Click += saveListToolStripMenuItem_Click;
            this.saveListAsToolStripMenuItem.Click += saveListAsStripMenuItem_Click;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fileChanged && _fileOpened)
            {
                AskAboutSavingChangesInFile();
            }
            else if (_fileChanged)
            {
                AskAboutCreatingNewFile();
            }
        }

        private void chooseItemButton_Click(object sender, EventArgs e)
        {
            switch (_window)
            {
                case 1:
                    var item = ListRandomizer.SelectObjectFromList(itemsListBox.Items);
                    if (item != null)
                    {
                        MessageBox.Show(item.ToString());
                    }
                    break;
                case 2:
                    _fileChanged = true;
                    itemsListBox.Items.Clear();

                    foreach (var stringLine in richTextBox.Lines)
                    {
                        if (stringLine.Trim() != "")
                        {
                            itemsListBox.Items.Add(stringLine.Trim());
                        }
                    }
                    CloseSecondWindow();
                    break;
            }
        }

        private void shellListButton_Click(object sender, EventArgs e)
        {
            switch (_window)
            {
                case 1:
                    var resList = ListRandomizer.ShellList(itemsListBox.Items);
                    if (resList != null)
                    {
                        itemsListBox.Items.Clear();
                        foreach (var item in resList)
                        {
                            itemsListBox.Items.Add(item);
                        }
                    }
                    break;
                case 2:
                    CloseSecondWindow();
                    break;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileOpened && _fileChanged)
            {
                AskAboutSavingChangesInFile();
            }
            else if (_fileChanged)
            {
                openFileDialog.FileName = "";
                AskAboutCreatingNewFile();
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentFileName = openFileDialog.FileName;
                var sr = new StreamReader(openFileDialog.FileName);
                itemsListBox.Items.Clear();

                while (!sr.EndOfStream)
                {
                    itemsListBox.Items.Add(sr.ReadLine());
                }

                _fileOpened = true;
                _fileChanged = false;
                this.saveListToolStripMenuItem.Enabled = true;
                this.editListToolStripMenuItem.Enabled = true;
                sr.Close();
            }
        }

        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (itemsListBox.SelectedIndex != -1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        for (int i = itemsListBox.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            itemsListBox.Items.RemoveAt(itemsListBox.SelectedIndices[i]);
                            if (_fileOpened)
                            {
                                _fileChanged = true;
                            }
                        }
                        break;
                }
            }
        }

        private void createNewListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileOpened && _fileChanged)
            {
                AskAboutSavingChangesInFile();
            }
            _currentFileName = "";
            _fileOpened = false;

            OpenSecondWindow();
            richTextBox.Clear();
        }

        private void CloseSecondWindow()
        {
            _window = 1;
            fileToolStripMenuItem.Enabled = true;
            richTextBox.Clear();
            richTextBox.Visible = false;
            itemsListBox.Visible = true;
            chooseItemButton.Text = "Визначити";
            shellListButton.Text = "Випадковий список";
        }

        private void OpenSecondWindow()
        {
            _window = 2;
            fileToolStripMenuItem.Enabled = false;
            richTextBox.Visible = true;
            itemsListBox.Visible = false;
            chooseItemButton.Text = "Прийняти";
            shellListButton.Text = "Скасувати";
        }

        private void editListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSecondWindow();
            richTextBox.Clear();

            foreach (var i in itemsListBox.Items)
            {
                richTextBox.AppendText(i.ToString() + '\n');
            }
        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveInCurrentFile(itemsListBox.Items);
        }

        private void saveListAsStripMenuItem_Click(object sender, EventArgs e)
        {
            saveNewUserList(itemsListBox.Items);
        }

        private void AskAboutCreatingNewFile()
        {
            var result = MessageBox.Show(this, "Чи бажаєте зберегти даний список у файлі?", "Збереження списку...",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Yes:
                    saveNewUserList(itemsListBox.Items);
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void AskAboutSavingChangesInFile()
        {
            var result = MessageBox.Show(this, "Ви бажаєте зберегти зміни в даному файлі?", "Збереження змін...",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (result)
            {
                case DialogResult.Yes:
                    saveInCurrentFile(itemsListBox.Items);
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void saveInCurrentFile(IList items)
        {
            var sw = new StreamWriter(openFileDialog.FileName);
            foreach (var i in items)
            {
                sw.WriteLine(i.ToString());
            }
            sw.Close();

            _fileOpened = true;
            _fileChanged = false;
        }

        private void saveNewUserList(IList items)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sw = new StreamWriter(saveFileDialog.FileName);
                foreach (var i in items)
                {
                    sw.WriteLine(i.ToString());
                }
                sw.Close();

                openFileDialog.FileName = saveFileDialog.FileName;
                _currentFileName = saveFileDialog.FileName;
                _fileOpened = true;
                _fileChanged = false;
            }
        }
    }
}
