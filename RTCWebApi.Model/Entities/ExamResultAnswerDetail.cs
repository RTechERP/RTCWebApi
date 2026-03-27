using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamResultAnswerDetail
    {
        public int Id { get; set; }
        public int? Stt { get; set; }
        public int? ExamResultDetailId { get; set; }
        public int? CourseQuestionId { get; set; }
        public int? CourseAnswerId { get; set; }
        public bool? IsPicked { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
