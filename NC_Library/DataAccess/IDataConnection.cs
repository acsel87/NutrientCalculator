using NC_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_Library.DataAccess
{
    public interface IDataConnection
    {
        void CreateFood(FoodModel model);
        void CreateRecipe(RecipeModel model);
        void CreatePlan(PlanModel model);

        void UpdateFood(FoodModel model);
        void UpdateRecipe(RecipeModel model);
        void UpdatePlan(PlanModel model);

        void DeleteFood(FoodModel model);
        void DeleteRecipe(RecipeModel model);
        void DeletePlan(PlanModel model);

        FoodModel ViewFood(FoodModel model);
        RecipeModel ViewRecipe(RecipeModel model);
        PlanModel ViewPlan(PlanModel model);

        List<FoodModel> GetFood_All();
        List<RecipeModel> GetRecipe_All();
        List<PlanModel> GetPlan_All();        
    }
}
