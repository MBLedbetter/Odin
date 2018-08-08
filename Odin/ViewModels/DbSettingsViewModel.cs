using Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Odin.ViewModels
{
    public class DbSettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Commands
        
        public ICommand SaveChangeCommand
        {
            get
            {
                if (_dBSettings == null)
                {
                    _dBSettings = new RelayCommand(param => SaveChange());
                }
                return _dBSettings;
            }
        }
        private RelayCommand _dBSettings;
        
        #endregion

        #region Properties

        public string DbServerName
        {
            get
            {
                if (_dbServerName == null)
                {
                    _dbServerName = string.Empty;
                }
                return _dbServerName;
            }
            set
            {
                _dbServerName = value;
                OnPropertyChanged("DbServerName");
            }
        }
        private string _dbServerName;
        
        public List<string> ServerNames
        {
            get
            {
                if (_serverNames == null)
                {
                    _serverNames = new List<string>();
                }
                return _serverNames;
            }
            set
            {
                _serverNames = value;
                OnPropertyChanged("ServerNames");
            }
        }
        private List<string> _serverNames;

        public string DbName
        {
            get
            {
                if (_dbName == null)
                {
                    _dbName = string.Empty;
                }
                return _dbName;
            }
            set
            {
                _dbName = value;
                OnPropertyChanged("DbName");
            }
        }
        private string _dbName;

        public string DbLoginId
        {
            get
            {
                if (_dbLoginId == null)
                {
                    _dbLoginId = string.Empty;
                }
                return _dbLoginId;
            }
            set
            {
                _dbLoginId = value;
                OnPropertyChanged("DbLoginId");
            }
        }
        private string _dbLoginId;

        public string ImageLocation
        {
            get
            {
                if (_imageLocation == null)
                {
                    _imageLocation = string.Empty;
                }
                return _imageLocation;
            }
            set
            {
                _imageLocation = value;
                OnPropertyChanged("ImageLocation");
            }
        }
        private string _imageLocation;

        public bool Status { get; set; }

        public bool ReturnStatus { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        ///     Add List of server names to db
        /// </summary>
        private void AddServerNames()
        {
            this.ServerNames.Add("FS88PRD");
            this.ServerNames.Add("FS88DEV");
        }

        /// <summary>
        ///     Save database settings.
        /// </summary>
        /// <returns></returns>
        public bool SaveChange() 
        {
            if (CheckInput(this.DbName))
            {
                if(DbName != Odin.Properties.Settings.Default.DbName)
                {
                    Status = true;
                }
                Odin.Properties.Settings.Default.DbServerName = DbServerName;
                Odin.Properties.Settings.Default.DbLoginId = DbLoginId;
                Odin.Properties.Settings.Default.DbName = DbName;
                Odin.Properties.Settings.Default.ImgSource = ImageLocation;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                MessageBox.Show("Check your setting bro");
                return false;
            }
        }

        /// <summary>
        ///     Assigns the server name that coresponds with the selected database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool CheckInput(string db)
        {
            if (db == "FS88PRD")
            {
                DbServerName = "YODA";
                return true;
            }
            else if (db == "FS88DEV")
            {
                DbServerName = "ANAKIN";
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Cancel out of window
        /// </summary>
        /// <returns></returns>
        public bool Cancel()
        {
            this.ReturnStatus = false; 
            return true;
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the DbSettingsViewModel
        /// </summary>
        public DbSettingsViewModel()
        {
            AddServerNames();
            this.ReturnStatus = true;
            Status = false;
            this.DbServerName = Odin.Properties.Settings.Default.DbServerName;
            this.DbLoginId = Odin.Properties.Settings.Default.DbLoginId;
            this.DbName = Odin.Properties.Settings.Default.DbName;
            this.ImageLocation = Odin.Properties.Settings.Default.ImgSource;
            this.ReturnStatus = true;
        }

        #endregion // Constructor
    }
}
