using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_Library.Models
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nutrient_List { get; set; }

        public decimal[] NutrientDecimalList()
        {
            decimal[] nutrientsDecimal = new decimal[32];

            if (Nutrient_List != null)
            {
                string[] nutrientValues = Nutrient_List.Split(';');

                for (int i = 0; i < nutrientValues.Length; i++)
                {
                    nutrientsDecimal[i] = Math.Round(decimal.Parse(nutrientValues[i]),2);
                }                
            }

            return nutrientsDecimal;
        }

        //public string NutrientsToString()
        //{
        //    string nutrientsString = "";

        //    if (NutrientDecimalList != null)
        //    {
        //        foreach (decimal d in NutrientDecimalList)
        //        {
        //            nutrientsString += $"{d};";
        //        }

        //       nutrientsString = nutrientsString.Remove(nutrientsString.Length - 1 , 1);
        //    }

        //    return nutrientsString;
        //}
    }
}
