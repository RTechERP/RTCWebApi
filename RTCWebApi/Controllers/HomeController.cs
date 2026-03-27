using EASendMail;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RTCWeb.Common;
using RTCWebApi.Model;
using RTCWebApi.Model.Common;
using RTCWebApi.Model.DTO;
using RTCWebApi.Repository;
using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RTCWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        UsersRepo userRepo = new UsersRepo();

        [HttpPost("login")]
        public IActionResult Login(LoginInfo loginInfo)
        {
            int statuscode = 0;
            string statusname = "NG";
            string message = "Đăng nhập thất bại!";

            UsersDTO user = new UsersDTO();

            if (string.IsNullOrEmpty(loginInfo.LoginName.Trim()) || string.IsNullOrEmpty(loginInfo.Password.Trim()))
            {
                statuscode = 0;
                statusname = "NG";
                message = "Bạn chưa nhập tên đăng nhập hoặc mật khẩu!";
            }


            else
            {
                user = userRepo.Login(loginInfo);
                if (user != null && user.ID > 0 && user.EmployeeId > 0)
                {
                    statuscode = 1;
                    statusname = "Ok";
                    message = "Đăng nhập thành công!";
                }
            }

            return Ok(new
            {
                StatusCode = statuscode,
                StatusName = statusname,
                Message = message,
                User = user
            });
        }


        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                int statusCode = 0;
                string fileName = "";
                string message = "Upload file thất bại!";

                if (file != null)
                {
                    string path = Config.Path() + @"Images\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //string name = System.IO.Path.GetFileNameWithoutExtension(path + file.FileName);
                    //string extention = System.IO.Path.GetExtension(path + file.FileName);
                    //string filePath = path + fileName +  "_" + DateTime.Now.ToString("ddMMyyHHmm") + extention;
                    //string sourceFileName = System.IO.Path.GetFullPath(file.FileName);
                    //System.IO.File.Move(sourceFileName, path + file.FileName);

                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        statusCode = 1;
                        fileName = file.FileName;
                        message = "Upload File thành công!";
                    }

                    //statusCode = 1;
                    //fileName = file.FileName;
                    //message = "Upload File thành công!";

                }
                else
                {
                    statusCode = 0;
                    message = "Not Upload File!";
                }

                return Ok(new
                {
                    StatusCode = statusCode,
                    FileName = fileName,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = 0,
                    Message = $"Upload file thất bại! ({ex.Message})"
                });
            }
        }


        //[HttpPost("uploadimagedemo")]
        //public IActionResult UploadImageProductDemo([FromForm] FileInput fileInput)
        //{
        //    try
        //    {
        //        int statusCode = 0;
        //        string fileName = "";
        //        string message = "Upload file thất bại!";

        //        if (fileInput.File != null)
        //        {
        //            //string path = @"\\192.168.1.2\ftp\Upload\Images\ProductDemo\";
        //            if (!Directory.Exists(fileInput.Path))
        //            {
        //                Directory.CreateDirectory(fileInput.Path);
        //            }

        //            //string name = System.IO.Path.GetFileNameWithoutExtension(path + file.FileName);
        //            //string extention = System.IO.Path.GetExtension(path + file.FileName);
        //            //string filePath = path + fileName +  "_" + DateTime.Now.ToString("ddMMyyHHmm") + extention;
        //            //string sourceFileName = System.IO.Path.GetFullPath(file.FileName);
        //            //System.IO.File.Move(sourceFileName, path + file.FileName);

        //            using (FileStream fileStream = System.IO.File.Create(fileInput.Path + fileInput.File.FileName))
        //            {
        //                fileInput.File.CopyTo(fileStream);
        //                fileStream.Flush();

        //                statusCode = 1;
        //                fileName = fileInput.File.FileName;
        //                message = "Upload File thành công!";
        //            }

        //            //statusCode = 1;
        //            //fileName = file.FileName;
        //            //message = "Upload File thành công!";

        //        }
        //        else
        //        {
        //            statusCode = 0;
        //            message = "Not Upload File!";
        //        }

        //        return Ok(new
        //        {
        //            StatusCode = statusCode,
        //            FileName = fileName,
        //            Message = message
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new
        //        {
        //            StatusCode = 0,
        //            Message = $"Upload file thất bại! ({ex.Message})"
        //        });
        //    }
        //}

        [HttpPost("uploadimagedemo")]
        public IActionResult UploadImageProductDemo(IFormFile file)
        {
            try
            {
                int statusCode = 0;
                string fileName = "";
                string message = "Upload file thất bại!";

                if (file != null)
                {
                    string path = @"\\192.168.1.2\ftp\Upload\Images\ProductDemo\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //string name = System.IO.Path.GetFileNameWithoutExtension(path + file.FileName);
                    //string extention = System.IO.Path.GetExtension(path + file.FileName);
                    //string filePath = path + fileName +  "_" + DateTime.Now.ToString("ddMMyyHHmm") + extention;
                    //string sourceFileName = System.IO.Path.GetFullPath(file.FileName);
                    //System.IO.File.Move(sourceFileName, path + file.FileName);

                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        statusCode = 1;
                        fileName = file.FileName;
                        message = "Upload File thành công!";
                    }

                    //statusCode = 1;
                    //fileName = file.FileName;
                    //message = "Upload File thành công!";

                }
                else
                {
                    statusCode = 0;
                    message = "Not Upload File!";
                }

                return Ok(new
                {
                    StatusCode = statusCode,
                    FileName = fileName,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    StatusCode = 0,
                    Message = $"Upload file thất bại! ({ex.Message})"
                });
            }
        }

        [HttpPost("uploaddocument")]
        public IActionResult UploadDocument(IFormFile file)
        {
            try
            {
                int statusCode = 0;
                string fileName = "";
                string message = "Upload file thất bại!";

                if (file != null)
                {
                    string path = @"\\192.168.1.2\ftp\Upload\RTCDocument\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        statusCode = 1;
                        fileName = file.FileName;
                        message = "Upload File thành công!";
                    }
                }
                else
                {
                    statusCode = 0;
                    message = "Not Upload File!";
                }

                return Ok(new
                {
                    StatusCode = statusCode,
                    FileName = fileName,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 0,
                    Message = $"Upload file thất bại! ({ex.Message})"
                });
            }
        }

        [HttpPost("uploadbillvehicle")]
        public IActionResult UploadBill(IFormFile file)
        {
            try
            {
                int statusCode = 0;
                string fileName = "";
                string message = "Upload file thất bại!";

                if (file != null)
                {
                    string path = @"\\192.168.1.2\ftp\Upload\BillVehicle\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();

                        statusCode = 1;
                        fileName = file.FileName;
                        message = "Upload File thành công!";
                    }
                }
                else
                {
                    statusCode = 0;
                    message = "Not Upload File!";
                }

                return Ok(new
                {
                    StatusCode = statusCode,
                    FileName = fileName,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 0,
                    Message = $"Upload file thất bại! ({ex.Message})"
                });
            }
        }


        [DisableRequestSizeLimit]
        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile(string path)
        {
            try
            {
                var file = Request.Form.Files;
                //string path = @"\\192.168.1.2\ftp\Upload\Course\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (file.Count > 0)
                {
                    foreach (var item in file)
                    {
                        // Thực hiện xử lý tệp tin ở đây, ví dụ lưu vào ổ đĩa
                        string filePath = Path.Combine(path,item.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }
                    }
                    return Ok(new
                    {
                        status = 1,
                        message = "Upload thành công!",
                        fileName = file
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "Không có file upload!"
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = 0,
                    message = ex.Message
                });
            }
        }

        [HttpPost("uploadfiledemo")]
        public async Task<IActionResult> UploadFile([FromBody] FileUploadInfo info)
        {
            int status = 0;
            string message = "";

            try
            {
                string path = Configuration.GetValue<string>("PathUpload");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = "";

                BillSaleDTO billSale = SQLHelper<BillSaleDTO>.ProcedureToModel("spGetBillSaleByCode", new string[] { "@Code" }, new object[] { info.name });

                if (billSale.BillType == 0)
                {
                    status = 0;
                    message = $"Không tồn tại mã phiếu [{info.name}]!";

                    return BadRequest(new
                    {
                        status = status,
                        message = message
                    });
                }

                string billType = billSale.BillType == 1 ? "PhieuNhapKho" : (billSale.BillType == 2 ? "PhieuXuatKho" : "");

                string billPath = $@"{Configuration.GetValue<string>("PathServer")}\VP.{billSale.WareHouseCode}\{billType}\{billSale.CreatDate.Value.Year}\{billSale.Code}";

                if (!Directory.Exists(billPath))
                {
                    Directory.CreateDirectory(billPath);
                }

                byte[] imageBytes = Convert.FromBase64String(info.content);

                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {

                    ms.Flush();

                    //filePath = path +  info.name + $"_{DateTime.Now.ToString("ddMMyy_HHmmss")}.jpg";
                    filePath = Path.Combine(billPath, $"{billSale.Code}_{ DateTime.Now.ToString("ddMMyy_HHmmss")}.jpg");

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ms.CopyToAsync(stream);
                    }

                    status = 1;
                    message = "Upload thành công!";
                }

                return Ok(new
                {
                    status = status,
                    message = message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = status,
                    message = ex.Message
                });
            }
        }


        [HttpGet("getdailyreport")]
        public ContentResult GetDailyReport(string lstTeamID, string startDate, string endDate, int departmentID)
        {
            string htmlTemp = "<!DOCTYPE html>" +
                "<html lang=\"en\">" +
                    "<head><meta charset=\"UTF-8\">" +
                        "<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\">" +
                        "<title>Document</title>" +
                    "</head>" +
                    "<body>" +
                        "<textarea id=\"text_area\" style=\"width: 100%; height: 1000px; \" onclick=\"SelectAll('text_area')\">@content</textarea>" +
                    "</body>" +
                    "<script type=\"text/javascript\">" +
                        "function SelectAll(id) {document.getElementById(id).focus();document.getElementById(id).select();}" +
                    "</script>" +
                "</html>";

            DataTable dt = TextUtils.GetDataTableSP("spGetDailyReportTechnicalByThao",
                    new string[] { "@DateStart", "@DateEnd", "@TeamID", "@Keyword", "@UserID", "@DepartmentID" },
                    new object[] {startDate
                                ,endDate
                                ,lstTeamID
                                ,""
                                ,0
                                ,departmentID
                    });
            List<string> lstProject = new List<string>();
            string Content = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string projectCode = dt.Rows[i]["ProjectCode"].ToString();
                if (projectCode.Contains("RTC.22.007") || projectCode.Contains("RTC.22.003") || projectCode.Trim() == "") continue;
                if (lstProject.Contains(projectCode)) continue;
                string projectText = dt.Rows[i]["ProjectText"].ToString();
                lstProject.Add(projectCode);
                DataRow[] arr = dt.Select($"ProjectCode = '{projectCode}'");
                Content += "- " + projectText + "\r\n";
                //Content += "- " + projectText + "</br>";
                for (int j = 0; j < arr.Length; j++)
                {
                    string c = arr[j]["Content"].ToString();
                    string[] arrC = c.Split('\n');
                    for (int h = 0; h < arrC.Length; h++)
                    {
                        Content += $"    {arrC[h]}\r\n";
                        //Content += $"    {arrC[h]}</br>";
                    }
                }
            }

            return new ContentResult
            {
                Content = htmlTemp.Replace("@content", Content),
                ContentType = "text/html"
            };

        }

        [HttpGet("listfile")]
        public IActionResult ListFile(string path)
        {
            try
            {
                //DirectoryInfo info = new DirectoryInfo(@"\\192.168.1.2\ftp\UpdateVersion\RTC");
                DirectoryInfo info = new DirectoryInfo(path);
                List<FileInfo> listfile = info.GetFiles().OrderByDescending(x =>  TextUtils.ToInt(Path.GetFileNameWithoutExtension(x.FullName))).ToList();
                string newVersion = listfile.FirstOrDefault().FullName;

                List<FileInfoDTO> listFile = new List<FileInfoDTO>();
                foreach (var item in listfile)
                {
                    FileInfoDTO fileInfo = new FileInfoDTO()
                    {
                        Name = item.Name,
                        Path = item.FullName
                    };
                    listFile.Add(fileInfo);
                }
                return Ok(new
                {
                    status = 1,
                    newVersion = newVersion,
                    data = listFile

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message
                });
            }
        }

        [HttpGet("versionrtc")]
        public ContentResult GetVersionRTC()
        {
            string content = "";

            DirectoryInfo info = new DirectoryInfo(@"\\192.168.1.2\ftp\UpdateVersion\RTC");
            List<FileInfo> listfile = info.GetFiles().OrderByDescending(x => Convert.ToInt32(Path.GetFileNameWithoutExtension(x.FullName))).Take(10).ToList();
            foreach (FileInfo item in listfile)
            {
                string fileName = item.Name;
                content += $"<div><a href=\"http://192.168.1.2:8083/api/NewVersion/{fileName}\">{fileName}</a></div>";
            }

            string html = "<!DOCTYPE html>" +
                            "<html lang=\"en\">" +
                            "<head>" +
                                "<meta charset=\"UTF-8\">" +
                                "<meta name=\"viewport\" content=\"width = device-width, initial-scale = 1.0\">" +
                                "<title>Document</title>" +
                            "</head>" +
                            $"<body>{content}</body>" +
                            "</html>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        [HttpGet("removefile")]
        public IActionResult RemoveFile(string path)
        {
            try
            {
                var file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                    return Ok(new
                    {
                        status = 1,
                        message = "Xoá thành công!",
                        //fileName = file
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "File không tồn tại!",
                        //fileName = file
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                    //fileName = file
                });
            }

        }

    }
}
