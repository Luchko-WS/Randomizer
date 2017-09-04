namespace CSRandom
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Choose = new System.Windows.Forms.Button();
            this.random_list = new System.Windows.Forms.Button();
            this.openFileDialog_1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиНовийСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.редагуватиСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиСписокУФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.зберегтиСписокЯкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(272, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(12, 335);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(134, 23);
            this.Choose.TabIndex = 1;
            this.Choose.Text = "Визначити";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // random_list
            // 
            this.random_list.Location = new System.Drawing.Point(152, 335);
            this.random_list.Name = "random_list";
            this.random_list.Size = new System.Drawing.Size(132, 23);
            this.random_list.TabIndex = 1;
            this.random_list.Text = "Випадковий список";
            this.random_list.UseVisualStyleBackColor = true;
            this.random_list.Click += new System.EventHandler(this.random_list_Click);
            // 
            // openFileDialog_1
            // 
            this.openFileDialog_1.Filter = "Текстові файли | *.txt";
            this.openFileDialog_1.InitialDirectory = "C://";
            this.openFileDialog_1.Title = "Відкриття файлу...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(294, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиНовийСписокToolStripMenuItem,
            this.редагуватиСписокToolStripMenuItem,
            this.toolStripSeparator1,
            this.відкритиФайлToolStripMenuItem,
            this.зберегтиСписокУФайлToolStripMenuItem,
            this.зберегтиСписокЯкToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // відкритиФайлToolStripMenuItem
            // 
            this.відкритиФайлToolStripMenuItem.Name = "відкритиФайлToolStripMenuItem";
            this.відкритиФайлToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.відкритиФайлToolStripMenuItem.Text = "Відкрити файл...";
            this.відкритиФайлToolStripMenuItem.Click += new System.EventHandler(this.відкритиФайлToolStripMenuItem_Click);
            // 
            // створитиНовийСписокToolStripMenuItem
            // 
            this.створитиНовийСписокToolStripMenuItem.Name = "створитиНовийСписокToolStripMenuItem";
            this.створитиНовийСписокToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.створитиНовийСписокToolStripMenuItem.Text = "Створити новий список";
            this.створитиНовийСписокToolStripMenuItem.Click += new System.EventHandler(this.створитиНовийСписокToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(272, 304);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Текстові файли | *.txt";
            this.saveFileDialog1.Title = "Збереження файлу...";
            // 
            // редагуватиСписокToolStripMenuItem
            // 
            this.редагуватиСписокToolStripMenuItem.Name = "редагуватиСписокToolStripMenuItem";
            this.редагуватиСписокToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.редагуватиСписокToolStripMenuItem.Text = "Редагувати список";
            this.редагуватиСписокToolStripMenuItem.Click += new System.EventHandler(this.редагуватиСписокToolStripMenuItem_Click);
            // 
            // зберегтиСписокУФайлToolStripMenuItem
            // 
            this.зберегтиСписокУФайлToolStripMenuItem.Name = "зберегтиСписокУФайлToolStripMenuItem";
            this.зберегтиСписокУФайлToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.зберегтиСписокУФайлToolStripMenuItem.Text = "Зберегти список у поточний файл...";
            this.зберегтиСписокУФайлToolStripMenuItem.Click += new System.EventHandler(this.зберегтиСписокУФайлToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // зберегтиСписокЯкToolStripMenuItem
            // 
            this.зберегтиСписокЯкToolStripMenuItem.Name = "зберегтиСписокЯкToolStripMenuItem";
            this.зберегтиСписокЯкToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.зберегтиСписокЯкToolStripMenuItem.Text = "Зберегти список як...";
            this.зберегтиСписокЯкToolStripMenuItem.Click += new System.EventHandler(this.зберегтиСписокЯкToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 370);
            this.Controls.Add(this.random_list);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randomizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button random_list;
        private System.Windows.Forms.OpenFileDialog openFileDialog_1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem створитиНовийСписокToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem редагуватиСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиСписокУФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиСписокЯкToolStripMenuItem;
    }
}

