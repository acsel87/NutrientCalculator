using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using NC_Library.Models;

namespace NC_Library.DataAccess
{
    public static class ImportNutrients
    {
        public static List<FoodModel> originalFoodModels = new List<FoodModel>();
        public static string[] NutrientNames = new string[32];

        public static void ParseXLSX(string filePath)
        {   
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);            

            if (reader != null)
            {
                DataSet content = reader.AsDataSet();

                DataRow firstRow = content.Tables[0].Rows[0];

                for (int i = 0; i < NutrientNames.Length; i++)
                {
                    NutrientNames[i] = firstRow.ItemArray[i+1].ToString();
                }

                var rows = content.Tables[0].Rows;
                int index = 0;

                foreach (DataRow row in rows)
                {
                    if (index == 0)
                    {
                        index++;
                        continue;
                    }

                    FoodModel foodModel = new FoodModel
                    {
                        Name = row[0].ToString(),
                        Type = ""
                    };                   

                    for (int i = 0; i < NutrientNames.Length; i++)
                    {
                        foodModel.Nutrient_List += $"{row[i + 1].ToString()};";
                    }

                    foodModel.Nutrient_List = foodModel.Nutrient_List.Remove(foodModel.Nutrient_List.Length - 1, 1);

                    originalFoodModels.Add(foodModel);
                }
            }
        }
    }
}
