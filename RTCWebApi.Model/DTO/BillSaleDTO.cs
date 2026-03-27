using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.DTO
{
    public class BillSaleDTO
    {
        public string Code { get; set; }
        public string WareHouseCode { get; set; }
        public DateTime? CreatDate { get; set; }
        public int BillType { get; set; }
    }
}
