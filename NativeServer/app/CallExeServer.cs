using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using NativeServer.handler;

namespace NativeServer.app
{
    //==============================================================
    //  作者：ganxunzou
    //  时间：2018/7/3 16:36:29
    //  文件名：A
    //  说明： EXE 调用服务
    //  修改者：
    //  修改说明： 
    //==============================================================
    public class CallExeServer
    {
        // exe 标准控制台输出回调
        private CallExeOutputHandler outputHandler;
        // exe 错误输出回调
        private CallExeErrorHandler errorHandler;
        // exe 退出回调
        private CallExeExitHandler exitHandler;


        /// <summary>
        /// 同步调用Exe
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="args"></param>
        public string[] syncCallExe(string exePath, string[] args)
        {
            // 返回：0: exitCode, 1: output, 2: error
            string[] ret = new string[] { "", "", ""};

            ProcessStartInfo psi = getProcessStartInfo(exePath, args);
            Process process = Process.Start(psi);


            StreamReader outputStreamReader = process.StandardOutput;
            StreamReader errStreamReader = process.StandardError;
            process.WaitForExit();// 等待程序运行结束， process.WaitForExit(2000);支持超时设置
            if (process.HasExited)
            {
                string output = outputStreamReader.ReadToEnd();
                string error = errStreamReader.ReadToEnd();

                ret[0] = process.ExitCode.ToString();
                ret[1] = output;
                ret[2] = error;
                
                Console.WriteLine("HasExited:{0}, ExitCode:{1}, outout:{2}, error:{3}", process.HasExited, process.ExitCode, output, error);
            }

            return ret;

        }

        /// <summary>
        /// 异步调用EXE
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="args"></param>
        public void asyncCallExe(string exePath, string[] args, CallExeOutputHandler outputHandler = null, CallExeExitHandler exitHandler = null, CallExeErrorHandler errorHandler = null)
        {
            this.outputHandler = outputHandler;
            this.errorHandler = errorHandler;
            this.exitHandler = exitHandler;

            ProcessStartInfo psi = getProcessStartInfo(exePath, args);
            Process process = Process.Start(psi);

            process.EnableRaisingEvents = true;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.Exited += new EventHandler(processExited);
            process.OutputDataReceived += new DataReceivedEventHandler(processOutputDataReceived);
            process.ErrorDataReceived += new DataReceivedEventHandler(processErrorDataReceived);
            
        }

        /// <summary>
        /// 异步调用 标准输出回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(outputHandler != null)
                outputHandler(e.Data);  
        }

        /// <summary>
        /// 异步调用 错误输出回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (errorHandler != null)
                errorHandler(e.Data);
        }

        /// <summary>
        /// 异步调用 程序退出回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processExited(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
            if (exitHandler != null)
                exitHandler(((Process)sender).ExitCode);
        }

        /// <summary>
        /// 获取 Process Start Info
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private ProcessStartInfo getProcessStartInfo(string exePath, string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = getWorkDerectory(exePath);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.FileName = exePath;
            const string argsSeparator = " ";
            string argsStr = string.Join(argsSeparator, args);
            psi.Arguments = argsStr; // 参数不支持数组，直接用空格分隔符处理

            return psi;
        }

        /// <summary>
        /// 获取exe对应的工作目录
        /// 规则：工作目录是exe所在的目录。
        /// </summary>
        /// <param name="exePath"></param>
        /// <returns></returns>
        private string getWorkDerectory(string exePath)
        {
            FileInfo fi = new FileInfo(exePath);
            return fi.Directory.FullName;
        }
    }
}
