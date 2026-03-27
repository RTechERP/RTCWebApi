using RTCWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class ExamQuestionBankDTO
    {
        public int Id { get; set; }
        public string CodeTest { get; set; }
        public string NameTest { get; set; }
        public int? TestTime { get; set; }
        public IEnumerable<ExamQuestionBank> ExamQuestionBank { get; set; }
    }
}
