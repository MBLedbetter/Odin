using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public interface IRequestRepository
    {
        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Inserts a website item request into Odin_WebsiteItemRequests
        /// </summary>
        /// <param name="request"></param>
        /// <param name="transaction"></param>
        void InsertWebsiteItemRequests(Request request, OdinContext context);

        /// <summary>
        ///     Inserts a request comment into Odin_RequestComments
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comment"></param>
        /// <param name="transaction"></param>
        void InsertRequestComment(int request, string comment, OdinContext context);

        #endregion // Public Insert Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieve all submitted requests from Odin_WebsiteItemRequests
        /// </summary>
        /// <returns>List of requests</returns>
        List<Request> RetrieveRequests(bool isAdmin);

        /// <summary>
        ///     Gets all requests with the given request id from Odin_WebsiteItemRequests
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of requests with specified id</returns>
        List<Request> RetrieveRequestList(int requestId);

        /// <summary>
        ///     Retrieves the submit request number from Odin_AutoNumberControlTable and updates the table value by 1
        /// </summary>
        /// <returns></returns>
        string RetrieveSubmitRequestNumber();


        #endregion // Public Retrieval Methods

        /// <summary>
        ///     Retrieve Request Status values
        /// </summary>
        /// <returns>List of Request Status values</returns>
        List<string> SetRequestStatus();

        /// <summary>
        ///     Runs InsertWebsiteItemRequests for each item submitted. Also runs InsertRequestComment
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="status"></param>
        /// <param name="Comment"></param>
        /// <param name="requestNum"></param>
        /// <returns></returns>
        void SubmitRequest(ObservableCollection<ItemObject> items, string status, string comment, string website, int requestNum);

        /// <summary>
        ///     Update Odin_WebsiteItemRequests Table with RequestID, ItemId, Comment, RequestStatus
        /// </summary>
        void UpdateWebsiteRequest(Request request);

        #endregion // Public Methods
    }
}
