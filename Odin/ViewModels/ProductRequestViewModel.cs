using Mvvm;
using OdinModels;
using OdinServices;
using Odin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;

namespace Odin.ViewModels
{
    public class ProductRequestViewModel : INotifyPropertyChanged
    {

        #region Command Properties

        /// <summary>
        ///     Change Request Status button triggered command
        /// </summary>
        public ICommand ChangeRequestStatusCommand
        {
            get
            {
                if (_changeRequestStatusCommand == null)
                {
                    _changeRequestStatusCommand = new RelayCommand(param => ChangeRequestStatus());
                }
                return _changeRequestStatusCommand;
            }
        }
        private RelayCommand _changeRequestStatusCommand;

        /// <summary>
        ///     Create CSV button triggered command
        /// </summary>
        public ICommand CreateCSVCommand
        {
            get
            {
                if (_createCSVCommand == null)
                {
                    _createCSVCommand = new RelayCommand(param => CreateCSVFile());
                }
                return _createCSVCommand;
            }
        }
        private RelayCommand _createCSVCommand;

        /// <summary>
        ///     Pull Images button triggered command
        /// </summary>
        public ICommand PullImagesCommand
        {
            get
            {
                if (_pullImagesCommand == null)
                {
                    _pullImagesCommand = new RelayCommand(param => PullImages());
                }
                return _pullImagesCommand;
            }
        }
        private RelayCommand _pullImagesCommand;
        
        /// <summary>
        ///     Submit Confirmation button triggered command
        /// </summary>
        public ICommand SubmitRequestCommand
        {
            get
            {
                if (_submitRequestCommand == null)
                {
                    _submitRequestCommand = new RelayCommand(param => SubmitRequest());
                }
                return _submitRequestCommand;
            }
        }
        private RelayCommand _submitRequestCommand;

        /// <summary>
        ///     ItemRequest_MouseDoubleClick triggered command
        /// </summary>
        public ICommand ViewSelectedItemRequestCommand
        {
            get
            {
                if (_viewSelectedItemRequestCommand == null)
                {
                    _viewSelectedItemRequestCommand = new RelayCommand(param => ViewSelectedItemRequest());
                }
                return _viewSelectedItemRequestCommand;
            }
        }
        private RelayCommand _viewSelectedItemRequestCommand;

        /// <summary>
        ///     Request_MouseDoubleClick triggered command
        /// </summary>
        public ICommand ViewSelectedRequestCommand
        {
            get
            {
                if (_viewSelectedRequestCommand == null)
                {
                    _viewSelectedRequestCommand = new RelayCommand(param => RetrieveRequestList(null));
                }
                return _viewSelectedRequestCommand;
            }
        }
        private RelayCommand _viewSelectedRequestCommand;

        #endregion // Command Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // Events

        #region Public Properties

        /// <summary>
        ///     Flag for displaying request editing tools for admins and hiding for users
        /// </summary>
        public bool AdminStatus { get; set; }

        /// <summary>
        ///     Holds coresponding text values for AdminStatus used for hiding and showing tools
        /// </summary>
        public string AdminVisible
        {
            get
            {
                if (_adminVisible == string.Empty)
                {
                    _adminVisible = "Hidden";
                }
                return _adminVisible;
            }
            set
            {
                _adminVisible = value;
                OnPropertyChanged("AdminVisible");
            }
        }
        private string _adminVisible = string.Empty;

        /// <summary>
        ///     Gets or sets the ControlVisibility
        /// </summary>
        public string ControlVisibility { get; set; }

        /// <summary>
        ///     Gets or sets the EmailService
        /// </summary>
        public EmailService EmailService { get; set; }

        /// <summary>
        ///     Gets or sets the ExcelService
        /// </summary>
        public ExcelService ExcelService { get; set; }

        /// <summary>
        ///     Gets or sets the ItemService
        /// </summary>
        public ItemService ItemService { get; set; }

        /// <summary>
        ///     Gets or sets the OptionService
        /// </summary>
        public OptionService OptionService { get; set; }

        /// <summary>
        ///     List of all Request containing a Pending Item
        /// </summary>
        public List<Request> RequestList
        {
            get
            {
                if (_requestList == null)
                {
                    _requestList = new List<Request>();
                }
                return _requestList;
            }
            private set
            {
                _requestList = value;
                OnPropertyChanged("RequestList");
            }

        }
        private List<Request> _requestList;

        /// <summary>
        ///     List of request status options
        /// </summary>
        public List<string> RequestStatusList
        {
            get
            {
                return GlobalData.RequestStatus;
            }
        }

        /// <summary>
        ///     Selected item from the RequestList
        /// </summary>
        public Request SelectedRequest
        {
            get
            {
                if (_selectedRequest == null)
                {
                    _selectedRequest = new Request(0, "", "", "", "", "", "", "", "");
                }
                return _selectedRequest;
            }
            set
            {
                _selectedRequest = value;
                OnPropertyChanged("SelectedRequest");
            }

        }
        private Request _selectedRequest;

        /// <summary>
        ///     The status of the selected Request (from RequestList)
        /// </summary>
        public string SelectedRequestStatus
        {
            get
            {
                if (_selectedRequestStatus == null)
                {
                    _selectedRequestStatus = string.Empty;
                }
                return _selectedRequestStatus;
            }
            set
            {
                _selectedRequestStatus = value;
                OnPropertyChanged("SelectedRequestStatus");
            }

        }
        private string _selectedRequestStatus;

        /// <summary>
        ///     The selected item from SelectedRequestList
        /// </summary>
        public Request SelectedRequest2
        {
            get
            {
                if (_selectedRequest2 == null)
                {
                    _selectedRequest2 = new Request(0, "", "", "", "", "", "");
                }
                return _selectedRequest2;
            }
            set
            {
                _selectedRequest2 = value;
                OnPropertyChanged("SelectedRequest2");
            }

        }
        private Request _selectedRequest2;

        /// <summary>
        ///     A list of all items withing the Selected Request
        /// </summary>
        public List<Request> SelectedRequestlingList
        {
            get
            {
                if (_selectedRequestlingList == null)
                {
                    _selectedRequestlingList = new List<Request>();
                }
                return _selectedRequestlingList;
            }
            set
            {
                _selectedRequestlingList = value;
                OnPropertyChanged("SelectedRequestlingList");
            }

        }
        private List<Request> _selectedRequestlingList;
        
        #endregion // Public Properties

        #region Methods

        /// <summary>
        ///     Update the request status of selected items children
        /// </summary>
        public void ChangeRequestStatus()
        {
            try
            {
                int requestId = 0;
                foreach (Request request in this.SelectedRequestlingList)
                {
                    requestId = request.RequestId;
                    request.RequestStatus = this.SelectedRequestStatus;
                    OptionService.UpdateWebsiteRequest(request);
                }

                Request SelectedRequestHolder = this.SelectedRequest;
                this.RequestList = LoadRequests();
                this.SelectedRequestlingList = OptionService.RetrieveRequestList(requestId);
                this.SelectedRequest = SelectedRequestHolder;
                MessageBox.Show("Got it!");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to change the request status.", ex.ToString());
            }
        }

        /// <summary>
        ///     Creates a CSV file to the desktop for the currently selected request
        /// </summary>
        public void CreateCSVFile()
        {
            if (this.SelectedRequest.Website == "ShopTrends.com")
            {
                CreateMagento2File();
            }
            else
            {
                CreateMagento1File();
            }

        }

        public void CreateMagento1File()
        {
            if (SelectedRequestlingList.Count > 0)
            {
                string requestId = SelectedRequestlingList[0].RequestId.ToString();
                string requestType = SelectedRequestlingList[0].ItemStatus.ToString();
                ObservableCollection<ItemObject> itemList = new ObservableCollection<ItemObject>();
                int count = 1;
                foreach (Request request in SelectedRequestlingList)
                {
                    ItemService.UpdateNewDate(request.ItemId);

                    ItemObject item = new ItemObject(1);
                    if (requestType != "Remove")
                    {
                        item = ItemService.RetrieveItem(request.ItemId, count);

                    }
                    else
                    {
                        item.ItemId = request.ItemId;
                    }
                    // item.ItemStatus = request.ItemStatus;
                    item.Status = request.ItemStatus;
                    itemList.Add(item);
                    count++;
                }
                ExcelService.WriteMagentoCsv(itemList, requestId, requestType);
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a Request");
            }
        }

        /// <summary>
        ///     Creates a CSV file to the desktop for the currently selected request
        /// </summary>
        public void CreateMagento2File()
        {
            if (SelectedRequestlingList.Count > 0)
            {
                string requestId = SelectedRequestlingList[0].RequestId.ToString();
                string requestType = SelectedRequestlingList[0].ItemStatus.ToString();
                ObservableCollection<ItemObject> itemList = new ObservableCollection<ItemObject>();
                int count = 1;
                foreach (Request request in SelectedRequestlingList)
                {
                    ItemService.UpdateNewDate(request.ItemId);

                    ItemObject item = new ItemObject(1);
                    if (requestType != "Remove")
                    {
                        item = ItemService.RetrieveItem(request.ItemId, count);
                    }
                    else
                    {
                        item.ItemId = request.ItemId;
                    }
                    // item.ItemStatus = request.ItemStatus;
                    item.Status = request.ItemStatus;
                    itemList.Add(item);
                    count++;
                }
                ExcelService.WriteMagento2Csv(itemList, requestId, requestType);
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a Request");
            }

        }

        /// <summary>
        ///     Load in a list of Request objects to populate the Request List
        /// </summary>
        /// <returns></returns>
        public List<Request> LoadRequests()
        {
            List<Request> requestList = new List<Request>();
            List<int> requestIds = new List<int>();
            List<Request> rawRequests = new List<Request>();
            try
            {
                if (this.AdminStatus)
                {
                    rawRequests = OptionService.RetrieveRequests();
                }
                else
                {
                    rawRequests = OptionService.RetrieveUserRequests();
                }

                int PresentId = 0;
                string PresentStatus = string.Empty;

                for (int i = 0; i < rawRequests.Count; i++)
                {
                    int nextId = i + 1;
                    int CurrentId = rawRequests[i].RequestId;
                    string CurrentStatus = rawRequests[i].RequestStatus;

                    if (PresentId != CurrentId)
                    {
                        PresentId = CurrentId;
                        requestIds.Add(CurrentId);
                        PresentStatus = CurrentStatus;
                    }
                    else
                    {
                        switch (PresentStatus)
                        {
                            case "Incomplete":
                                break;

                            case "Pending":
                                if (CurrentStatus == "Incomplete") { PresentStatus = CurrentStatus; }
                                break;

                            case "Canceled":
                                if (CurrentStatus == "Incomplete") { PresentStatus = CurrentStatus; }
                                if (CurrentStatus == "Pending") { PresentStatus = CurrentStatus; }
                                break;
                            case "Complete":
                                if (CurrentStatus == "Incomplete") { PresentStatus = CurrentStatus; }
                                if (CurrentStatus == "Pending") { PresentStatus = CurrentStatus; }
                                break;
                        }
                    }
                    if (nextId == rawRequests.Count)
                    {
                        Request request = new Request(PresentId, rawRequests[i].UserName, rawRequests[i].DttmSubmitted, PresentStatus);
                        request.GroupComment = rawRequests[i].GroupComment;
                        requestList.Add(request);
                    }
                    else if (rawRequests[i].RequestId != rawRequests[nextId].RequestId)
                    {
                        Request request = new Request(PresentId, rawRequests[i].UserName, rawRequests[i].DttmSubmitted, PresentStatus);
                        request.GroupComment = rawRequests[i].GroupComment;
                        requestList.Add(request);
                    }
                }// End for (int i = 0; i <= RawRequests.Count; i++)
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to load the requests.", ex.ToString());
            }
            return requestList;

        }

        /// <summary>
        ///     Copies the images for the given request into a folder on the users desktop
        /// </summary>
        public void PullImages()
        {
            List<string> itemIds = new List<string>();
            foreach (Request r in this.SelectedRequestlingList)
            {
                itemIds.Add(r.ItemId);
            }
            List<string> missingImages = ItemService.PullImages(itemIds);
            if (missingImages.Count>0)
            {
                AlertView window = new AlertView
                {
                    DataContext = new AlertViewModel(missingImages, "Alert", "The following images were not found in the captures folder or were too large.")
                };
                window.ShowDialog();
            }
        }

        /// <summary>
        ///     Loads request children into SelectedRequestlingList
        /// </summary>
        /// <param name="request"></param>
        public void RetrieveRequestList(Request request)
        {
            List<Request> requestList = new List<Request>();

            try
            {
                this.SelectedRequestlingList = OptionService.RetrieveRequestList(this.SelectedRequest.RequestId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to retrieve the request list.", ex.ToString());
            }
        }
        
        /// <summary>
        ///    Updates request status and sends out notification email
        /// </summary>
        public void SubmitRequest()
        {
            bool valid = true;
            if (this.SelectedRequest.RequestStatus == "Pending")
            {
                DialogResult dialogResult = MessageBox.Show("The status of this request is still pending. Do you wish to proceed?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    valid = false;
                }
            }
            if (valid)
            {
                try
                {
                    List<Request> requests = OptionService.RetrieveRequestList(SelectedRequest.RequestId);

                    EmailService.SendStatusChangedEmail(SelectedRequest.RequestId.ToString(), requests, SelectedRequest.UserName);
                    foreach (Request request in requests)
                    {
                        if (SelectedRequestStatus != "")
                        {
                            request.RequestStatus = SelectedRequestStatus;
                        }
                        OptionService.UpdateWebsiteRequest(request);
                        if (request.RequestStatus == "Completed")
                        {
                            ItemObject item = new ItemObject(0)
                            {
                                ItemId = request.ItemId
                            };
                            ItemService.UpdateOnSite(item, request.Website);
                        }
                    }
                    System.Windows.MessageBox.Show("Requests Submitted");
                }
                catch(Exception ex)
                {
                    ErrorLog.LogError("Odin was unable to submit the request.", ex.ToString());
                }
            }
        } 

        /// <summary>
        ///     Show information regarding a specific requestling
        /// </summary>
        public void ViewSelectedItemRequest()
        {
            ItemRequestView window = new ItemRequestView();
            window.DataContext = new ItemRequestViewModel(OptionService, SelectedRequest2, AdminStatus);
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                this.RequestList = LoadRequests(); ;
            }
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the ProductRequestViewModel
        /// </summary>
        /// <param name="controlVisibility"></param>
        /// <param name="adminstatus"></param>
        /// <param name="emailService"></param>
        /// <param name="excelService"></param>
        /// <param name="optionService"></param>
        /// <param name="itemService"></param>
        public ProductRequestViewModel(
            bool controlVisibility,
            bool adminstatus,
            EmailService emailService,
            ExcelService excelService,
            OptionService optionService,
            ItemService itemService)
        {
            this.ExcelService = excelService ?? throw new ArgumentNullException("excelService");
            this.ControlVisibility = (controlVisibility) ? "Visible" : "Hidden";
            this.AdminStatus = adminstatus;
            this.EmailService = emailService ?? throw new ArgumentNullException("emailService");
            this.ItemService = itemService ?? throw new ArgumentNullException("itemService");
            this.OptionService = optionService ?? throw new ArgumentNullException("optionService");
            try
            {
                this.RequestList = LoadRequests();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError("Odin was unable to load the requests.", ex.ToString());
            }
        }

        #endregion // Constructor
    }
}
