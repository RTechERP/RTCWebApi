using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class ExamTestResultDTO
    {
        public int Id { get; set; }
        public string CodeTest { get; set; }
        public string NameTest { get; set; }
        public string ContentTest { get; set; }
        public string EmployeeName { get; set; }
        public string CandidateName { get; set; }
        public string ResultChose { get; set; }
        public bool Result { get; set; }
    }
}
