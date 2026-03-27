using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamQuestionListTest
    {
        public int Id { get; set; }
        public int? ExamQuestionId { get; set; }
        public int? ExamListTestId { get; set; }
        public int? Stt { get; set; }
    }
}
