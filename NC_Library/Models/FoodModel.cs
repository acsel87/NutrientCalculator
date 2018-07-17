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

        public double[] NutrientList
        {
            get
            {
                return GetNutrientList();
            }
        }

        public double[] GetNutrientList()
        {
            double[] nutrientsDouble = new double[32];

            if (Nutrient_List != null)
            {
                string[] nutrientValues = Nutrient_List.Split(';');

                for (int i = 0; i < nutrientValues.Length; i++)
                {
                    double temp = 0;
                    double.TryParse(nutrientValues[i], out temp);
                    nutrientsDouble[i] = Math.Round(temp, 2);
                }                
            }

            return nutrientsDouble;
        }
    }
}
