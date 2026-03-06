using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Net;
namespace RTC_Vision_Lite.Classes
{

    public class cFTP
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool IsConnected { get; set; }
        public string HomeDir { get; set; }
        public string ErrMessage { get; set; }
        WebClient client = null;
        private int RequestTimeout = 100000;
        private int ReadWriteTimeout = 100000;
        internal cFTP(string _HostName, string _UserName, string _PassWord)
        {
            HostName = _HostName;
            UserName = _UserName;
            PassWord = _PassWord;
            HomeDir = "ftp://" + HostName + "/";
        }
        internal void Disconnect()
        {
            client = null;
            IsConnected = false;
        }
        internal bool Connect(int requestTimeout = 100000, int readWriteTimeout = 300000)
        {
            try
            {
                ErrMessage = string.Empty;
                IsConnected = false;
                client = null;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(HomeDir);
                RequestTimeout = requestTimeout;
                ReadWriteTimeout = readWriteTimeout;
                request.Timeout = requestTimeout;
                request.ReadWriteTimeout = readWriteTimeout;
                request.Credentials = new NetworkCredential(UserName, PassWord);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    IsConnected = true;
                    client = new WebClient();
                    client.Credentials = new NetworkCredential(UserName, PassWord);
                }

                return IsConnected;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                return false;
            }
        }
        internal bool IsDirectoryExist(string _Path)
        {
            bool isexist = false;
            if (!IsConnected) return isexist;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_Path);
                request.Credentials = new NetworkCredential(UserName, PassWord);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isexist = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isexist;
        }

        internal bool CreateFolder(string _FolderName)
        {
            if (!IsConnected) return true;

            string path = HomeDir + _FolderName;
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(UserName, PassWord);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    //Console.WriteLine(resp.StatusCode);
                }
            }
            catch
            {
                IsCreated = false;
            }
            return IsCreated;
        }

        internal bool UploadFile(string _FileName, string _Path, bool isAsync = false)
        {
            try
            {
                if (!IsConnected) return false;
                string From = _FileName;
                string To = HomeDir + _Path + "/" + Path.GetFileName(_FileName);
                Uri uriTo = new Uri(To);
                if (isAsync)
                    client.UploadFileAsync(uriTo, WebRequestMethods.Ftp.UploadFile, From);
                else
                    client.UploadFile(To, WebRequestMethods.Ftp.UploadFile, From);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        internal bool DownloadFile(string hostFileName, string newFileName, bool isAsync = false)
        {
            try
            {
                if (!IsConnected || string.IsNullOrEmpty(newFileName)) 
                    return false;
                string From = HomeDir + "/" + hostFileName;
                Uri uriFrom = new Uri(From);
                if (isAsync)
                    client.DownloadFileAsync(uriFrom, newFileName);
                else
                    client.DownloadFile(From, newFileName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
