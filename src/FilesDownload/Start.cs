using FilesDownload.Infrastructure;
using FilesDownload.Model;
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
        private ConfigInfo _config;
        private int _next = 0;

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

            try
            {
                if (btnDonwload.Text == "下载")
                {
                    btnDonwload.Text = "停止下载";
                }
                else
                {
                    btnDonwload.Text = "下载";
                    timerStatus.Enabled = false;
                    timerDownload.Enabled = false;
                    LogInfo("中途停止下载，暂无法进行统计计算");
                    return;
                }

                _config = LoadConfig();
                LogInfo($"已读取配置信息：{_config.Info()}");


                var urls = _config.GetUrls();
                if (urls.Length == 0)
                {
                    LogInfo("未识别到有效链接，终止下载");
                    timerDownload.Enabled = false;
                    timerStatus.Enabled = false;
                    return;
                }
                LogInfo($"已识别有效格式链接 {urls.Length} 个");

                timerDownload.Interval = _config.GetTimeInterval();

                _next = _config.GetTimeInterval() / 1000;
                _next = _next - 1;
                _next = _next < 0 ? 0 : _next;

                timerStatus.Enabled = true;
                timerDownload.Enabled = true;
                timerDownload.Start();
            }
            catch (Exception ex)
            {
                LogInfo($"读取配置有误,{ex.Message}");
            }
        }
        /// <summary>
        /// 执行下载业务
        /// </summary>
        private void DoDownload(string[] urls)
        {
            try
            {
                LogInfo($"【启动下载】 【{urls.Length}个文件】");

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
                throw ex;
            }
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择存放网络地址的储存文件";
            dialog.Filter = "文本文件|*.txt|所有文件|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
                {
                    txtUrls.Text = reader.ReadToEnd();
                    LogInfo($"已读取文件：{filename}");
                }
            }
        }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        private ConfigInfo LoadConfig()
        {
            var config = new ConfigInfo(txtTimeInterval.Text.Trim(),
                                        txtDownNum.Text.Trim());
            config.IsCircle = rCircle.Checked ? true : false;
            config.SetUrls(txtUrls.Text.Trim());
            return config;
        }

        private void timerDownload_Tick(object sender, EventArgs e)
        {
            timerDownload.Enabled = false;
           
            timerStatus.Enabled = false;
            lbStatus.Text = "下载执行中";

            try
            {
                var urls = _config.GetUrls();
                if (urls == null) return;

                var tempUrls = new string[_config.GetDownloadNum()];
                for (int i = 0; i < tempUrls.Length; i++)
                {
                    var url = urls[i];
                    tempUrls[i] = url;
                }
                DoDownload(tempUrls);
            }
            catch (Exception ex)
            {
                LogInfo($"下载失败：{ex.Message}");
            }
            finally
            {
                _next = _config.GetTimeInterval()/1000;
                _next = _next - 1;
                _next = _next < 0 ? 0 : _next;

                timerStatus.Enabled = true;
                timerDownload.Enabled = true;
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lbStatus.Text = $"距离下次下载还剩：{_next--}秒";
        }
    }
}
