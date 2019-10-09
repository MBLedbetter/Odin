using Odin.DbTableModels;
using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Odin.Data
{
    public class RequestRepository : IRequestRepository
    {
        #region Fields

        private readonly IOdinContextFactory contextFactory;

        #endregion // Fields

        #region Public Methods

        #region Public Insert Methods

        /// <summary>
        ///     Inserts a website item request into Odin_WebsiteItemRequests
        /// </summary>
        /// <param name="request"></param>
        /// <param name="transaction"></param>
        public void InsertWebsiteItemRequests(Request request, OdinContext context)
        {
            context.OdinWebsiteItemRequests.Add(new OdinWebsiteItemRequests
            {
                RequestId = request.RequestId,
                ItemId = request.ItemId,
                ItemStatus = request.ItemStatus,
                UserName = request.UserName,
                Comment = request.Comment,
                DttmSubmitted = DateTime.Now.ToString(),
                InStockDate = request.InStockDate,
                RequestStatus = request.RequestStatus,
                Website = request.Website
            });
        }

        /// <summary>
        ///     Inserts a request comment into Odin_RequestComments
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comment"></param>
        /// <param name="transaction"></param>
        public void InsertRequestComment(int request, string comment, OdinContext context)
        {
            context.OdinRequestComments.Add(new OdinRequestComments
            {
                Rid = request,
                Groupcomment = comment
            });
        }

        #endregion // Public Insert Methods

        #region Public Retrieval Methods

        /// <summary>
        ///     Retrieve all submitted requests from Odin_WebsiteItemRequests
        /// </summary>
        /// <returns>List of requests</returns>
        public List<Request> RetrieveRequests(bool isAdmin)
        {
            List<Request> requestList = new List<Request>();
            List<OdinWebsiteItemRequests> odinWebsiteItemRequests = new List<OdinWebsiteItemRequests>();
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                if (isAdmin)
                {
                    odinWebsiteItemRequests = (from o in context.OdinWebsiteItemRequests
                                               orderby o.RequestId descending
                                               select o).ToList();
                }
                else
                {
                    odinWebsiteItemRequests = (from o in context.OdinWebsiteItemRequests
                                               where o.UserName == GlobalData.UserName.ToLower()
                                               select o).ToList();
                }
                foreach (OdinWebsiteItemRequests x in odinWebsiteItemRequests)
                {
                    string website = (x.Website != null) ? x.Website.Trim() : "";
                    Request request = new Request(
                        x.RequestId,
                        x.ItemCategory,
                        x.ItemId.Trim(),
                        x.ItemStatus.Trim(),
                        x.UserName.Trim(),
                        x.DttmSubmitted.Trim(),
                        x.InStockDate.Trim(),
                        x.Comment.Trim(),
                        x.RequestStatus.Trim(),
                        website);
                    requestList.Add(request);
                }
            }
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
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                List<OdinWebsiteItemRequests> odinWebsiteItemRequests = (from o in context.OdinWebsiteItemRequests
                                     where o.RequestId == requestId
                                     select o).ToList();

                foreach (OdinWebsiteItemRequests odinWebsiteItemRequest in odinWebsiteItemRequests)
                {
                    requestList.Add(new Request(
                        odinWebsiteItemRequest.RequestId,
                        odinWebsiteItemRequest.ItemCategory,
                        odinWebsiteItemRequest.ItemId,
                        odinWebsiteItemRequest.ItemStatus,
                        odinWebsiteItemRequest.UserName,
                        odinWebsiteItemRequest.DttmSubmitted,
                        odinWebsiteItemRequest.InStockDate,
                        odinWebsiteItemRequest.Comment,
                        odinWebsiteItemRequest.RequestStatus,
                        odinWebsiteItemRequest.Website));
                }
            }
            return requestList;
        }

        /// <summary>
        ///     Retrieves the submit request number from Odin_AutoNumberControlTable and updates the table value by 1
        /// </summary>
        /// <returns></returns>
        public string RetrieveSubmitRequestNumber()
        {
            string autoNumber = string.Empty;

            using (OdinContext context = this.contextFactory.CreateContext())
            {
                OdinAutoNumberControlTable odinAutoNumberControlTable = (from o in context.OdinAutoNumberControlTable
                                     where o.Identifier == "WebSiteIdentifier"
                                     select o).FirstOrDefault();
                autoNumber = Convert.ToString(odinAutoNumberControlTable.Nextautonumber);
                odinAutoNumberControlTable.Nextautonumber++;
                context.SaveChanges();
            }
            return autoNumber;
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
            string date = DateTime.Now.ToString("M/d/yyyy");
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                foreach (ItemObject item in Items)
                {
                    Request request = new Request(requestNum, item.ItemCategory, item.ItemId, status, Environment.UserName, date, item.InStockDate, comment, "Pending", website);
                    InsertWebsiteItemRequests(request, context);
                }
                if (!(string.IsNullOrEmpty(comment)))
                {
                    InsertRequestComment(requestNum, comment, context);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Update Odin_WebsiteItemRequests Table with RequestID, ItemId, Comment, RequestStatus
        /// </summary>
        public void UpdateWebsiteRequest(Request request)
        {
            using (OdinContext context = this.contextFactory.CreateContext())
            {
                OdinWebsiteItemRequests odinWebsiteItemRequests = (from o in context.OdinWebsiteItemRequests
                               where o.ItemId == request.ItemId
                               && o.RequestId == request.RequestId
                               select o).FirstOrDefault();
                if (odinWebsiteItemRequests != null)
                {
                    odinWebsiteItemRequests.Comment = request.Comment;
                    odinWebsiteItemRequests.RequestStatus = request.RequestStatus;
                    context.SaveChanges();
                }
            }
        }

        #endregion // Public Methods

        #region Constructor

        /// <summary>
        ///     Constructs the requestRepository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public RequestRepository(IOdinContextFactory contextFactory)
        {
            if (contextFactory == null)
            {
                throw new ArgumentNullException("contextFactory");
            }
            this.contextFactory = contextFactory;
        }

        #endregion // Constructor
    }
}
