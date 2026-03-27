using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTCWebApi.Model.Entities;
using RTCWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTestResultController : ControllerBase
    {
        ExamTestResultRepo testResultRepo = new ExamTestResultRepo();

        [HttpPost("updatetestresult")]
        public async Task<IActionResult> UpdateTestResult([FromBody] ExamTestResult examTestResult)
        {
            try
            {
                int idTestResult = testResultRepo.CheckExistExamTest(examTestResult);
                if (idTestResult <= 0)
                {
                    examTestResult.CreatedBy = examTestResult.UpdateBy = examTestResult.EmployeeId.ToString();
                    examTestResult.CreatedDate = examTestResult.UpdateDate = DateTime.Now;
                    //testResultRepo.Create(examTestResult);

                    await testResultRepo.CreateAsync(examTestResult);
                    return Ok(new
                    {
                        statusCode = 1,
                        message = "Thêm thành công!",
                        testResult = examTestResult
                    });
                }
                else
                {

                    ExamTestResult result = testResultRepo.GetByID(idTestResult);
                    if (result != null)
                    {
                        result.ResultChose = examTestResult.ResultChose;
                        result.UpdateDate = DateTime.Now;
                        result.UpdateBy = examTestResult.EmployeeId.ToString();

                        //testResultRepo.Update(result);
                        await testResultRepo.UpdateAsync(result);
                        return Ok(new
                        {
                            statusCode = 1,
                            message = "Cập nhập thành công!",
                            testResult = examTestResult
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            statusCode = 0,
                            message = $"Cập nhật thất bại!"
                        });
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    statusCode = 0,
                    message = $"Cập nhật thất bại ({ex.Message})"
                });
            }
        }

        [HttpGet("checktestresult")]
        public IActionResult CheckTestResult(string examCateCode, int employeeId)
        {
            int statusCode = testResultRepo.CheckExistExamTestResult(examCateCode, employeeId);
            
            if (statusCode == 0)
            {
                return Ok(new
                {
                    StatusCode = statusCode,
                    Message = "Bạn có thể làm bài test. Xin vui lòng bấm Bắt đầu."
                }) ;
            }
            else
            {
                var list = testResultRepo.GetExamTestResult(examCateCode, employeeId);
               
                return Ok(new
                {
                    statusCode = statusCode,
                    Message = "Bạn đã làm bài test. Kết quả bài test:",
                    result = list
                });
            }
        }
    }
}
