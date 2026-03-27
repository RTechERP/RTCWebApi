using System;
using System.Collections.Generic;

#nullable disable

namespace RTCWebApi.Model.Entities
{
    public partial class ExamListTest
    {
        public int Id { get; set; }
        public int? ExamTypeTestId { get; set; }
        public int? ExamCategoryId { get; set; }
        public string CodeTest { get; set; }
        public string NameTest { get; set; }
        public string Note { get; set; }
        public int? TestTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
