using FilesDownload.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesDownload
{
    public partial class Start : Form
    {

        private const string FILE_SAVE_DIR = "files";

        private string _preSavePath = "";

        public Start()
        {
            InitializeComponent();
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文本文件|*.txt|所有文件|*.*";
            dialog.Title = "保存下载日志";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;

                using (StreamWriter writer = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    writer.Write(txtLog.Text);
                }
                MessageBox.Show("保存完成");
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnOpenSavePath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e," + _preSavePath;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// 下载文本框内url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            DoDownload();
        }
        /// <summary>
        /// 执行下载业务
        /// </summary>
        private void DoDownload()
        {
            btnDonwload.Text = "下载中";
            try
            {
                LogInfo("【启动下载】");
                var urls = GetUrlsFilter(txtUrls.Text);
                if (urls.Length == 0)
                {
                    LogInfo("未识别到有效链接，终止下载");
                    return;
                }
                LogInfo($"已识别有效格式链接 {urls.Length} 个");

                var savePath = System.IO.Directory.GetCurrentDirectory() + "\\" + FILE_SAVE_DIR + "\\" + GetToday();
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                Stopwatch globalStopwatch = new Stopwatch();
                Stopwatch perStopwatch = new Stopwatch();
                var crtPrefix = GetRandomLotno();

                globalStopwatch.Start();
                long globalFineSize = 0;

                for (int i = 0; i < urls.Length; i++)
                {
                    var url = urls[i];


                    var filename = GetRandomFilename(crtPrefix + "-" + (i + 1));
                    LogInfo($"正在下载文件[{i + 1}] [{filename}]......", false);

                    perStopwatch.Restart();
                    var result = HttpHelper.Download(url, savePath + "\\" + filename);
                    perStopwatch.Stop();

                    if (result.Status == HttpHelper.DonwloadStatus.Success)
                    {
                        var rate = HttpHelper.GetDonwloadRate(result.FileSize, perStopwatch.ElapsedMilliseconds);

                        globalFineSize += result?.FileSize ?? 0;
                        LogInfo($"完成......大小：{result?.FileSize} byte,总耗时{perStopwatch.ElapsedMilliseconds}ms,平均：{rate}KB/s,{result.Message}");
                    }
                    else
                    {
                        LogInfo($"下载失败......耗时{perStopwatch.ElapsedMilliseconds}ms,{result.Message}");
                    }
                }



                _preSavePath = savePath;
                btnOpenSavePath.Visible = true;


                globalStopwatch.Stop();
                var grate = HttpHelper.GetDonwloadRate(globalFineSize, globalStopwatch.ElapsedMilliseconds);
                LogInfo($"全部下载完成");
                LogInfo($"{urls.Length} 个文件,{globalFineSize}byte,总耗时：{globalStopwatch.ElapsedMilliseconds}ms,平均：{Math.Round(double.Parse((globalStopwatch.ElapsedMilliseconds / urls.Length).ToString()))}ms/个,{grate}KB/s");
                LogInfo($"保存目录：{savePath}");
                LogInfo($"下载批次：{crtPrefix}");

            }
            catch (Exception ex)
            {
                LogInfo($"下载失败！！！{ex.Message}");
            }
            finally
            {
                btnDonwload.Text = "下载";
            }
        }
        /// <summary>
        /// 获取有效格式的urls
        /// </summary>
        /// <param name="urlsText"></param>
        /// <returns></returns>
        private string[] GetUrlsFilter(string urlsText)
        {
            urlsText = (urlsText ?? "").Trim();
            if (urlsText == "") return null;

            var urls = urlsText.Replace("\r\n", "\n").Split('\n');
            return urls.Where(x => x.StartsWith("http") == true).ToArray();
        }
        public string GetToday() => DateTime.Now.ToString("yyyy-MM-dd");

        public string GetRandomFilename(string prefix = null) =>
            (prefix == null ? "" : prefix + "-") + Guid.NewGuid().ToString("N").Substring(0, 8);

        public string GetRandomLotno() => Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void LogInfo(string message, bool isEnter = true)
        {
            txtLog.Text += message + (isEnter ? "\r\n" : "");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void btnLoadSuning_Click(object sender, EventArgs e)
        {
            txtUrls.Text = @"
http://oss.suning.com/ases/xdfj/a28435144f8849cd894c8f8ee9571499?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014415&Signature=3wuUrUk9r4lVJ6MktbV%2BZkcoeWM%3D
http://oss.suning.com/ases/xdfj/33bb25a3d5b046599a8a549ee66d994f?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014417&Signature=ESntz%2F9SIi0TreQQj1W%2BU5bzBZk%3D
http://oss.suning.com/ases/xdfj/771f13212468410f9f5cd061e32c5bb9?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014420&Signature=TPDci6%2BoHUe4hgTf7ngtkvHoO9g%3D
http://oss.suning.com/ases/xdfj/25ec85b37cb14645b344d9366f4b39b5?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014421&Signature=e%2Bkg3qgOQClPToefYkUBDLtvtUo%3D
http://oss.suning.com/ases/xdfj/9615549342a047339b817a7614d98244?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014425&Signature=q0iTwABAlU2irq6JkRCDcxw1xtE%3D
http://oss.suning.com/ases/xdfj/ba17a77beac84039ac3ed5733c2060d1?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014427&Signature=Qj2Morm5lBLv%2B%2FyEXojtOK%2BbuhM%3D
http://oss.suning.com/ases/xdfj/1b1741f8bcc440b18741ddf59d2e03c3?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014429&Signature=31poPWrpAViuGsbGsWdT99KzIHw%3D
http://oss.suning.com/ases/xdfj/d598b110a4b546e1a8c8e462bc0a8045?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014437&Signature=rpmmV9n7Gk1yBQin83%2BNLo%2FjDi4%3D
http://oss.suning.com/ases/xdfj/4167dcbe85aa405bb49e741359f35e53?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892014444&Signature=ZmWCurog9opj5EPrOQALO2te7Rg%3D
http://oss.suning.com/ases/tmdelay/79a9c284ee324fe5b70f9ab877d23502?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892077212&Signature=f8XT40%2FiYkRvlVHePrTExT3791Y%3D
http://oss.suning.com/ases/tmdelay/18e219e0195b4bc5b281ced7f37165c4?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892077215&Signature=zV%2FS2OblT5SJRpL2rJErXNzHwQo%3D
http://oss.suning.com/ases/tmdelay/1e0de53d0fa34f7f8bb716d588bc452d?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892077219&Signature=MvxFM9hM8AAVn5ks8qfy9hqTxbs%3D
http://oss.suning.com/ases/tmdelay/5180d21e04034c97ace9ea632c653a88?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892077225&Signature=sq4QapPlWkIzA25HshTZAir60Z4%3D
http://oss.suning.com/ases/tmdelay/9bc26f75ded447d6b1224630d51393ff?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892077230&Signature=pJHafGnxEMZSbBb2%2F7j9NUC1y5I%3D
http://oss.suning.com/ases/xdfj/aa56ac2f94d343b9ada8f0a41cd20664?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838179&Signature=urS3F04xhXthO%2FlsKxX4G51Xb2s%3D
http://oss.suning.com/ases/xdfj/c53d358507614ad2978649b6cfa0a6b6?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838181&Signature=IbL0a2Eo%2BG5LY2P%2BunzyWXnZVeY%3D
http://oss.suning.com/ases/xdfj/8fa701910ede4d57afda3a6eac6bd103?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838184&Signature=YN1ymvWKO5dxuh7U8H7IryvThVY%3D
http://oss.suning.com/ases/xdfj/92b9f48dfec44dd3a90406fea632d6e6?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838186&Signature=%2B5cnWjtP0WGrnV71CdMjZaIyF4w%3D
http://oss.suning.com/ases/xdfj/1669261ec5c24f529a798880b9c702e7?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838189&Signature=fuZSohuHKr3B3Vf4QFkyN8xEj10%3D
http://oss.suning.com/ases/xdfj/7316554d6a9048ff80eab70ac23d5a3c?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838208&Signature=ksF3pwM3WPlzYu7GDMKE4KTGhCQ%3D
http://oss.suning.com/ases/xdfj/64303ac30ae04d37a0f59041dc2239ea?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891838211&Signature=oBKJUzbuDM79JIoAqGCX%2BPt8gLw%3D
http://oss.suning.com/ases/xdfj/19238e3d3b984513a9eb35e2eb7e41df?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927759&Signature=exixmfrRNgBR%2Fid2FVwyotMaVVQ%3D
http://oss.suning.com/ases/xdfj/36ad3655566b4253ae0df0c2295cf8c3?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927762&Signature=iEd6gjD1nLs8alQE2O6LBWCqSVk%3D
http://oss.suning.com/ases/xdfj/217e27730a684863898dc02102754762?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927762&Signature=99EKhSxTZy9qzMnzvm9pw9CCyC8%3D
http://oss.suning.com/ases/xdfj/7070082a3cc44f85b3dadb107f4777da?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927764&Signature=mc4pOzPMRFcL2Z9u7D6VpyklRKg%3D
http://oss.suning.com/ases/xdfj/c8ad2ca59c5141f09d3c8a36acaa2611?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927766&Signature=CyMefogbSUN9ArJCXKS%2BdQCbmN0%3D
http://oss.suning.com/ases/xdfj/26d613929f374627aac0bf5d64ff2989?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927767&Signature=JQvIRJESyGTs4S4og0YnuRsfsW4%3D
http://oss.suning.com/ases/xdfj/53e030640d3244159d29abd5768079a3?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1891927769&Signature=bttry23lJW%2BjrOn81XSR2NwIzGs%3D
http://oss.suning.com/ases/tmdelay/912d12451a784b588a95b81e5af0b49a?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892009973&Signature=oRktcMARfOEghmX7M3JwZuOg7bQ%3D
http://oss.suning.com/ases/tmdelay/af652a924c5749fb8822f3fa1b3d694a?SDOSSAccessKeyId=4K0T3872HOW7DC2Z&Expires=1892009976&Signature=YqXaxJo%2Bvbdg8AJCVwoLoRJ1R90%3D
";
        }
    }
}
