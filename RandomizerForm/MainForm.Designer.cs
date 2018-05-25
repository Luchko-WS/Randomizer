namespace CSRandom
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.chooseItemButton = new System.Windows.Forms.Button();
            this.shellListButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.editListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveListAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(12, 25);
            this.itemsListBox.Name = "listBox1";
            this.itemsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.itemsListBox.Size = new System.Drawing.Size(272, 303);
            this.itemsListBox.TabIndex = 0;
            // 
            // Choose
            // 
            this.chooseItemButton.Location = new System.Drawing.Point(12, 335);
            this.chooseItemButton.Name = "Choose";
            this.chooseItemButton.Size = new System.Drawing.Size(134, 23);
            this.chooseItemButton.TabIndex = 1;
            this.chooseItemButton.Text = "Визначити";
            this.chooseItemButton.UseVisualStyleBackColor = true;
            // 
            // random_list
            // 
            this.shellListButton.Location = new System.Drawing.Point(152, 335);
            this.shellListButton.Name = "random_list";
            this.shellListButton.Size = new System.Drawing.Size(132, 23);
            this.shellListButton.TabIndex = 1;
            this.shellListButton.Text = "Випадковий список";
            this.shellListButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog_1
            // 
            this.openFileDialog.Filter = "Текстові файли | *.txt";
            this.openFileDialog.InitialDirectory = "C://";
            this.openFileDialog.Title = "Відкриття файлу...";
            // 
            // menuStrip1
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip1";
            this.menuStrip.Size = new System.Drawing.Size(294, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewListToolStripMenuItem,
            this.editListToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFileToolStripMenuItem,
            this.saveListToolStripMenuItem,
            this.saveListAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // відкритиФайлToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "відкритиФайлToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.openFileToolStripMenuItem.Text = "Відкрити файл...";
            // 
            // створитиНовийСписокToolStripMenuItem
            // 
            this.createNewListToolStripMenuItem.Name = "створитиНовийСписокToolStripMenuItem";
            this.createNewListToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.createNewListToolStripMenuItem.Text = "Створити новий список";
            // 
            // richTextBox1
            // 
            this.richTextBox.Location = new System.Drawing.Point(12, 25);
            this.richTextBox.Name = "richTextBox1";
            this.richTextBox.Size = new System.Drawing.Size(272, 304);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "";
            this.richTextBox.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog.Filter = "Текстові файли | *.txt";
            this.saveFileDialog.Title = "Збереження файлу...";
            // 
            // редагуватиСписокToolStripMenuItem
            // 
            this.editListToolStripMenuItem.Name = "редагуватиСписокToolStripMenuItem";
            this.editListToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.editListToolStripMenuItem.Text = "Редагувати список";
            this.editListToolStripMenuItem.Enabled = false;
            // 
            // зберегтиСписокУФайлToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Name = "зберегтиСписокУФайлToolStripMenuItem";
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.saveListToolStripMenuItem.Text = "Зберегти список у поточний файл...";
            this.saveListToolStripMenuItem.Enabled = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // зберегтиСписокЯкToolStripMenuItem
            // 
            this.saveListAsToolStripMenuItem.Name = "зберегтиСписокЯкToolStripMenuItem";
            this.saveListAsToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.saveListAsToolStripMenuItem.Text = "Зберегти список як...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 370);
            this.Controls.Add(this.shellListButton);
            this.Controls.Add(this.chooseItemButton);
            this.Controls.Add(this.itemsListBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.richTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randomizer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Button chooseItemButton;
        private System.Windows.Forms.Button shellListButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewListToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem editListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveListAsToolStripMenuItem;
    }
}

