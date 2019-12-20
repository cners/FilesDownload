
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace FilesDownload.Infrastructure
{
    public class HttpHelper
    {

        ///   文件下载 
        ///   </summary> 
        ///   <param   name="url">连接</param> 
        ///   <param   name="fileName">本地保存文件名</param> 
        public static DonwloadResult Download(string url, string fileName)
        {
            long fileSize = 0;
            long donwloadedFileSize = 0;
            var result = new DonwloadResult();

            Stopwatch s = new Stopwatch();
            try
            {
                s.Start();
                var fileInfo = GetFileSize(url);
                fileSize = fileInfo.FileSize;
                var suffix = GetFileSuffix(fileInfo.FileType);

                if (suffix == "")
                {
                    suffix = url.Substring(url.LastIndexOf('.') + 1).ToLower();
                    if (suffix == "")
                        throw new Exception("不支持该文件类型的下载");
                }
                fileName = fileName + "." + suffix;


                s.Stop();
                if (fileSize > 0)
                {
                    WebClient webClient = new WebClient();
                    using (Stream read = webClient.OpenRead(url))
                    {
                        //判断并建立文件 
                        if (CreateFile(fileName))
                        {
                            byte[] mbyte = new byte[1024 * 1024];
                            int readL = read.Read(mbyte, 0, 1024 * 1024);
                            using (Stream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                //读取流 
                                while (readL != 0)
                                {
                                    donwloadedFileSize += readL;
                                    fs.Write(mbyte, 0, readL);
                                    readL = read.Read(mbyte, 0, 1024 * 1024);
                                }
                            }
                        }
                    }
                }
                result.Status = DonwloadStatus.Success;
                result.FileSize = fileSize;
                result.FileType = suffix;
                result.Message = $"预取大小{s.ElapsedMilliseconds}ms";
                return result;
            }
            catch (Exception ex)
            {
                s.Stop();
                result.Status = DonwloadStatus.Fail;
                result.Message = ex.Message;
                return result;
            }
        }
        ///   <summary> 
        ///   获取下载文件大小
        ///   </summary> 
        ///   <param   name="url">连接</param> 
        ///   <returns>文件长度</returns> 
        public static FileInfo GetFileSize(string url)
        {
            var fileInfo = new FileInfo();
            try
            {
                WebRequest wrq = WebRequest.Create(url);
                WebResponse wrp = (WebResponse)wrq.GetResponse();
                fileInfo.FileSize = wrp.ContentLength;
                fileInfo.FileType = wrp.ContentType.ToLower();
                wrp.Close();
                return fileInfo;
            }
            catch (Exception ex)
            {
                fileInfo.FileType = "";
                fileInfo.FileSize = 0;
                return fileInfo;
            }
        }

        ///   <summary> 
        ///   建立文件(文件如已经存在，删除重建) 
        ///   </summary> 
        ///   <param   name="fileName">文件全名(包括保存目录)</param> 
        ///   <returns></returns> 
        private static bool CreateFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                Stream s = File.Create(fileName);
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public class DonwloadResult : FileInfo
        {
            public DonwloadStatus Status { get; set; }

            public string Message { get; set; }


        }

        public class FileInfo
        {
            public long FileSize { get; set; }

            public string FileType { get; set; }
        }

        public enum DonwloadStatus
        {
            Success = 1,
            Fail = 2
        }

        /// <summary>
        /// 获取文件下载速度
        /// </summary>
        /// <param name="fileSizeBytpeLength"></param>
        /// <param name="elapsedMilliseconds"></param>
        /// <returns></returns>
        public static double GetDonwloadRate(long fileSizeBytpeLength, long elapsedMilliseconds)
        {
            if (fileSizeBytpeLength == 0) return 0;
            if (elapsedMilliseconds == 0) return 0;
            double fe = fileSizeBytpeLength / elapsedMilliseconds;
            return Math.Round(fe * 1000 / 1024d, 2);
        }

        public static string GetFileSuffix(string fileType)
        {
            if (string.IsNullOrEmpty(fileType)) return "";
            if (fileType.StartsWith("image")) return "jpg";
            else return "";
        }
    }
}