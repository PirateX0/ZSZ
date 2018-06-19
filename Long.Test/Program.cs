using Autofac;
using Long.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBllImpl;
using MyIBLL;
using System.Reflection;
using ZSZ.Common;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Security;
using ZSZ.Service;
using System.Data;
using System.Collections;

namespace Long.Test
{
    class TestType
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Helper.GenerateCaptchaCode(4));
            //SmtpHelper.SendEmail();
            //ImgHelper.GenerateProcessedImage();
            //ImgHelper.GenerateWatermark();
            //ImgHelper.GenerateCaptchaCodeImage();
            //LogHelper.AddLog();
            //QuartzHelper.ScheduleByDate();
            QuartzHelper.ScheduleByInterval();

            //Type type = Type.GetType("Long.Utilities.TestJob");
            //Console.WriteLine(type.Name);

            #region autoFac
            //MyIBLL.IDogBll dog = new MyBllImpl.DogBll();

            //ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<DogBll>().As<IDogBll>();//注册实现类Service1，当请求IService1接口的时候返回Service1的对象。原理代码，很少写
            //IContainer resolver = builder.Build();
            //IDogBll dog = resolver.Resolve<IDogBll>();

            //Assembly asm = Assembly.Load("MyBllImpl");
            //builder.RegisterAssemblyTypes(asm).AsImplementedInterfaces().PropertiesAutowired();//这是最常用的用法！
            //IContainer resolver = builder.Build();

            ////IDogBll dog = resolver.Resolve<IDogBll>();
            ////dog.Bark();
            ////ISchool school = resolver.Resolve<ISchool>();
            ////school.FangXue();

            //IEnumerable<IUserBll> userBlls = resolver.Resolve<IEnumerable<IUserBll>>();
            //foreach (var bll in userBlls)
            //{
            //    Console.WriteLine(bll.GetType());
            //    bll.AddNew("dalong","123");
            //} 
            #endregion

            #region sms
            //string userName = "rupengtest1";
            //string appKey = "fdsafasdf@adfasdfa";
            //string templateId = "183";
            //string code = "6666";
            //string phoneNum = "18918918189";
            ///*
            //            WebClient wc = new WebClient();
            //            string url = "http://sms.rupeng.cn/SendSms.ashx?userName=" +
            //                Uri.EscapeDataString(userName) + "&appKey=" + Uri.EscapeDataString(appKey) +
            //                "&templateId=" + templateId + "&code=" + Uri.EscapeDataString(code) +
            //                "&phoneNum=" + phoneNum;
            //            wc.Encoding = Encoding.UTF8;
            //            string resp = wc.DownloadString(url);
            //            //发出url这样一个http请求（Get请求）返回值为响应报文体
            //            Console.WriteLine(resp);
            //            */
            //RuPengSMSSender sender = new RuPengSMSSender();
            //sender.AppKey = appKey;
            //sender.UserName = userName;
            //var result = sender.SendSMS(templateId, code, phoneNum);
            //Console.WriteLine("返回码：" + result.code + ",消息：" + result.msg); 
            #endregion

            #region remote powershell

            //WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
            //connectionInfo.ComputerName = "BJLE0005";
            //var pwd = ConvertStringToSecureString("m3diaR00mT3stPl@tform");
            //connectionInfo.Credential = new PSCredential(@"MR.ERICSSON.SE\mtpbot", pwd);

            //connectionInfo.OperationTimeout = 4 * 60 * 1000; // 4 minutes.
            //connectionInfo.OpenTimeout = 1 * 60 * 1000; // 1 minute.


            //using (Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo))
            //{
            //    remoteRunspace.Open();

            //    // Create a PowerShell object to run commands in the remote runspace.
            //    using (PowerShell powershell = PowerShell.Create())
            //    {
            //        powershell.Runspace = remoteRunspace;
            //        powershell.AddCommand(@"C:\Users\mtpbot\Desktop\test.bat");
            //        powershell.Invoke();

            //        Collection<PSObject> results = powershell.Invoke();

            //        Console.WriteLine("--------------------------------");
            //        Console.WriteLine("result count:" + results.Count);

            //        for (int i = 0; i < results.Count; i++)
            //        {
            //            Console.WriteLine(
            //                              "{0}:{1}",
            //                              i,
            //                              results[i].ToString()
            //                              );
            //        }
            //    }

            //    remoteRunspace.Close();
            //}
            #endregion

            #region buildService
            //string sql = "select * from T_Tasks";
            //DataTable dataTable= sqlHelper.executeDataTable(sql);
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    Console.WriteLine(dataRow["Status"].ToString()+dataRow["ScriptPath"]);
            //}


            //using (Runspace runspace = RunspaceFactory.CreateRunspace())
            //{
            //    runspace.Open();
            //    // Create a PowerShell object to run commands in the remote runspace.
            //    using (PowerShell powershell = PowerShell.Create())
            //    {
            //        powershell.Runspace = runspace;
            //        powershell.AddCommand(@"C:\Users\banana\Desktop\getProcessId.ps1");

            //        Collection<PSObject> results = powershell.Invoke();

            //        Console.WriteLine("--------------------------------");
            //        Console.WriteLine("result count:" + results.Count);

            //        for (int i = 0; i < results.Count; i++)
            //        {
            //            Console.WriteLine(
            //                              "{0}:{1}",
            //                              i,
            //                              results[i].ToString()
            //                              );
            //        }

            //        powershell.AddCommand(@"C:\Users\banana\Desktop\fakeBuild.ps1");
            //        Collection<PSObject> results2 = powershell.Invoke();

            //        Console.WriteLine("--------------------------------");
            //        Console.WriteLine("result2 count:" + results.Count);

            //        for (int i = 0; i < results2.Count; i++)
            //        {
            //            Console.WriteLine(
            //                              "{0}:{1}",
            //                              i,
            //                              results2[i].ToString()
            //                              );
            //        }
            //    }

            //    runspace.Close();
            //} 


            #endregion

            #region hashtable & dictionary
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("name", "dalong");
            //Console.WriteLine(hashtable["name"]);

            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            //keyValuePairs.Add("name", "dalong");
            //keyValuePairs.Add("age", "18");
            //Console.WriteLine(keyValuePairs["name"]);
            //Console.WriteLine("==========");
            //foreach (var keyValuePair in keyValuePairs)
            //{
            //    Console.WriteLine(keyValuePair.Key);
            //    Console.WriteLine(keyValuePair.Value);
            //    Console.WriteLine("==========");
            //} 
            #endregion

            #region create database
            //using (ZSZDbContext ctx = new ZSZDbContext())
            //{
            //    ctx.Database.Delete();
            //    ctx.Database.Create();
            //}

            //Console.WriteLine("ok");
            //Console.ReadKey(); 
            #endregion

            #region test string
            //string s1 = @"Q0hBSQAAAAEAAAOYAAAAAAAAAAJDRVJUAAAAAQAAAdQAAAFEAAEAAQAAAFjfKx1WiER0GrUujTkjRlDxAAAAAAAAAAAAAAALn6YKmr + a6v6i9 + DWqVp1NTCPIEihik9ElCZJgHoROCtZ + Q6AAAAAAAAAAAAAAAAAAAAAAAABAA8AAAAMAAAALQABAAUAAAAQAAAAAQAAAAwAAQAGAAAAYAAAAAEAAQIAAAAAAGi6nYeCxE6Dt7l4gpCVGAJgcvintfuroE6UheXZ4RvBdunFEVqVjqBr + UYPiw0xumWoFq1mq9edl0sNAW / GAvUAAAACAAAAAQAAABQAAAAHAAAAYAAAAAAAAAAWTWljcm9zb2Z0IENvcnBvcmF0aW9uAAAAAAAAKFBsYXlSZWFkeSBTZXJ2ZXIgRGVwbG95bWVudCBDZXJ0aWZpY2F0ZQAAAAAGNDEyMjAAAAAAAQAIAAAAkAABAED + FQlCTEM2m9yNAVIxft3p99LOjTAOv4PwmpTasJlPpsEeQ7nh / jI9Zyt5W4dkqmGNcB6JMqTLYtxWtu8QI / sXAAACAM0d13P6iIdFkoybUizDzLm5QfInUr + PNNpZTi9EoyFFde1HWSvvOyYxDOF8tSuCj4leP4Mn83XJm8MLDEZ8RiZDRVJUAAAAAQAAAbAAAAEgAAEAAQAAAFiaCgs2MrtFMaNrM41ZkfRvAAAAAAAAAAAAAAAE9ohU9a1KaJyI9bUwqwaVxBOo7R4xS + gG8Hv0ESdBtnz/////AAAAAAAAAAAAAAAAAAAAAAABAAUAAAAMAAAAAAABAAYAAABgAAAAAQABAgAAAAAAzR3Xc/qIh0WSjJtSLMPMublB8idSv4802llOL0SjIUV17UdZK+87JjEM4Xy1K4KPiV4/gyfzdcmbwwsMRnxGJgAAAAIAAAABAAAADwAAAAcAAABMAAAAAAAAAApNaWNyb3NvZnQAAAAAAAAdUGxheVJlYWR5IFNMMCBTZXJ2ZXIgUm9vdCBDQQAAAAAAAAAIMS4wLjAuMQAAAQAIAAAAkAABAEA6OPlVasx9gd4f7dnZoS2EoWubrKGikufmx2HD30bycFu5p31Yw69YLVkeSVF2GEO1/TtRL9juw0D2wEtCl9/zAAACAIZNYc/yJW5CLFaLPCgAHPs+FSdlhYS6BSG3mxgo2TbeHYJqj8Pm5/p6kNXKKUbx9kou+59dz/5+Q060QpP6xas=";
            //string s2 = @"Q0hBSQAAAAEAAAOMAAAAAAAAAAJDRVJUAAAAAQAAAcgAAAE4AAEAAQAAAFjMd71m2PXNXNKBMAo8cLXFAAAAAAAAAAAAAAALElFY0UIHFc/ewUEGwPnB11uL6iskd798dOTqvuSUuLZbvUEAAAAAAAAAAAAAAAAAAAAAAAABAA8AAAAMAAAALQABAAUAAAAQAAAAAQAAAAwAAQAGAAAAYAAAAAEAAQIAAAAAAH8mfJr0kLcyHl/IHP/6d+cDYtk5ILNEd7++HE0bPVTHRi8TBf5ASOroIBLkg0U6nhr3wQRqtD+VK4F/hKHs+8sAAAACAAAAAQAAABQAAAAHAAAAVAAAAAAAAAAMRXJpY3Nzb24gQUIAAAAAKFBsYXlSZWFkeSBTZXJ2ZXIgRGVwbG95bWVudCBDZXJ0aWZpY2F0ZQAAAAAGNDI1MjkAAAAAAQAIAAAAkAABAEDi7hDO8SqFoHpdyW3lX6+MkG6W3S95iqliZuCHksZEWMd8y1eCL3E4BloGEADYScavlh2a9qF0XoWavN818kokAAACAM0d13P6iIdFkoybUizDzLm5QfInUr+PNNpZTi9EoyFFde1HWSvvOyYxDOF8tSuCj4leP4Mn83XJm8MLDEZ8RiZDRVJUAAAAAQAAAbAAAAEgAAEAAQAAAFiaCgs2MrtFMaNrM41ZkfRvAAAAAAAAAAAAAAAE9ohU9a1KaJyI9bUwqwaVxBOo7R4xS+gG8Hv0ESdBtnz/////AAAAAAAAAAAAAAAAAAAAAAABAAUAAAAMAAAAAAABAAYAAABgAAAAAQABAgAAAAAAzR3Xc/qIh0WSjJtSLMPMublB8idSv4802llOL0SjIUV17UdZK+87JjEM4Xy1K4KPiV4/gyfzdcmbwwsMRnxGJgAAAAIAAAABAAAADwAAAAcAAABMAAAAAAAAAApNaWNyb3NvZnQAAAAAAAAdUGxheVJlYWR5IFNMMCBTZXJ2ZXIgUm9vdCBDQQAAAAAAAAAIMS4wLjAuMQAAAQAIAAAAkAABAEA6OPlVasx9gd4f7dnZoS2EoWubrKGikufmx2HD30bycFu5p31Yw69YLVkeSVF2GEO1/TtRL9juw0D2wEtCl9/zAAACAIZNYc/yJW5CLFaLPCgAHPs+FSdlhYS6BSG3mxgo2TbeHYJqj8Pm5/p6kNXKKUbx9kou+59dz/5+Q060QpP6xas=";
            //Console.WriteLine(s1==s2); 
            #endregion

            //string dT = DateTime.Now.ToFileTimeUtc().ToString();
            //Console.WriteLine(dT);
            //string dT2 = DateTime.Now.ToFileTimeUtc().ToString();
            //Console.WriteLine(dT2);
            //Console.WriteLine(dT.Length);
            //string guid= Guid.NewGuid().ToString();
            //Console.WriteLine(guid);
            //Console.WriteLine(guid.Length);

            //char[] data = { 'a','c','d','e','f','h','k','m',
            //    'n','r','s','t','w','x','y'};
            //StringBuilder sb = new StringBuilder();
            //Random rand = new Random();
            //for (int i = 0; i < 2000; i++)
            //{

            //    int index = rand.Next(data.Length);//[0,data.length)
            //    char ch = data[index];
            //    sb.Append(ch);
            //}
            //Console.WriteLine(sb.ToString());

            Console.WriteLine("ok");
            Console.ReadKey();
        }

        public static void InvokeSystemPS(string cmd)
        {
            List<string> ps = new List<string>();
            ps.Add("Set-ExecutionPolicy RemoteSigned");
            ps.Add("Set-ExecutionPolicy -ExecutionPolicy Unrestricted");
            ps.Add("& " + cmd);
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in ps)
            {
                pipeline.Commands.AddScript(scr);
            }
            pipeline.Invoke();//Execute the ps script
            runspace.Close();
        }

        public static SecureString ConvertStringToSecureString(string str)
        {
            var pwd = new SecureString();
            foreach (var strChar in str)
            {
                pwd.AppendChar(strChar);
            }
            return pwd;
        }
    }

}
