using Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Odin.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        ///     Gets / sets the version number
        /// </summary>
        public string Version { get; set; }

        #endregion // Properties

        #region Constructor

        /// <summary>
        ///     Constructs the about view
        /// </summary>
        public AboutViewModel()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Version = fvi.FileVersion;
        }

        #endregion // Constructor
    }
}
