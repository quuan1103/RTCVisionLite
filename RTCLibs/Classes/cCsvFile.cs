using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;


namespace RTCLibs
{
    internal sealed class CsvObjectMap : ClassMap<CsvObject>
    {
        public CsvObjectMap()
        {
            Map(m => m.Col1);
            Map(m => m.Col2);
            Map(m => m.Col3);
            Map(m => m.Col4);
            Map(m => m.Col5);
            Map(m => m.Col6);
            Map(m => m.Col7);
            Map(m => m.Col8);
            Map(m => m.Col9);
            Map(m => m.Col10);
            Map(m => m.Col11);
            Map(m => m.Col12);
            Map(m => m.Col13);
            Map(m => m.Col14);
            Map(m => m.Col15);
            Map(m => m.Col16);
            Map(m => m.Col17);
            Map(m => m.Col18);
            Map(m => m.Col19);
            Map(m => m.Col20);
            Map(m => m.Col21);
            Map(m => m.Col22);
            Map(m => m.Col23);
            Map(m => m.Col24);
            Map(m => m.Col25);
            Map(m => m.Col26);
            Map(m => m.Col27);
            Map(m => m.Col28);
            Map(m => m.Col29);
            Map(m => m.Col30);
        }
    }
    public static class CsvFile
    {
        public static bool Write(List<CsvRecord> records, 
            string fileName, 
            ref int rowCount,
            out string errMessage)
        {
            errMessage = string.Empty;
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                using (var writer = new StreamWriter(fileName, rowCount != 0))
                using (var csvWriter = new CsvWriter(writer, config))
                {
                    csvWriter.Context.RegisterClassMap<CsvObjectMap>();
                    csvWriter.WriteRecords(records);
                }
                rowCount += 1;
                return true;
            }
            catch (Exception e)
            {
                errMessage = e.Message;
                return false;
            }
        }
    }
    public class CsvObject
    {

        public string Col28 { get; set; }
        public string Col27 { get; set; }
        public string Col26 { get; set; }
        public string Col25 { get; set; }
        public string Col24 { get; set; }
        public string Col23 { get; set; }
        public string Col22 { get; set; }
        public string Col21 { get; set; }
        public string Col20 { get; set; }
        public string Col19 { get; set; }
        public string Col18 { get; set; }
        public string Col17 { get; set; }
        public string Col16 { get; set; }
        public string Col29 { get; set; }
        public string Col15 { get; set; }
        public string Col13 { get; set; }
        public string Col12 { get; set; }
        public string Col11 { get; set; }
        public string Col10 { get; set; }
        public string Col9 { get; set; }
        public string Col8 { get; set; }
        public string Col7 { get; set; }
        public string Col6 { get; set; }
        public string Col5 { get; set; }
        public string Col4 { get; set; }
        public string Col3 { get; set; }
        public string Col2 { get; set; }
        public string Col1 { get; set; }
        public string Col14 { get; set; }
        public string Col30 { get; set; }
    }
    public class CsvRecord
    {
        public List<string> Value { get; set; }
        public CsvRecord()
        {
            Value = new List<string>();
        }
    }
}
