using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamQuestionBank
    {
        public int Id { get; set; }
        public int? ExamListTestId { get; set; }
        public int? ExamQuestionTypeId { get; set; }
        public int? Stt { get; set; }
        public string ContentTest { get; set; }
        public string CorrectAnswer { get; set; }
        public string Image { get; set; }
        public int? Score { get; set; }
    }
}
