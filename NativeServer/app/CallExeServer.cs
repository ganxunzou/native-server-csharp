using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using NativeServer.handler;

namespace NativeServer.app
{
    /// <summary>
    /// 调用Exe 服务
    /// </summary>
    public class CallExeServer
    {
        private CallExeOutputHandler outputHandler;
        private CallExeErrorHandler errorHandler;
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

        private void processOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(outputHandler != null)
                outputHandler(e.Data);  
        }

        private void processErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (errorHandler != null)
                errorHandler(e.Data);
        }

        private void processExited(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
            if (exitHandler != null)
                exitHandler(((Process)sender).ExitCode);
        }

        private ProcessStartInfo getProcessStartInfo(string exePath, string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = getWorkDerectory(exePath);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.FileName = exePath;
            const string argsSeparator = " ";
            string argsStr = string.Join(argsSeparator, args);
            psi.Arguments = argsStr; // 参数不支持数组，直接用空格分隔符处理

            return psi;
        }

        private string getWorkDerectory(string exePath)
        {
            FileInfo fi = new FileInfo(exePath);
            return fi.Directory.FullName;
        }
    }
}
