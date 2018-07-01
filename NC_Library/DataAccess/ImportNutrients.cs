using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace NC_Library.DataAccess
{
    public static class ImportNutrients
    {
        public static List<string> ParseExcel(string filePath)
        {
            List<string> nutrients = new List<string>(); 
            
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);            

            if (reader != null)
            {
                DataSet content = reader.AsDataSet();

                DataRow firstRow = content.Tables[0].Rows[0];

                foreach (var row in firstRow.ItemArray)
                {
                    nutrients.Add(row.ToString());
                }
            }
            return nutrients;
        }
    }
}
