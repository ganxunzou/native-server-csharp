using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeServer.socket.co;
using NativeServer.socket;
using NativeServer.socket.constant;
using NativeServer.exception;
using Newtonsoft.Json;

namespace NativeServer.socket.utils
{
    public class CommunicateUtils
    {
        private const string PREFIX = "$$$$";

        private const string SUFFIX = "####";

        /// <summary>
        /// 字符串转CommunicateVo 对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<CommunicateVO> strToCommunicateVos(string data)
        {
            List<CommunicateVO> list = new List<CommunicateVO>();
            try
            {
                while (data.IndexOf(PREFIX) >= 0 && data.IndexOf(SUFFIX) >= 0) 
                {
                    int startIndex = data.IndexOf(PREFIX);
                    int endIndex = data.IndexOf(SUFFIX);
                    int length = endIndex - (startIndex + PREFIX.Length);

                    string result = data.Substring(startIndex + PREFIX.Length, length);

                    int cmType = checkCMType(result);

                    if ((int)CMType.CallExe == (cmType))
                    {
                        list.Add(JsonConvert.DeserializeObject<CallExeCo>(result));
                    }
                    else if ((int)CMType.DownloadFile == (cmType))
                    {
                        list.Add(JsonConvert.DeserializeObject<DownloadFileCo>(result));
                    }
                    else if ((int)CMType.OpenFile == (cmType))
                    {
                        list.Add(JsonConvert.DeserializeObject<OpenFileCo>(result));
                    }
                    else if ((int)CMType.SayHello == cmType)
                    {
                        list.Add(JsonConvert.DeserializeObject<SayHelloCo>(result));
                    }
                    else
                    {
                        throw new CMTypeNotFoundException("没有找到对应的通讯类型(CMType),当前值：" + cmType);
                    }

                    data = data.Remove(startIndex, endIndex + SUFFIX.Length - startIndex);
                }
            }
            catch (Exception ex)
            {
                // TODO: 后续做日志
                throw ex;
            }

            return list;
        }

        /// <summary>
        /// 根据通讯字符串，判断通讯类型（CMType）
        /// TODO： 这个函数不是很健壮，cmType类型超过9以后需要调整。
        /// 调整方案：先用JSON序列化成 CommunicateVo对象，然后在判断。考虑到通讯频繁的情况重复序列化可能导致性能影响
        /// 暂时使用此方案。后续在优化。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int checkCMType(string str)
        {
            int i = str.ToLower().IndexOf("cmtype");

            int cmType = int.Parse(str.Substring(i + 8, 1));

            return cmType;
        }

        /// <summary>
        /// CommunivateVo 转 通讯字符串
        /// </summary>
        /// <param name="co"></param>
        /// <returns></returns>
        public static string communicateVoToStr(CommunicateVO co)
        {
            string str = JsonConvert.SerializeObject(co);
            return PREFIX + str + SUFFIX;
        }
    }
}
