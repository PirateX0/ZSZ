using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities
{
    [Obsolete]
    public class RuPengSMSModel
    {
        public string UserName { get; set; }
        public string AppKey { get; set; }
        public string TemplateId { get; set; }
        public string Code { get; set; }
        public string PhoneNum { get; set; }
    }
}
