using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsForms.Stock.GPService
{
    public class LogTool
    {

        public static void TempWriteLog(string name, string gPDesc)
        {

            WriteLog(name, gPDesc);
            //logTempDatas.Add(new LogTempData() { GPName = name, Content = gPDesc });

            //if (logTempDatas.Count >= Length)
            //{

            //    var tempLogs = logTempDatas;
            //    var result = (from x in tempLogs.FindAll(t => t != null)
            //                  group x by x.GPName into g
            //                  select new
            //                  {
            //                      g.Key,
            //                      Items = logTempDatas.FindAll(t => t.GPName == g.Key)
            //                  }).ToList(); ;
            //    //写入Logs里
            //    foreach (var item in result)
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        foreach (var subItem in item.Items)
            //        {
            //            sb.AppendLine(DateTime.Now.ToString() + ":" + subItem.Content);
            //        }

            //        WriteLog(item.Key, sb.ToString());
            //    }

            //    logTempDatas.Clear();
            //}
        }


        private static Object lockObj = new object();
        #region MyRegion
        public static void WriteLog(string GPName, string Content, bool AddFirstData = false)
        {
            GPName = GPName.Replace("*", "");
            string FileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + GPName + ".txt";
            string Path = "D:\\研究性代码\\LifeFly\\GP\\Logs\\" + FileName;
            lock (lockObj)
            {
                if (!File.Exists(Path))
                {
                    File.Create(Path).Close(); ;
                }
                FileStream fs = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Content + "\n");
                sr.Close();
                fs.Close();
            }

        }
        #endregion
    }
}
