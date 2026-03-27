using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.Model.Common
{
    public class TextUtils
    {
        private static string connectionString = Config.Connection();


        public static bool ConnectFTPServer(string username, string password)
        {
            try
            {
                var credentials = new NetworkCredential(username, password, @"\\192.168.1.190");
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Load DataTable từ StoreProcedure
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="param"></param>
        /// <param name="valueParam"></param>
        /// <returns></returns>
        public static DataTable GetDataTableSP(string commandText, string[] param, object[] valueParam)
        {
            try
            {
                var dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlParameter sqlParam;
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    if (param != null)
                    {
                        for (int i = 0; i < param.Length; i++)
                        {
                            sqlParam = new SqlParameter(param[i], valueParam[i]);
                            cmd.Parameters.Add(sqlParam);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load DataSet từ StoreProcedure
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="param"></param>
        /// <param name="valueParam"></param>
        /// <returns></returns>
        public static DataSet GetDataSetSP(string commandText, string[] param, object[] valueParam)
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlParameter sqlParam;
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    if (param != null)
                    {
                        for (int i = 0; i < param.Length; i++)
                        {
                            sqlParam = new SqlParameter(param[i], valueParam[i]);
                            cmd.Parameters.Add(sqlParam);
                        }
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);
                    conn.Close();
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ToString(object x)
        {
            try
            {
                return Convert.ToString(x);
            }
            catch
            {

                return "";
            }
        }


        /// <summary>
        /// Convert object to int
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ToInt(object x)
        {
            try
            {
                return Convert.ToInt32(x);
            }
            catch
            {

                return 0;
            }
        }


        /// <summary>
        /// Convert object to float
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float ToFloat(object x)
        {
            try
            {
                return Convert.ToSingle(x);
            }
            catch
            {

                return 0;
            }
        }

        /// <summary>
        /// Convert object to decimal
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object x)
        {
            try
            {
                return Convert.ToDecimal(x);
            }
            catch
            {

                return 0;
            }
        }

        /// <summary>
        /// Convert object to bool
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool ToBoolean(object x)
        {
            try
            {
                return Convert.ToBoolean(x);
            }
            catch
            {

                return false;
            }
        }

        /// <summary>
        /// Convert DataTable to List object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static T GetItem<T>(DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                        {
                            //var value = Convert.IsDBNull()
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }

                        else
                        {
                            continue;
                        }

                    }
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
