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
    public class ExamTestResultRepo:GenericRepo<ExamTestResult>
    {

        DataSet dataSet = new DataSet();
        //Kiểm tra tồn tại ExamTestResult
        public int CheckExistExamTest(ExamTestResult examTestResult)
        {
            int result = 0;
            DataTable dt = TextUtils.GetDataTableSP("spCheckExistExamTestResult",
                        new string[] { "@ExamQuestionBankID", "@EmployeeID", "@ExamCategoryID", "@ExamListTestID" },
                        new object[] { examTestResult.ExamQuestionBankId, examTestResult.EmployeeId, examTestResult.ExamCategoryId, examTestResult.ExamListTestId});

            if (dt.Rows.Count > 0)
            {
                result = TextUtils.ToInt(dt.Rows[0]["ID"]);
            }
            return result;
        }

        public int CheckExistExamTestResult(string examCateCode, int employeeId)
        {
            dataSet = TextUtils.GetDataSetSP("spGetExamTestResult", new string[] { "@ExamCategoryCode", "@EmployeeID" }, new object[] { examCateCode, employeeId });
            return TextUtils.ToInt(dataSet.Tables[0].Rows[0]["StatusCode"]);
        }

        //Get danh sách kết quả test và check kết quả
        public List<ExamTestResultDTO> GetExamTestResult(string examCateCode, int employeeId)
        {
            List<ExamTestResultDTO> list = new List<ExamTestResultDTO>();

            DataTable dt = TextUtils.GetDataSetSP("spGetExamTestResult", new string[] { "@ExamCategoryCode", "@EmployeeID" }, new object[] { examCateCode, employeeId }).Tables[1];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ExamTestResultDTO testResult = new ExamTestResultDTO();
                    testResult.Id = TextUtils.ToInt(dt.Rows[i]["ID"]);
                    testResult.CodeTest = TextUtils.ToString(dt.Rows[i]["CodeTest"]);
                    testResult.NameTest = TextUtils.ToString(dt.Rows[i]["NameTest"]);
                    testResult.ContentTest = TextUtils.ToString(dt.Rows[i]["ContentTest"]);
                    testResult.EmployeeName = TextUtils.ToString(dt.Rows[i]["FullName"]);
                    testResult.CandidateName = TextUtils.ToString(dt.Rows[i]["CandidateName"]);
                    testResult.ResultChose = TextUtils.ToString(dt.Rows[i]["ResultChose"]);
                    testResult.Result = TextUtils.ToBoolean(dt.Rows[i]["Result"]);

                    list.Add(testResult);
                }
            }

            return list;
        }
    }
}
