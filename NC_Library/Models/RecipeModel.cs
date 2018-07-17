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
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();
        public List<int> FoodAmount { get; set; } = new List<int>();

        public int Amount
        {
            get
            {
                int tempAmount = 0;

                foreach (int i in FoodAmount)
                {
                    tempAmount += i;
                }

                return tempAmount;
            }
        }

        public double[] NutrientList
        {
            get
            {               
                return GetNutrientList();
            }
        }

        private double[] GetNutrientList()
        {
            double[] nutrients = new double[32];

            if (FoodList != null)
            {
                for (int i = 0; i < FoodList.Count; i++)
                {                    
                    nutrients.AddDoubleArray(FoodList[i].NutrientList, FoodAmount[i]);
                }
            }
            return nutrients;
        }
    }
}
