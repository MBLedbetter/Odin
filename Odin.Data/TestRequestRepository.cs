using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public class TestRequestRepository : IRequestRepository
    {
        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Inserts a website item request into Odin_WebsiteItemRequests
        /// </summary>
        /// <param name="request"></param>
        /// <param name="transaction"></param>
        public void InsertWebsiteItemRequests(Request request, OdinContext context)
        {
        }

        /// <summary>
        ///     Inserts a request comment into Odin_RequestComments
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comment"></param>
        /// <param name="transaction"></param>
        public void InsertRequestComment(int request, string comment, OdinContext context)
        {
        }

        #endregion // Public Insert Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieve all submitted requests from Odin_WebsiteItemRequests
        /// </summary>
        /// <returns>List of requests</returns>
        public List<Request> RetrieveRequests(bool isAdmin)
        {
            List<Request> requestList = new List<Request>
            {
                new Request(
                            1,
                            "Itemid",
                            "Itemstatus",
                            "Username",
                            "Dttmsubmitted",
                            "Instockdate",
                            "Comment",
                            "Requeststatus",
                            "Website")
            };
            return requestList;
        }

        /// <summary>
        ///     Gets all requests with the given request id from Odin_WebsiteItemRequests
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of requests with specified id</returns>
        public List<Request> RetrieveRequestList(int requestId)
        {
            List<Request> requestList = new List<Request>();
            requestList.Add(new Request(
                            1,
                            "Itemid",
                            "Itemstatus",
                            "Username",
                            "Dttmsubmitted",
                            "Instockdate",
                            "Comment",
                            "Requeststatus",
                            "Website"));

            return requestList;
        }

        /// <summary>
        ///     Retrieves the submit request number from Odin_AutoNumberControlTable and updates the table value by 1
        /// </summary>
        /// <returns></returns>
        public string RetrieveSubmitRequestNumber()
        {
            string autoNumber = "76";
            return autoNumber;
        }

        /// <summary>
        ///     Retrieves all requests made by current user
        /// </summary>
        /// <returns></returns>
        public List<Request> RetrieveUserRequests()
        {
            List<Request> RequestList = new List<Request>();

            RequestList.Add( new Request(
                1,
                "Itemid",
                "Itemstatus",
                "Username",
                "Dttmsubmitted",
                "Instockdate",
                "Comment",
                "Requeststatus",
                "Website"));
            return RequestList;
        }

        #endregion // Public Retrieval Methods

        /// <summary>
        ///     Retrieve Request Status values
        /// </summary>
        /// <returns>List of Request Status values</returns>
        public List<string> SetRequestStatus()
        {
            List<string> Values = new List<string>();
            Values.Add("Completed");
            Values.Add("Pending");
            Values.Add("Canceled");
            Values.Add("Incomplete");
            return Values;
        }

        /// <summary>
        ///     Runs InsertWebsiteItemRequests for each item submitted. Also runs InsertRequestComment
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="status"></param>
        /// <param name="Comment"></param>
        /// <param name="requestNum"></param>
        /// <returns></returns>
        public void SubmitRequest(ObservableCollection<ItemObject> Items, string status, string comment, string website, int requestNum)
        {
        }

        /// <summary>
        ///     Update Odin_WebsiteItemRequests Table with RequestID, ItemId, Comment, RequestStatus
        /// </summary>
        public void UpdateWebsiteRequest(Request request)
        {
        }

        #endregion // Public Methods
    }
}
