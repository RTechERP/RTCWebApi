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
    public class ExamListTestController : ControllerBase
    {
        ExamListTestRepo listTestRepo = new ExamListTestRepo();
        ExamCategoryRepo categoryRepo = new ExamCategoryRepo();

        [HttpGet("getexamlist")]
        public IActionResult GetExamListTest(string code)
        {
            ExamCategory category = categoryRepo.GetAll().FirstOrDefault(x => x.CatCode == code && x.Status == true);

            List<ExamListTest> examLists = new List<ExamListTest>();
            if (category != null)
            {
                examLists = listTestRepo.GetAll().Where(x => x.ExamCategoryId == category.Id).ToList();

                return Ok(new
                {
                    StatusCode = 1,
                    Message = "Thành công!",
                    CategoryCode = category.CatCode,
                    CategoryName = category.CatName,
                    ExamList = examLists
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = 0,
                    Message = "Mã kỳ thi không tồn tại hoặc không được sử dụng!"
                });
            }

            
        }
    }
}
