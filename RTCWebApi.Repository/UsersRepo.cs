using RTCWebApi.Model;
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
    public class UsersRepo:GenericRepo<User>
    {
        public UsersDTO Login(LoginInfo loginInfo)
        {
            DataTable dt = TextUtils.GetDataTableSP("spLogin",
                                            new string[] { "@LoginName", "@Password" }, new object[] { loginInfo.LoginName, MaHoaMD5.EncryptPassword(loginInfo.Password) });
            UsersDTO user = new UsersDTO();

            if (dt.Rows.Count > 0)
            {
                user.ID = TextUtils.ToInt(dt.Rows[0]["ID"]);
                user.EmployeeId = TextUtils.ToInt(dt.Rows[0]["EmployeeId"]);
                user.Code = TextUtils.ToString(dt.Rows[0]["Code"]);
                user.FullName = TextUtils.ToString(dt.Rows[0]["FullName"]);
            }

            return user;
        }
    }
}
