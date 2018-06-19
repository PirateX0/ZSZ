using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace Long.TestMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildSuperlab()
        {
            #region remote powershell

            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
            connectionInfo.ComputerName = "BJLE0005";
            var pwd = ConvertStringToSecureString("m3diaR00mT3stPl@tform");
            connectionInfo.Credential = new PSCredential(@"MR.ERICSSON.SE\mtpbot", pwd);

            connectionInfo.OperationTimeout = 4 * 60 * 1000; // 4 minutes.
            connectionInfo.OpenTimeout = 1 * 60 * 1000; // 1 minute.

            PSDataCollection<PSObject> results = null;

            using (Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo))
            {
                remoteRunspace.Open();

                // Create a PowerShell object to run commands in the remote runspace.
                using (PowerShell powershell = PowerShell.Create())
                {
                    powershell.Runspace = remoteRunspace;
                    //powershell.AddCommand(@"C:\Users\mtpbot\Desktop\test.bat");
                    powershell.AddCommand(@"C:\Users\mtpbot\Desktop\test.ps1");
                    var resultYibu= powershell.BeginInvoke();
                    results = powershell.EndInvoke(resultYibu);
                    
                    //powershell.Invoke();
                    //results = powershell.Invoke();
                }

                remoteRunspace.Close();
            }
            #endregion
            return View(results);
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