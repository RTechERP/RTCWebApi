using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTCWebApi.Model.DTO;
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
    public class ExamQuestionBankController : ControllerBase
    {
        ExamListTestRepo listTestRepo = new ExamListTestRepo();
        ExamQuestionBankRepo questionBankRepo = new ExamQuestionBankRepo();
        ExamTypeTestRepo typeTestRepo = new ExamTypeTestRepo();
        ExamCategoryRepo categoryRepo = new ExamCategoryRepo();

        //[HttpGet("questionbank")]
        //public  IActionResult GetQuestionBank(string code)
        //{
        //    ExamCategory category = categoryRepo.GetAll().Where(x => x.CatCode == code).SingleOrDefault();
        //    if (category != null)
        //    {
        //        IEnumerable<ExamListTest> examListTest = listTestRepo.GetAll().Where(x => x.ExamCategoryId == category.Id);
        //        List<ExamQuestionBankDTO> listQuestionBank = new List<ExamQuestionBankDTO>();
        //        foreach (ExamListTest item in examListTest)
        //        {
        //            ExamQuestionBankDTO examQuestionBank = new ExamQuestionBankDTO();
        //            examQuestionBank.Id = item.Id;
        //            examQuestionBank.CodeTest = item.CodeTest;
        //            examQuestionBank.NameTest = item.NameTest;
        //            examQuestionBank.TestTime = item.TestTime;
        //            examQuestionBank.ExamQuestionBank = questionBankRepo.GetAll().Where(x => x.ExamListTestId == item.Id);
        //            listQuestionBank.Add(examQuestionBank);
        //        }

        //        return Ok(new
        //        {
        //            CategoryCode = category.CatCode,
        //            CategoryName =category.CatName,
        //            Exam = listQuestionBank
        //        });
        //    }
        //    else
        //    {
        //        return Ok(new
        //        {
        //            status = "Failed",
        //            message = "Bài kiểm tra không tồn tại. Vui lòng kiểm tra lại!"
        //        });
        //    }
        //}

        [HttpGet("questionbank")]
        public IActionResult GetQuestionBank(int examlistId)
        {
            ExamListTest examList = listTestRepo.GetByID(examlistId);
            List<ExamQuestionDTO> questionBanks = new List<ExamQuestionDTO>();
            if (examList != null)
            {
                //questionBanks = questionBankRepo.GetAll().Where(x => x.ExamListTestId == examList.Id).ToList();
                questionBanks = questionBankRepo.GetExamQuestion(examlistId);
                return Ok(new
                {
                    StatusCode = 1,
                    Message = "Thành công!",
                    ExamCode = examList.CodeTest,
                    ExamName = examList.NameTest,
                    ExamTime = examList.TestTime,
                    ExamTypeId = examList.ExamTypeTestId,
                    ExamTypeText = typeTestRepo.GetAll().Where(x => x.Id == examList.ExamTypeTestId).SingleOrDefault().TypeName,
                    QuestionBank = questionBanks
                });


              //return Ok(new
              //{
              //    status = 1,
              //    message = "",
              //    data = questionBanks
              //})
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = 0,
                    Message = "Không tồn tại bài thi này!"
                }) ;
            }
        }
    }
}
