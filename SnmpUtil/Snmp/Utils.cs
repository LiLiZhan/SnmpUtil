using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using SnmpSharpNet;

namespace SnmpUtil
{
    public class Utils
    {
        /// <summary>
        /// 运行后台操作
        /// </summary>
        /// <param name="backgroundWorker"></param>
        /// <param name="doWork"></param>
        /// <param name="runComplete"></param>
        public static void RunBackgroundWorker(BackgroundWorker backgroundWorker, DoWorkEventHandler doWork, RunWorkerCompletedEventHandler runComplete)
        {
            ClearEventHandler(backgroundWorker, "doWorkKey");
            ClearEventHandler(backgroundWorker, "runWorkerCompletedKey");
            backgroundWorker.WorkerReportsProgress = false;
            backgroundWorker.DoWork += doWork;
            backgroundWorker.RunWorkerCompleted += runComplete;
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 运行后台操作
        /// </summary>
        /// <param name="backgroundWorker"></param>
        /// <param name="doWork"></param>
        /// <param name="reportProgress"></param>
        /// <param name="runComplete"></param>
        public static void RunBackgroundWorker(BackgroundWorker backgroundWorker, DoWorkEventHandler doWork, ProgressChangedEventHandler reportProgress, RunWorkerCompletedEventHandler runComplete)
        {
            ClearEventHandler(backgroundWorker, "doWorkKey");
            ClearEventHandler(backgroundWorker, "progressChangedKey");
            ClearEventHandler(backgroundWorker, "runWorkerCompletedKey");
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += doWork;
            backgroundWorker.ProgressChanged += reportProgress;
            backgroundWorker.RunWorkerCompleted += runComplete;
            backgroundWorker.RunWorkerAsync();
        }

        public static void ClearEventHandler(Component obj, string eventName)
        {
            Type t = obj.GetType();
            EventHandlerList eventHandlerList = (EventHandlerList)t.InvokeMember("Events", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, obj, null);
            object key = t.InvokeMember(eventName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField, null, null, null);
            Delegate eventDelegate = eventHandlerList[key];
            if (eventDelegate != null)
            {
                foreach (Delegate invocation in eventDelegate.GetInvocationList())
                {
                    eventHandlerList.RemoveHandler(key, invocation);
                }
            }
        }

        /// <summary>
        ///  转化消息，转化时间刻度
        /// </summary>
        /// <param name="asnType"></param>
        /// <returns></returns>
        public static string ConvertTo(AsnType asnType)
        {
            Type type = asnType.GetType();
            if (type.Equals(typeof(TimeTicks)))
            {
                return ((TimeTicks)asnType).Miliseconds.ToString();
            }
            else
                return ConvertTo(asnType.ToString()).Replace(",", "_");
        }

        /// <summary>
        /// 转化消息，如果为正整数，则直接返回，负整数时将其转化为无符号数，非数字型时判断是否可以转化为汉字，是则转化，否则直接返回，主要是对硬盘容量大于一定值后出现负数以及汉字无法显示的情况
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ConvertTo(string message)
        {
            try
            {
                int dec = 0;
                if (int.TryParse(message, out dec))
                {
                    if (dec < 0)
                    {
                        byte[] bytes = BitConverter.GetBytes(dec);
                        return BitConverter.ToUInt32(bytes, 0).ToString();
                    }
                    else
                        return message;
                }
                else
                {
                    string[] strs = message.Split(' ');
                    bool isSucc = false;
                    byte[] buff = new byte[strs.Length];
                    for (int i = 0; i < strs.Length; i++)
                    {
                        byte _byte = new byte();
                        isSucc = byte.TryParse(strs[i], System.Globalization.NumberStyles.AllowHexSpecifier, null, out _byte);
                        if (isSucc)
                            buff[i] = _byte;
                        else
                            return message;
                    }
                    return Encoding.Default.GetString(buff);
                }
            }
            catch (Exception ex)
            {
            }
            return message;
        }
    }
}
