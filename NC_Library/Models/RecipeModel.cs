using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_Library.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();

        public decimal[] NutrientList
        {
            get
            {               
                return GetNutrientList();
            }
        }

        private decimal[] GetNutrientList()
        {
            decimal[] nutrients = new decimal[32];

            if (FoodList != null)
            {
                foreach (FoodModel f in FoodList)
                {
                    nutrients.AddDecimalArray(f.NutrientList);
                }
            }
            return nutrients;
        }
    }
}
