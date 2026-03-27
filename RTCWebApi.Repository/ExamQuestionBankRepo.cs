using RTCWebApi.Model.Common;
using RTCWebApi.Model.DTO;
using RTCWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Repository
{
    public class ExamQuestionBankRepo:GenericRepo<ExamQuestionBank>
    {
        public List<ExamQuestionDTO> GetExamQuestion(int ExamListTestID)
        {
            List<ExamQuestionDTO> list = new List<ExamQuestionDTO>();
            DataTable dt = TextUtils.GetDataTableSP("spGetQuestionOfExam", new string[] { "@ExamListTestID" }, new object[] { ExamListTestID });
            if (dt.Rows.Count > 0)
            {
                list = TextUtils.ConvertDataTable<ExamQuestionDTO>(dt);
            }

            return list;
        }
    }
}
