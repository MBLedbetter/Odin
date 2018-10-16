using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Windows;

namespace OdinServices
{
    public class FtpService
    {

        #region Properties
                
        /// <summary>
        ///     List of existing file names on the server
        /// </summary>
        public List<string> ExistingImageFiles
        {
            get
            {
                return _existingImageFiles;
            }
            set
            {
                _existingImageFiles = value;
            }
        }
        private List<string> _existingImageFiles = new List<string>();

        /// <summary>
        ///     ftp password
        /// </summary>
        private readonly string FtpPassword = OdinServices.Properties.Resources.ftpPassword;

        /// <summary>
        ///     ftp user name
        /// </summary>
        private readonly string FtpUserName = OdinServices.Properties.Resources.ftpUserName;

        #endregion // Properties

        #region Methods
        
        /// <summary>
        ///     Checks if file exists on server
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CheckFile(string filePath)
        {
            string[] x = filePath.Split('/');
            string fileName = x[x.Length - 1];
            if(this.ExistingImageFiles.Contains(fileName))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Returns a list of existing image files in the media/externalCaptures folder
        /// </summary>
        /// <returns></returns>
        public List<string> ReturnExistingImageFiles()
        {
            List<string> newNames = new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://trendsinternational.com/trendsinternational.com/html/media/externalCaptures/");
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(this.FtpUserName, this.FtpPassword);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string names = reader.ReadToEnd();

            reader.Close();
            response.Close();

            newNames = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            newNames.Remove(".");
            newNames.Remove("..");
            return newNames;
        }

        /// <summary>
        ///     Transfers local files to ftp file location media/externalCaptures
        /// </summary>
        public void SubmitImage(string filePath)
        {
            string[] x = filePath.Split('\\');
            string fileName = x[x.Length - 1];
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://trendsinternational.com" + @"/trendsinternational.com/html/media/externalCaptures/" + fileName);
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(this.FtpUserName, this.FtpPassword);
            // Copy the contents of the file to the request stream.  
            StreamReader sourceStream = new StreamReader(filePath);
            Image img = Image.FromFile(filePath);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            String b64 = Convert.ToBase64String(arr);
            byte[] originalimage = Convert.FromBase64String(b64);
            sourceStream.Close();
            request.ContentLength = originalimage.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(originalimage, 0, originalimage.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();

            this.ExistingImageFiles = ReturnExistingImageFiles();
        }

        #endregion // Methods

        #region Constructor

        /// <summary>
        ///     Constructs the FtpService
        /// </summary>
        public FtpService()
        {
            // this.ExistingImageFiles = ReturnExistingImageFiles();
        }

        #endregion // Constructor
    }
}
