using OdinModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
namespace OdinRepositories
{
    public class RequestRepository : IRequestRepository
    {
        #region Properties

        /// <summary>
        ///     gets or sets the repositoryAssigned flag
        /// </summary>
        public bool repositoryAssigned = true;

        /// <summary>
        ///     gets or sets the server name
        /// </summary>
        private string DbServerName { get; set; }

        /// <summary>
        ///     gets or sets the database name
        /// </summary>
        private string DbName { get; set; }

        /// <summary>
        ///     gets or sets the database password
        /// </summary>
        private string DbPassword { get; set; }

        /// <summary>
        ///     gets or sets the isLocalTest flag
        /// </summary>
        private bool IsLocalTest { get; set; }

        #endregion // Properties

        #region Request Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="transaction"></param>
        public void InsertWebsiteItemRequests(Request request, SqlTransaction transaction)
        {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertWebsiteItemRequests", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@RequestId", SqlDbType.VarChar).Value = request.RequestId;
            sqlCommand.Parameters.Add("@ItemId", SqlDbType.VarChar).Value = request.ItemId;
            sqlCommand.Parameters.Add("@ItemStatus", SqlDbType.VarChar).Value = request.ItemStatus;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = request.UserName;
            sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "";
            sqlCommand.Parameters.Add("@InStockDate", SqlDbType.VarChar).Value = request.InStockDate;
            sqlCommand.Parameters.Add("@RequestStatus", SqlDbType.VarChar).Value = request.RequestStatus;
            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comment"></param>
        /// <param name="transaction"></param>
        public void InsertRequestComment(int request, string comment, SqlTransaction transaction)
        {
            SqlCommand sqlCommand = new SqlCommand("Odin_InsertRequestComments", transaction.Connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@RequestId", SqlDbType.VarChar).Value = request.ToString();
            sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar).Value = comment;
            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RepositoryAssigned()
        {
            return repositoryAssigned;
        }

        /// <summary>
        ///     Retrieve all submitted requests
        /// </summary>
        /// <returns>List of requests</returns>
        public List<Request> RetrieveRequests()
        {
            List<Request> RequestList = new List<Request>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebsiteItemRequests", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Request request = new Request(
                            Convert.ToInt32(reader["RequestId"]),
                            Convert.ToString(reader["ItemId"]).Trim(),
                            Convert.ToString(reader["ItemStatus"]).Trim(),
                            Convert.ToString(reader["UserName"]).Trim(),
                            Convert.ToString(reader["DttmSubmitted"]).Trim(),
                            Convert.ToString(reader["InStockDate"]).Trim(),
                            Convert.ToString(reader["Comment"]).Trim(),
                            Convert.ToString(reader["RequestStatus"]).Trim()
                            );
                    request.GroupComment = Convert.ToString(reader["GroupComment"]).Trim();
                    RequestList.Add(request);
                }
            }
            return RequestList;
        }

        /// <summary>
        ///     Gets all requests with a specific request id
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns>List of requests with specified id</returns>
        public List<Request> RetrieveRequestList(int requestId)
        {
            List<Request> RequestList = new List<Request>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebsiteItemRequestList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@requestId", SqlDbType.VarChar).Value = requestId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Request request = new Request(
                            Convert.ToInt32(reader["RequestId"]),
                            Convert.ToString(reader["ItemId"]).Trim(),
                            Convert.ToString(reader["ItemStatus"]).Trim(),
                            Convert.ToString(reader["UserName"]).Trim(),
                            Convert.ToString(reader["DttmSubmitted"]).Trim(),
                            Convert.ToString(reader["InStockDate"]).Trim(),
                            Convert.ToString(reader["Comment"]).Trim(),
                            Convert.ToString(reader["RequestStatus"]).Trim()
                            );
                    RequestList.Add(request);
                }
            }
            return RequestList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string RetrieveSubmitRequestNumber()
        {
            string autoNumber = string.Empty;
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetNextWebsiteIdentifier", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    autoNumber = Convert.ToString(reader["NextAutoNumber"]);
                }
            }
            return autoNumber;
        }

        /// <summary>
        ///     Retrieves all requests made by current user
        /// </summary>
        /// <returns></returns>
        public List<Request> RetrieveUserRequests()
        {
            List<Request> RequestList = new List<Request>();
            using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName, DbName, DbPassword, IsLocalTest).GetConnection(IsLocalTest))
            {
                SqlCommand sqlCommand = new SqlCommand("Odin_GetWebsiteItemRequests_User", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = Environment.UserName;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Request request = new Request(
                            Convert.ToInt32(reader["RequestId"]),
                            Convert.ToString(reader["ItemId"]).Trim(),
                            Convert.ToString(reader["ItemStatus"]).Trim(),
                            Convert.ToString(reader["UserName"]).Trim(),
                            Convert.ToString(reader["DttmSubmitted"]).Trim(),
                            Convert.ToString(reader["InStockDate"]).Trim(),
                            Convert.ToString(reader["Comment"]).Trim(),
                            Convert.ToString(reader["RequestStatus"]).Trim()
                            );
                    RequestList.Add(request);
                }
            }
            return RequestList;
        }

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
        /// 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="status"></param>
        /// <param name="Comment"></param>
        /// <param name="requestNum"></param>
        /// <returns></returns>
        public bool SubmitRequest(ObservableCollection<ItemObject> Items, string status, string Comment, int requestNum)
        {
            string date = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName,DbName,DbPassword,IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        foreach (ItemObject item in Items)
                        {
                            Request request = new Request(requestNum, item.ItemId, status, Environment.UserName, date, item.InStockDate, "", "Pending");
                            InsertWebsiteItemRequests(request, sqlTransaction);
                        }
                        if (!(string.IsNullOrEmpty(Comment)))
                        {
                            InsertRequestComment(requestNum, Comment, sqlTransaction);
                        }

                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
            }
            return false;

        }

        /// <summary>
        ///     Update Odin_WebsiteItemRequests Table with RequestID, ItemId, Comment, RequestStatus
        /// </summary>
        public bool UpdateWebsiteRequest(Request request)
        {
            try
            {
                using (SqlConnection sqlConnection = new DatabaseConnection(DbServerName,DbName,DbPassword,IsLocalTest).GetConnection(IsLocalTest))
                {
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        SqlCommand sqlCommand = new SqlCommand("Odin_UpdateWebsiteRequest", sqlTransaction.Connection, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@RequestId", SqlDbType.VarChar).Value = request.RequestId;
                        sqlCommand.Parameters.Add("@ItemId", SqlDbType.VarChar).Value = request.ItemId;
                        sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar).Value = request.Comment;
                        sqlCommand.Parameters.Add("@RequestStatus", SqlDbType.VarChar).Value = request.RequestStatus;
                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex.ToString());
            }
            return false;
        }

        #endregion // Request Methods

        #region Constructor

        /// <summary>
        ///     Constructs the requestRepository
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbPassword"></param>
        /// <param name="dbServerName"></param>
        /// <param name="isLocalTest"></param>
        public RequestRepository(string dbName, string dbPassword, string dbServerName, bool isLocalTest)
        {
            DbServerName = dbServerName;
            DbName = dbName;
            DbPassword = dbPassword;
            IsLocalTest = isLocalTest;
        }

        #endregion // Constructor
    }
}
