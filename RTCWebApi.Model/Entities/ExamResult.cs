using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamResult
    {
        public int Id { get; set; }
        public int? YearValue { get; set; }
        public int? Season { get; set; }
        public int? TestType { get; set; }
        public int? EmployeeId { get; set; }
        public int? TotalQuestion { get; set; }
        public int? TotalChoosen { get; set; }
        public int? TotalCorrect { get; set; }
        public int? TotalInCorrect { get; set; }
        public decimal? TotalMarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
