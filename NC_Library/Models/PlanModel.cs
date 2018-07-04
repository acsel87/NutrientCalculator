using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_Library.Models
{
    public class PlanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();
        public List<RecipeModel> RecipeList { get; set; } = new List<RecipeModel>();

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
                    nutrients.AddDecimalArray(f.NutrientDecimalList());
                }
            }

            if (RecipeList != null)
            {
                foreach (RecipeModel r in RecipeList)
                {
                    for (int i = 0; i < r.NutrientList.Length; i++)
                    {
                        nutrients[i] += r.NutrientList[i];
                    }
                }
            }

            return nutrients;
        }
    }
}
