using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Randomizer
{
    public class FileActionResult<T>
    {
        public FileActionResult()
        {
            IsSuccess = true;
            IsCancelled = false;
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }

        public bool IsCancelled { get; set; }
    }

    public class FileManager
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;
        private string _currentFileName;
        private bool _isFileOpened;

        public FileManager()
        {
            _currentFileName = null; 

            _openFileDialog = new OpenFileDialog
            {
                Filter = "Текстові файли | *.txt",
                InitialDirectory = "C://",
                Title = "Відкриття файлу..."
            };

            _saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстові файли | *.txt",
                Title = "Збереження файлу..."
            };
        }

        public string CurrentFileName
        {
            get
            {
                return _currentFileName;
            }
            private set
            {
                if(_currentFileName != value)
                {
                    _currentFileName = value;
                    var handler = CurrentFileChanged;
                    if (handler != null)
                    {
                        handler.Invoke(value);
                    }
                }
            }
        }

        public bool IsFileOpened
        {
            get
            {
                return _isFileOpened;
            }
            private set
            {
                if(_isFileOpened != value)
                {
                    _isFileOpened = value;
                    if(_isFileOpened)
                    {
                        var handler = FileOpened;
                        if (handler != null)
                        {
                            handler.Invoke(_currentFileName);
                        }
                    }
                    else
                    {
                        var handler = FileClosed;
                        if (handler != null)
                        {
                            handler.Invoke(_currentFileName);
                        }
                    }
                }
            }
        }

        public FileActionResult<IList> ReadListFromFileByDialog()
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var res = ReadListFromFile(_openFileDialog.FileName);
                if (res.IsSuccess)
                {
                    CurrentFileName = _openFileDialog.FileName;
                    IsFileOpened = true;
                }
                return res;
            }
            return new FileActionResult<IList> { IsCancelled = true };
        }

        private FileActionResult<IList> ReadListFromFile(string filename)
        {
            var sr = new StreamReader(filename);
            try
            {
                var resList = new List<string>();
                while (!sr.EndOfStream)
                {
                    resList.Add(sr.ReadLine());
                }
                return new FileActionResult<IList>() { Data = resList };
            }
            catch(Exception ex)
            {
                return new FileActionResult<IList>() { IsSuccess = false, ErrorMessage = ex.Message };
            }
            finally
            {
                sr.Close();
            }
        }

        public FileActionResult<int> SaveListInCurrentFile(IList items)
        {
            return IsFileOpened ? 
                WriteListIntoFile(CurrentFileName, items) : 
                new FileActionResult<int>() { IsSuccess = false, ErrorMessage = "No file is opened" };
        }

        public FileActionResult<int> SaveListAsNewFileByDialog(IList items)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var res = WriteListIntoFile(_saveFileDialog.FileName, items);
                if (res.IsSuccess)
                {
                    CurrentFileName = _saveFileDialog.FileName;
                    IsFileOpened = true;
                }
                return res;
            }
            return new FileActionResult<int>() { IsCancelled = true };
        }

        private FileActionResult<int> WriteListIntoFile(string filename, IList items)
        {
            var sw = new StreamWriter(filename);
            int writtenItemsCount = 0;
            try
            {
                foreach (var i in items)
                {
                    sw.WriteLine(i.ToString());
                    writtenItemsCount++;
                }
                return new FileActionResult<int>() { Data = writtenItemsCount };
            }
            catch (Exception ex)
            {
                return new FileActionResult<int>() { Data = writtenItemsCount, IsSuccess = false, ErrorMessage = ex.Message };
            }
            finally
            {
                sw.Close();
            }
        }

        public FileActionResult<string> CloseCurrentFile()
        {
            var res = new FileActionResult<string>() { Data = CurrentFileName };
            IsFileOpened = false;
            CurrentFileName = null;
            return res;
        }

        public event Action<string> CurrentFileChanged;
        public event Action<string> FileOpened;
        public event Action<string> FileClosed;
    }
}
