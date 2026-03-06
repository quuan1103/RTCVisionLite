using RTC_Vision_Lite.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite
{
    public static class Lib
    {
        public static DataTable GetDataTable(string sqlQuery, string dataSource)
        {
            cSQLite myConn = new cSQLite(dataSource);
            DataTable dataTable = myConn.GetDataTable(sqlQuery);
            myConn.Close();
            return dataTable;
        }
        public static bool ExecuteQuery(string sqlQuery, string dataSource)
        {
            cSQLite myConn = new cSQLite(dataSource);
            bool result = myConn.ExecuteQuery(sqlQuery);
            myConn.Close();
            return result;

        }
        #region Chuyển kiểu, ép kiểu
        public static string ToString(object x)
        {
            if(x != null)
            {
                return x.ToString().Trim();
            }
            return "";
        }
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
        public static int Object2Int(object @object, int @default = 0)
        {
            if (@object == null)
                return @default;
            if (int.TryParse(@object.ToString(), out int result))
                return result;
            return @default;
        }
        public static double Object2Double(object @object, double @default = 0)
        {
            if (@object == null)
                return @default;
            if (double.TryParse(@object.ToString(), out double result))
                return result;
            return @default;
        }
        public static long Object2Long(object @object, long @default = 0)
        {
            if (@object == null)
                return @default;
            if (long.TryParse(@object.ToString(), out long result))
                return result;
            return @default;
        }
        public static decimal Object2Decimal(object @object, decimal @default = 0)
        {
            if (@object == null)
                return @default;
            if (decimal.TryParse(@object.ToString(), out decimal result))
                return result;
            return @default;
        }
        public static bool Object2Bool(object @object, bool @default = false)
        {
            if (@object == null)
                return @default;
            if (bool.TryParse(@object.ToString(), out bool result))
                return result;
            return @default;
        }

        #endregion
    }
}
