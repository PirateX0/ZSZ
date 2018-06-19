using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities
{
    public static class SmtpHelper
    {
        public static void SendEmail()
        {
            using (MailMessage mailMessage = new MailMessage())
            using (SmtpClient smtpClient = new SmtpClient("smtp.163.com"))
            {
                mailMessage.To.Add("295528322@qq.com");
                mailMessage.To.Add("3072733386@qq.com");
                mailMessage.Body = "加油！";
                mailMessage.From = new MailAddress("sky_dalong@163.com");
                mailMessage.Subject = "中午好！";
                smtpClient.Credentials = new System.Net.NetworkCredential("sky_dalong", "xsrtqpnztmbfgmws");//如果启用了“客户端授权码”，要用授权码代替密码
                smtpClient.Send(mailMessage);

            }

        }
    }
}
