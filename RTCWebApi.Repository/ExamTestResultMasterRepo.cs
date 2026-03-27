using RTCWebApi.Model.Common;
using RTCWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Repository
{
    public class ExamTestResultMasterRepo:GenericRepo<ExamTestResultMaster>
    {
        public int CheckExistExamTestResultMaster(string cateCode, int employeeId)
        {
            DataTable dt = TextUtils.GetDataTableSP("spGetExistExamTestResultMaster", new string[] { "@CateCode", "@EmployeeID" }, new object[] { cateCode, employeeId });
            return TextUtils.ToInt(dt.Rows[0]["StatusCode"]);
        }

        public int CheckInsertUpdate(int? examCateID, int? employeeId, int? listTestId)
        {
            int id = 0;
            DataTable dt = TextUtils.GetDataTableSP("spCheckInsertOrUpdateExamTestResultMaster",
                        new string[] { "@ExamCateID", "@EmployeeID", "@ListTestID" },
                        new object[] { examCateID, employeeId, listTestId });

            if (dt.Rows.Count > 0)
            {
                id = TextUtils.ToInt(dt.Rows[0]["ID"]);
            }
            return id;
        }
    }
}
