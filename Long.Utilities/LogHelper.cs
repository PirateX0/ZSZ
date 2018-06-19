using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities
{
    public static class LogHelper
    {
        public static void AddLog()
        {
            log4net.Config.XmlConfigurator.Configure();

            ILog logger = LogManager.GetLogger(typeof(LogHelper));
            logger.Debug("aaaaaaaaaaaaaa");
            logger.Error("aaaaaaaaaaaaaa");
        }
    }
}
