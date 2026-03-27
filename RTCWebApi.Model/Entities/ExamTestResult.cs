using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamTestResult
    {
        public int Id { get; set; }
        public int? ExamCategoryId { get; set; }
        public int? ExamListTestId { get; set; }
        public int? ExamQuestionBankId { get; set; }
        public int? EmployeeId { get; set; }
        public string CandidateName { get; set; }
        public string ResultChose { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
