using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OdinRepositories
{
    public interface IRequestRepository
    {
        #region Request Methods

        /// <summary>
        ///     Retrieve all submitted requests
        /// </summary>
        /// <returns>List of requests</returns>
        List<Request> RetrieveRequests();
        /// <summary>
        ///     Gets all requests with a specific request id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of requests with specified id</returns>
        List<Request> RetrieveRequestList(int requestId);
        string RetrieveSubmitRequestNumber();
        /// <summary>
        ///     Retrieves all requests made by current user
        /// </summary>
        /// <returns></returns>
        List<Request> RetrieveUserRequests();
        bool RepositoryAssigned();
        /// <summary>
        ///     Retrieve Request Status values
        ///     TODO: Create db table for values
        /// </summary>
        /// <returns>List of Request Status values</returns>
        List<string> SetRequestStatus();
        bool SubmitRequest(ObservableCollection<ItemObject> Items, string status, string Comment, int requestNum);
        /// <summary>
        ///     Update Odin_WebsiteItemRequests Table with RequestID, ItemId, Comment, RequestStatus
        /// </summary>
        bool UpdateWebsiteRequest(Request request);

        #endregion // Request Methods

        #region Constructor

        // RequestRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest);

        #endregion // Constructor
    }
}
