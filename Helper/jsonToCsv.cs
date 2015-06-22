using System;
using System.Xml;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Helper
{
    public static class jsonToCsv
    {
        public static string getCsv(string jsonString)
        {
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonString + "}}");
            XmlDocument xmldoc = new XmlDocument();
            //Create XmlDoc Object
            xmldoc.LoadXml(xml.InnerXml);
            //Create XML Steam 
            var xmlReader = new XmlNodeReader(xmldoc);
            DataSet dataSet = new DataSet();
            //Load Dataset with Xml
            dataSet.ReadXml(xmlReader);
            //return single table inside of dataset
            string csv = "";
            //only the last table has data
            csv = ToCSV(dataSet.Tables[dataSet.Tables.Count - 1], "\t"); //Excel uses TabStop by default for csv
            return csv;
        }
        private static string ToCSV(this DataTable table, string delimator)
        {
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
                }
            }
            return result.ToString().TrimEnd(new char[] { '\r', '\n' });
        }
    }
}
