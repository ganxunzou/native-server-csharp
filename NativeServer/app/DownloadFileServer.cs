using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.handler;
using System.Net;
using System.IO;
using System.ComponentModel;
using NativeServer.socket.co.cro;

namespace NativeServer.app
{
    //==============================================================
    //  作者：ganxunzou
    //  时间：2018/7/3 16:36:29
    //  说明： 文件下载服务
    //  修改者：
    //  修改说明： 
    //==============================================================
    public class DownloadFileServer
    {
        private DownloadFileHandler downloadFileHandler;
        private DownloadFileCro downloadCro = new DownloadFileCro();
        private string url;
        private string savePath;
        private WebClient wc;

        /// <summary>
        /// 执行文件下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savePath"></param>
        /// <param name="downloadFileHandler"></param>
        public void downloadFile(string url, string savePath, DownloadFileHandler downloadFileHandler)
        {
            this.downloadFileHandler = downloadFileHandler;
            this.url = url;
            this.savePath = savePath;

            try
            {
                // 创建目录
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }

                wc = new WebClient();
                wc.DownloadProgressChanged += WebClientDownloadProgressChanged;
                wc.DownloadDataCompleted += WebClientDownloadCompleted;
                wc.DownloadDataAsync(new Uri(url));
                
                // Sync 
                //byte[] bf = wc.DownloadData(new System.Uri(url));
                //ByteArrayToFile(savePath, bf);

                // DownloadFileAsync存在文件不释放问题
                // wc.DownloadFileAsync(new System.Uri(url), savePath);
            }
            catch (Exception ex)
            {
                downloadCro.IsSuccess = false;
                downloadCro.Message = ex.Message;
                downloadFileHandler?.Invoke(downloadCro);
            }
        }

        /// <summary>
        /// 将 byte[] 保存成文件
        /// </summary>
        /// <param name="_FileName"></param>
        /// <param name="_ByteArray"></param>
        private void ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            // Open file for reading
            System.IO.FileStream _FileStream =
               new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                            System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
            _FileStream.Flush();
            // close file stream
            _FileStream.Close();
        }

        /// <summary>
        /// 下载进度回到函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Progress Percentage:{0}", e.ProgressPercentage);
        }

        /// <summary>
        /// 下载完成回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                byte[] bf = e.Result;
                ByteArrayToFile(savePath, bf);

                downloadCro.IsSuccess = true;
                downloadCro.Message = "Download finished!";
            }
            catch (Exception ex)
            {
                downloadCro.IsSuccess = false;
                downloadCro.Message = "Download fail! " + ex.Message;
            }

            finally
            {
                downloadCro.LocalPath = savePath;

                downloadFileHandler?.Invoke(downloadCro);
            }
        }
    }
}
