using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SnmpUtil
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs senderArgs)
            {
                try
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    string name = new AssemblyName(executingAssembly.FullName).Name;
                    string str = new AssemblyName(senderArgs.Name).Name;
                    if (str.Equals("SnmpSharpNet"))
                        return Assembly.Load(Resource.SnmpSharpNet);
                }
                catch (Exception)
                {
                }
                return null;
            };

            Application.Run(new MainForm());
        }
    }
}
