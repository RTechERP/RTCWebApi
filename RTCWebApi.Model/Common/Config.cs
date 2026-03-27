using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.Common
{
    public static class Config
    {
        /// <summary>
        /// Môi trường chạy
        /// 1: Môi trường Publish lên server
        /// 0: Môi trường Test trên local
        /// </summary>
        private static int _environment = 1;

        public static string Path()
        {
            string path = "";
            if (_environment == 0)
            {
                path = @"D:\LeTheAnh\Image\";
            }
            else
            {
                path = @"\\192.168.1.2\ftp\Upload\";
            }

            return path;
        }
       

        public static string Connection()
        {
            string conn = "";
            if (_environment == 0)
            {
                conn = @"Server=DESKTOP-40H717B\SQLEXPRESS;Database=RTCTest;User ID=sa;Password=123456a@";
            }
            else
            {
                conn = "Server=192.168.1.3;Database=RTC;User ID=sa;Password=rtc@rtc123";
            }

            return conn;
        }
    }
}
