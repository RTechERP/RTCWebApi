using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamTestResultMaster
    {
        public int Id { get; set; }
        public int? ExamCategoryId { get; set; }
        public int? ExamListTestId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TotalQuestion { get; set; }
        public int? TotalChose { get; set; }
        public int? TotalCorrect { get; set; }
        public int? TotalIncorrect { get; set; }
        public decimal? TotalMarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
