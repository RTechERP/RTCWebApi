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
    public class ExamTestResultMasterController : ControllerBase
    {
        ExamTestResultMasterRepo masterRepo = new ExamTestResultMasterRepo();

        [HttpGet("getexammaster")]
        public IActionResult GetExamMaster(string examCatCode, int employeeId)
        {
            int exist = masterRepo.CheckExistExamTestResultMaster(examCatCode, employeeId);
            string message = "Không tồn tại bản ghi nào!";

            if (exist > 0)
            {
                message = "Có tồn tại ít nhất 1 bản ghi!";
            }

            return Ok(new
            {
                StatusCode = exist,
                Message = message
            });
        }

        [HttpPost("createexammaster")]
        public async Task<IActionResult> Create([FromBody] ExamTestResultMaster resultMaster)
        {
            int statusCode = 0;
            string message = "Thêm thất bại!";

            try
            {
           
                if (ModelState.IsValid)
                {
                    int id = masterRepo.CheckInsertUpdate(resultMaster.ExamCategoryId, resultMaster.EmployeeId, resultMaster.ExamListTestId);

                    if (id <= 0)
                    {
                        resultMaster.CreatedDate = resultMaster.UpdateDate = DateTime.Now;
                        resultMaster.CreatedBy = resultMaster.UpdateBy = resultMaster.EmployeeId.ToString();
                        //masterRepo.Create(resultMaster);
                        await masterRepo.CreateAsync(resultMaster);
                        statusCode = 1;
                        message = "Thêm thành công!";
                    }
                    else
                    {
                        resultMaster.TotalMarks = (decimal)resultMaster.TotalCorrect / (decimal)resultMaster.TotalQuestion;
                        ExamTestResultMaster master = masterRepo.GetByID(id);
                        if (master != null)
                        {
                            //master.ExamCategoryId = resultMaster.ExamCategoryId;
                            //master.ExamListTestId = resultMaster.ExamListTestId;
                            //master.EmployeeId = resultMaster.EmployeeId;
                            //master.TotalQuestion = resultMaster.TotalQuestion;
                            master.TotalChose = resultMaster.TotalChose;
                            master.TotalCorrect = resultMaster.TotalCorrect;
                            master.TotalIncorrect = resultMaster.TotalIncorrect;
                            master.TotalMarks = resultMaster.TotalMarks;
                            //master.CreatedDate = resultMaster.CreatedDate;
                            //master.CreatedBy = resultMaster.CreatedBy;
                            //master.UpdateBy = resultMaster.UpdateBy;

                            master.UpdateDate = DateTime.Now;

                            //masterRepo.Update(master);
                            await masterRepo.UpdateAsync(master);


                            statusCode = 1;
                            message = "Cập nhật thành công!";
                        }

                        
                    }
                   
                }

                return Ok(new
                {
                    StatusCode = statusCode,
                    Message = message,
                    ExamMaster = resultMaster
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = 0,
                    Message = $"Thêm thất bại! ({ex.Message})"
                });
            }
        }
    }
}
