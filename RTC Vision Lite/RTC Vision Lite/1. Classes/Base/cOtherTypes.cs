using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cPropCompare
    {
        /// <summary>
        /// Type of the data
        /// </summary>
        public Type DataType;
        /// <summary>
        /// Name of the RTC property camera
        /// </summary>
        public string RTCPropCAMName;
        /// <summary>
        /// Name of the property camera.
        /// </summary>
        public string PropCAMName;
        /// <summary>
        /// The value
        /// </summary>
        public decimal DValue;
        /// <summary>
        /// The minimum value
        /// </summary>
        public decimal DMinValue;
        /// <summary>
        /// The maximum value
        /// </summary>
        public decimal DMaxValue;
        /// <summary>
        /// The sarr value
        /// </summary>
        public string[] SARRValue;
        /// <summary>
        /// The value
        /// </summary>
        public string SValue;
        /// <summary>
        /// True to read only
        /// </summary>
        public bool ReadOnly;
        /// <summary>
        /// True if is live, false if not
        /// </summary>
        public bool IsLive;

        public cPropCompare()
        {
            DataType = typeof(string);
            PropCAMName = string.Empty;
            DValue = 0;
            DMinValue = 0;
            DMaxValue = 0;
            SValue = string.Empty;
            ReadOnly = false;
            SARRValue = new string[] { };
            IsLive = true;
        }
       
    }
    internal class DeviceInfo
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;

        public string SubnetMask { get; set; } = string.Empty;
        public string DefaultGateway { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsGIGE { get; set; } = false;
        public bool IsExists { get; set; } = false;


    }
    class cOtherTypes
    {
    }
}
