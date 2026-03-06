using RTCConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cColumnProperty
    {
        public Guid ID { get; set; }
        public bool Active { get; set; }
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Format { get; set; }
        public string DisplayFormat { get; set; }
        public string Value { get; set; }
        public Guid RefID { get; set; }
        public string PropName { get; set; }
        public string Ref { get; set; }
        public bool IsRowToCol { get; set; }
        public string SortMode { get; set; }
        internal int AutoNumber = 0;
        public cColumnProperty(List<cColumnProperty> list = null)
        {
            ID = Guid.NewGuid();
            OrderNum = 1;
            Active = true;
            Name = GenerateColumnName(list);
            DataType = cDataTypes.String;
            Format = string.Empty;
            DisplayFormat = string.Empty;
            Value = string.Empty;
            RefID = Guid.Empty;
            PropName = string.Empty;
            Ref = string.Empty;
            IsRowToCol = false;
            SortMode = cSortMode.None;

        }

        internal string GenerateColumnName(List<cColumnProperty> list)
        {
            if (list == null || list.Count <= 0)
                return cStrings.NewColumn;
            else
            {
                string s = cStrings.NewColumn;
                int i = 1;
                while (list.FirstOrDefault(x => x.Name.ToLower() == s.ToLower()) != null)
                {
                    s = cStrings.NewColumn + " " + i.ToString();
                    i += 1;
                }
                return s;
            }
        }
        internal cColumnProperty Clone()
        {
            cColumnProperty cloneProperty = new cColumnProperty
            {
                OrderNum = this.OrderNum,
                Active = this.Active,
                Name = this.Name,
                DataType = this.DataType,
                Format = this.Format,
                DisplayFormat = this.DisplayFormat,
                Value = this.Value,
                RefID = this.RefID,
                PropName = this.PropName,
                Ref = this.Ref,
                IsRowToCol = this.IsRowToCol
            };
            return cloneProperty;
        }

    }

}

