using Microsoft.AspNetCore.Mvc;
using RTCWeb.Common;
using RTCWebApi.Model.Common;
using RTCWebApi.Model.DTO;
using RTCWebApi.Model.Entities;
using RTCWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RTCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamNewController : ControllerBase
    {
        private ExamResultRepo erRepo = new();
        private ExamResultDetailRepo erdRepo = new();
        private ExamResultAnswerDetailRepo eradRepo = new();

        // Tạo đề
        [HttpPost("tests")]
        public async Task<IActionResult> Tests([FromForm] int YearValue, [FromForm] int Season, [FromForm] int TestType,
            [FromForm] int EmployeeID, [FromForm] string LoginName)
        {
            int rollbackExamID = 0;
            try
            {
                DataRow existingExamResult = null;
                DataTable dt = TextUtils.GetDataTableSP("spCheckExamResultStatus",
                            new string[] { "@YearValue", "@Season", "@TestType", "@EmployeeID" },
                            new object[] { YearValue, Season, TestType, EmployeeID });
                existingExamResult = dt.Rows[0];

                var existed = TextUtils.ToBoolean(existingExamResult["existed"]);
                var total = TextUtils.ToInt(existingExamResult["total"]);               // tổng số lượng câu hỏi
                var duration = TextUtils.ToDecimal(existingExamResult["duration"]);     // tổng thời gian đề thi

                if (existed)
                {
                    return Ok(new
                    {
                        Status = 0,
                        Message = "Bạn đã làm bài thi này.",
                    });
                }
                else
                {
                    ExamResult newExam = new()
                    {
                        YearValue = YearValue,
                        Season = Season,
                        TestType = TestType,
                        EmployeeId = EmployeeID,
                        CreatedBy = LoginName,
                        CreatedDate = DateTime.Now
                    };
                    await erRepo.CreateAsync(newExam);
                    rollbackExamID = newExam.Id;

                    var newQuestions = SQLHelper<ExamResultDetail>.ProcedureToList("spCreateExamQuestions",
                            new string[] { "@ExamResultID", "@LoginName" },
                            new object[] { newExam.Id, LoginName })
                        ?? throw new Exception();
                    List<ExamResultAnswerDetail> answers = new();
                    foreach (var question in newQuestions)
                    {
                        var newAnswers = SQLHelper<ExamResultAnswerDetail>.ProcedureToList("spCreateExamAnswers",
                            new string[] { "@ExamResultDetailID", "@CourseQuestionID", "@LoginName" },
                            new object[] { question.Id, question.CourseQuestionId, LoginName });
                        answers.AddRange(newAnswers);
                    }
                    return Ok(new
                    {
                        Status = 1,
                        Message = $"Bài thi có {total} câu, thời lượng {duration} phút.",
                        Data = new
                        {
                            examID = newExam.Id,
                            total,
                            duration
                        }

                    });
                }
            }
            catch (Exception ex)
            {
                erRepo.Delete(rollbackExamID);
                return StatusCode(500, new
                {
                    Status = 0,
                    ex.Message
                });
            }
        }

        // Lấy dữ liệu đề thi
        [HttpGet("tests")]
        public IActionResult Tests(int YearValue, int Season, int TestType, int EmployeeID)
        {
            try
            {
                var content = SQLHelper<ExamContentDTO>.ProcedureToList("spGetExamTestContent",
                    new string[] { "@YearValue", "@Season", "@TestType", "@EmployeeID" },
                    new object[] { YearValue, Season, TestType, EmployeeID });

                if (content == null)
                {
                    return BadRequest(new
                    {
                        Status = 0,
                        Message = "Lấy dữ liệu đề thi thất bại!",
                        //Data = content
                    });
                }

                return Ok(new
                {
                    Status = 1,
                    Message = "Lấy dữ liệu đề thi thành công",
                    Data = content
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    ex.Message
                });
            }
        }

        // update câu hỏi
        [HttpPost("answers")]
        public async Task<IActionResult> Answers([FromBody] List<ExamContentDTO> answers)
        {
            try
            {
                foreach (var answer in answers)
                {
                    var ans = eradRepo.GetByID(answer.ID) ?? throw new Exception("Câu trả lời đã bị xóa?");
                    ans.IsPicked = answer.IsPicked;
                    ans.UpdatedBy = answer.CreatedBy;
                    ans.UpdatedDate = DateTime.Now;
                    await eradRepo.UpdateAsync(ans);
                }
                return Ok(new
                {
                    Status = 1,
                    Message = "Lưu câu trả lời thành công"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    ex.Message
                });
            }
        }

        // Hoàn thành bài thi
        [HttpPost("result")]
        public IActionResult Result([FromForm] int Id, [FromForm] string LoginName, [FromForm] int EmployeeID)
        {
            try
            {
                var exam = erRepo.GetByID(Id);
                if (exam == null || exam.EmployeeId != EmployeeID) throw new Exception("Đã có lỗi xảy ra.");
                DataRow result = null;
                DataTable dt = TextUtils.GetDataTableSP("spCalculateExamConclusion",
                    new string[] { "@ExamID", "@LoginName" },
                    new object[] { Id, LoginName });
                result = dt.Rows[0];
                //var TotalQuestion = TextUtils.ToInt(result["TotalQuestion"]);
                //var TotalChoosen = TextUtils.ToInt(result["TotalChoosen"]);
                //var TotalCorrect = TextUtils.ToInt(result["TotalCorrect"]);
                //var TotalInCorrect = TextUtils.ToInt(result["TotalInCorrect"]);
                //var TotalMarks = TextUtils.ToDecimal(result["TotalMarks"]);

                return Ok(new
                {
                    Status = 1,
                    Message = "Bài thi hoàn thành",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    ex.Message
                });
            }
        }

        // Trả kết quả thi
        [HttpGet("result")]
        public IActionResult Result(int Id)
        {
            try
            {
                var exam = erRepo.GetByID(Id);
                return Ok(new
                {
                    Status = 1,
                    Message = "Lấy kết quả thi thành công",
                    Data = exam
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 0,
                    ex.Message
                });
            }
        }

        private T ToObject<T>(DataRow dataRow) where T : new()  //unused, can remove
        {
            T item = new();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                if (dataRow[column] != DBNull.Value)
                {
                    PropertyInfo prop = item.GetType().GetProperty(column.ColumnName);
                    if (prop != null)
                    {
                        object result = Convert.ChangeType(dataRow[column], prop.PropertyType);
                        prop.SetValue(item, result, null);
                        continue;
                    }
                    else
                    {
                        FieldInfo fld = item.GetType().GetField(column.ColumnName);
                        if (fld != null)
                        {
                            object result = Convert.ChangeType(dataRow[column], fld.FieldType);
                            fld.SetValue(item, result);
                        }
                    }
                }
            }
            return item;
        }
    }
}