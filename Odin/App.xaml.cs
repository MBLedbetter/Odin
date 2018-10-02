using ExcelLibrary;
using OdinModels;
using OdinServices;
using Odin.ViewModels;
using Odin.Views;
using System;
using System.Windows;
using Odin.Data;
using LogLibrary;

namespace Odin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Properties
        
        public static IOdinContextFactory OdinContextFactory;
       
        #region Service Properties

        public static EmailService EmailService { get; set; }

        public static ExcelService ExcelService { get; set; }

        public static ItemService ItemService { get; set; }

        public static OptionService OptionService { get; set; }

        #endregion // Service Properties

        #region Repositories

        public static ItemRepository ItemRepository { get; set; }
        public static OptionRepository OptionRepository { get; set; }
        public static RequestRepository RequestRepository { get; set; }
        public static TemplateRepository TemplateRepository { get; set; }

        #endregion // Repositories

        /// <summary>
        ///     Gets or sets the WorkbookReader variable
        /// </summary>
        public static WorkbookReader WorkbookReader { get; set; }

        #endregion // Properties

        #region Methods
              
        public static void LoadGlobalValues()
        {
            OptionRepository.RetrieveGloablOptionData();
            ItemRepository.RetrieveGlobalData();
        }
        public static void WireUp()
        {
            ErrorLog.CreateFolder();
            try
            {
                

                ConnectionManager connectionManager = new ConnectionManager(Odin.Properties.Settings.Default.DbServerName, Odin.Properties.Settings.Default.DbName);
                // ConnectionManager connectionManager = new ConnectionManager(@"(local)\SQLExpress", "Odin");
                // connectionManager.SetUseTrustedConnection(true);
                connectionManager.SetUseTrustedConnection(false);
                connectionManager.SetPassword(Odin.Properties.Settings.Default.DbPassword);
                LogServiceFactory logServiceFactory = new LogServiceFactory("Odin");
                OdinContextFactory = new OdinContextFactory(connectionManager, logServiceFactory);
                                
                OdinContext context = OdinContextFactory.CreateContext();
                if (!context.Database.Exists())
                {
                    DbSettingsView window = new DbSettingsView()
                    {
                        DataContext = new DbSettingsViewModel()
                    };
                    window.ShowDialog();
                    OdinContextFactory.CreateContext();
                }

                WorkbookReader = new WorkbookReader();
                ItemRepository = new ItemRepository(OdinContextFactory);
                OptionRepository = new OptionRepository(OdinContextFactory);
                RequestRepository = new RequestRepository(OdinContextFactory);
                TemplateRepository = new TemplateRepository(OdinContextFactory);
                ItemService = new ItemService(WorkbookReader, ItemRepository, TemplateRepository);
                OptionService = new OptionService(OptionRepository, RequestRepository);
                ExcelService = new ExcelService(false, ItemService, OptionService, TemplateRepository, RequestRepository);
                EmailService = new EmailService(OptionService);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ErrorLog.LogError("Odin encountered an error with the database.", e.ToString());
                Environment.Exit(1);
            }
        }

        #endregion // Methods
    }
}
