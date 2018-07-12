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
        public bool IsCustom { get; set; }
        public string Type { get; set; }
        public string Nutrient_List { get; set; }

        public decimal[] NutrientList
        {
            get
            {
                return GetNutrientList();
            }
        }

        public decimal[] GetNutrientList()
        {
            decimal[] nutrientsDecimal = new decimal[32];

            if (Nutrient_List != null)
            {
                string[] nutrientValues = Nutrient_List.Split(';');

                for (int i = 0; i < nutrientValues.Length; i++)
                {
                    decimal temp = 0M;
                    decimal.TryParse(nutrientValues[i], out temp);
                    nutrientsDecimal[i] = Math.Round(temp, 2);
                }                
            }

            return nutrientsDecimal;
        }
    }
}
