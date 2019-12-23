using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilesDownload.Model
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class ConfigInfo
    {
        /// <summary>
        /// 下载时间间隔（单位：秒）
        /// </summary>
        private string timeInterval { get; set; }

        /// <summary>
        /// 下载个数
        /// </summary>
        private string downloadNumber { get; set; }

        /// <summary>
        /// 是否循环
        /// </summary>
        public bool IsCircle { get; set; }

        private string[] urls { get; set; }

        public ConfigInfo(string timeInterval, string downloadNumber)
        {
            this.timeInterval = timeInterval;
            this.downloadNumber = downloadNumber;
        }


        //private int downloadNumberMax;
        //private int donwloadNumberMin;

        private int GetDownloadNumberMax()
        {
            if (downloadNumber.Contains("-"))
            {
                var nums = downloadNumber.Split('-');
                if (nums.Length != 2)
                {
                    throw new Exception("下载个数范围配置有误");
                }
                return int.Parse(nums[1]);
            }
            return 0;
        }


        private int GetDownloadNumberMin()
        {
            if (downloadNumber.Contains("-"))
            {
                var nums = downloadNumber.Split('-');
                if (nums.Length != 2)
                {
                    throw new Exception("下载个数范围配置有误");
                }
                return int.Parse(nums[0]);
            }
            return 0;
        }


        public int GetDownloadNum()
        {
            Random r = new Random();
            return r.Next(GetDownloadNumberMin(), GetDownloadNumberMax() + 1);
        }

        public int GetTimeInterval()
        {
            return int.Parse(timeInterval)*1000;
        }


        public string Info()
        {
            return $"下载时间间隔：{this.timeInterval}秒，下载个数：{downloadNumber}，{(IsCircle ? "" : "非")}循环下载";
        }


        public void SetUrls(string urlsText)
        {
            this.urls = GetUrlsFilter(urlsText);
        }

        public string[] GetUrls()
        {
            return this.urls;
        }

        /// <summary>
        /// 获取有效格式的urls
        /// </summary>
        /// <param name="urlsText"></param>
        /// <returns></returns>
        private string[] GetUrlsFilter(string urlsText)
        {
            urlsText = (urlsText ?? "").Trim();
            if (urlsText == "") return new string[] { };

            var urls = urlsText.Replace("\r\n", "\n").Split('\n');
            return urls.Where(x => x.StartsWith("http") == true).ToArray();
        }
    }
}
