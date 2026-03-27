using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class ExamQuestionDTO
    {
        public int ID { get; set; }
        public int STT { get; set; }
        public string ContentTest { get; set; }
        public string CorrectAnswer { get; set; }
        public string Image { get; set; }
        public int? Score { get; set; }
        public int? ExamListTestID { get; set; }
        public int ExamCategoryID { get; set; }
    }
}
