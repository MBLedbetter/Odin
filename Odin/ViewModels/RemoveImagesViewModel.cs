using ExcelLibrary;
using Microsoft.Win32;
using Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    class RemoveImagesViewModel : ViewModelBase
    {
        #region Commands

        public ICommand ImportItemListCommand
        {
            get
            {
                if (_importItemList == null)
                {
                    _importItemList = new RelayCommand(param => ImportItemList());
                }
                return _importItemList;
            }
        }
        private RelayCommand _importItemList;

        public ICommand RemoveImagesCommand
        {
            get
            {
                if (_removeImages == null)
                {
                    _removeImages = new RelayCommand(param => RemoveImages());
                }
                return _removeImages;
            }
        }
        private RelayCommand _removeImages;
        
        #endregion // Commands

        #region Properties

        public List<string> ItemIds
        {
            get
            {
                if (_itemIds == null)
                {
                    _itemIds = new List<string>();
                }
                return _itemIds;
            }
            set
            {
                _itemIds = value;
                OnPropertyChanged("ItemIds");
            }
        }
        private List<string> _itemIds;

        string path = @"C:\Users\bledbetter\Desktop\WebImages\";
        #endregion // Properties

        #region Methods


        public void ImportItemList()
        {
            OpenFileDialog dialogue = new OpenFileDialog();
            dialogue.Filter = "Excel files|*.xls; *.xlsx";
            WorkbookReader workbookReader = new WorkbookReader();

            if (dialogue.ShowDialog() != true)
            {
                return;
            }
            this.ItemIds = workbookReader.RetrieveIds(dialogue.FileName);

        }

        public void RemoveImages()
        {
            string filename = string.Empty;
            string idList = string.Empty;
            int count = 0;
            foreach (string item in ItemIds)
            {
                filename = path + @"spread\" + item + ".jpg";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    count++;
                    idList = idList + ", " + item;
                }
                filename = path + @"spread\" + item + ".gif";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    count++;
                    idList = idList + ", " + item;
                }
            }
            MessageBox.Show(count.ToString() + " files removed");
            MessageBox.Show(idList);
        }



        #endregion // Methods
    }
}
