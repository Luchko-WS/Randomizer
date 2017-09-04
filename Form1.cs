using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSRandom
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        bool FileEdited = false;
        bool FileOpened = false;
        bool NewUserList = false;
        int window = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void choose_Click(object sender, EventArgs e)
        {
            switch(window)
            {
                case 1:
                    if (listBox1.Items.Count != 0)
                    {
                        int number = rnd.Next(0, listBox1.Items.Count - 1);
                        MessageBox.Show(listBox1.Items[number].ToString());
                    }
                    break;
                case 2:
                    if (FileEdited)
                    {
                        save_In_Current_File();
                        FileEdited = false;
                        FileOpened = false;
                    }
                    
                    NewUserList = true;
                    listBox1.Items.Clear();
                    
                    foreach (var s in richTextBox1.Lines)
                    {   
                        if(s.Trim() != "")
                            listBox1.Items.Add(s.Trim());
                    }
 
                    close_Window_2();
                    break;
            }
        }

        private void random_list_Click(object sender, EventArgs e)
        {
            switch(window)
            {
                case 1:  
                    if (listBox1.Items.Count != 0)
                    {
                        int size = listBox1.Items.Count, number;
                        
                        String[] array = new String[listBox1.Items.Count];

                        for (int i = 0; i < size; i++)
                        {
                            number = rnd.Next(0, listBox1.Items.Count);
                            array[i] = listBox1.Items[number].ToString();
                            listBox1.Items.RemoveAt(number);
                        }

                        foreach (var i in array)
                            listBox1.Items.Add(i);
                    } 
                    break;
                case 2:
                    close_Window_2();
                    break;
            }
        }

        private void відкритиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(FileOpened && FileEdited)
            {
                save_In_Current_File();
            }
            else if(NewUserList)
            {
                save_New_User_List();
                openFileDialog_1.FileName = "";
            }

            if (openFileDialog_1.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(openFileDialog_1.FileName);
                listBox1.Items.Clear();
                
                while (!sr.EndOfStream)
                    listBox1.Items.Add(sr.ReadLine());

                FileOpened = true;
                sr.Close();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        for (int i = listBox1.SelectedItems.Count - 1; i >= 0 ; i-- )
                        {
                            listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                            if(FileOpened) FileEdited = true;
                        }	
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileEdited)
            {
                if (MessageBox.Show(this, "Ви бажаєте зберегти зміни в даному файлі?", "Збереження змін...",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                    save_In_Current_File();
            }
            else if(NewUserList)
            {
                if (MessageBox.Show(this, "Чи бажаєте зберегти даний список у файлі?", "Збереження списку...",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                    save_New_User_List();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void save_In_Current_File()
        {
            var sw = new StreamWriter(openFileDialog_1.FileName);
            
            foreach (var i in listBox1.Items)
                sw.WriteLine(i.ToString());
            sw.Close();
            
            FileOpened = true;
            FileEdited = false;
            NewUserList = false;
        }

        private void save_New_User_List()
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sw = new StreamWriter(saveFileDialog1.FileName);
                
                foreach (var i in listBox1.Items)
                    sw.WriteLine(i.ToString());
                sw.Close();
            }
            
            openFileDialog_1.FileName = saveFileDialog1.FileName;
            FileOpened = true;
            FileEdited = false;
            NewUserList = false;
        }

        private void створитиНовийСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_Window_2();
        }
        private void close_Window_2()
        {
            window = 1;
            відкритиФайлToolStripMenuItem.Enabled = true;
            зберегтиСписокУФайлToolStripMenuItem.Enabled = true;
            зберегтиСписокЯкToolStripMenuItem.Enabled = true;
            richTextBox1.Clear();
            richTextBox1.Visible = false;
            listBox1.Visible = true;
            Choose.Text = "Визначити";
            random_list.Text = "Випадковий список";
        }

        private void open_Window_2()
        {
            window = 2;
            відкритиФайлToolStripMenuItem.Enabled = false;
            зберегтиСписокУФайлToolStripMenuItem.Enabled = false;
            зберегтиСписокЯкToolStripMenuItem.Enabled = false;
            richTextBox1.Visible = true;
            listBox1.Visible = false;
            Choose.Text = "Прийняти";
            random_list.Text = "Скасувати";
        }

        private void редагуватиСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_Window_2();
            richTextBox1.Clear();
            
            foreach (var i in listBox1.Items)
                richTextBox1.AppendText(i.ToString() + '\n');
        }

        private void зберегтиСписокУФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_In_Current_File();
        }

        private void зберегтиСписокЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_New_User_List();
        }
    }
}
