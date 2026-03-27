using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class UsersDTO
    {
        public int ID { get; set; }
        public int? EmployeeId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
    }
}
