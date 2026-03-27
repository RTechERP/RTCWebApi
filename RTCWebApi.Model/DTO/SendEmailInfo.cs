using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class SendEmailInfo
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailTo { get; set; }
        public List<string> EmailCC { get; set; }
    }
}
