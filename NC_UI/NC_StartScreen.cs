using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NC_Library.DataAccess;
using NC_UI.Properties;
using NC_Library.Models;

namespace NC_UI
{
    public partial class NC_StartScreen : Form
    {
        SqlConnector sql = new SqlConnector();

        public NC_StartScreen()
        {
            InitializeComponent();

            FoodModel f1 = new FoodModel
            {
                Id = 1,
                Name = "f1"             
            };

            FoodModel f2 = new FoodModel
            {
                Id = 2,
                Name = "f2"
            };

            FoodModel f3 = new FoodModel
            {
                Id = 3,
                Name = "f3"
            };

            RecipeModel r1 = new RecipeModel
            {
                Id = 1,
                Name = "r1",
                Amount = 10,
                FoodList = new List<FoodModel> { f1}
            };

            RecipeModel r2 = new RecipeModel
            {
                Id = 2,
                Name = "r2",
                Amount = 20,
                FoodList = new List<FoodModel> { f1, f2 }
            };

            RecipeModel r3 = new RecipeModel
            {
                Id = 3,
                Name = "r3",
                Amount = 30,
                FoodList = new List<FoodModel> { f1, f2, f3 }
            };

            PlanModel p1 = new PlanModel
            {
                Name = "p1",
                Amount = 100,
                FoodList = new List<FoodModel> { f1 },
                RecipeList = new List<RecipeModel> { r1 }
            };

            PlanModel p2 = new PlanModel
            {
                Name = "p2",
                Amount = 200,
                FoodList = new List<FoodModel> { f1, f2 },
                RecipeList = new List<RecipeModel> { r1, r2, r3 }
            };

            PlanModel p3 = new PlanModel
            {
                Name = "p3",
                Amount = 300,
                FoodList = new List<FoodModel> { f1, f2, f3 },
                RecipeList = new List<RecipeModel> { r2, r3 }
            };

            //sql.CreateRecipe(r1);
            //sql.CreateRecipe(r2);
            //sql.CreateRecipe(r3);

            //sql.CreatePlan(p1);
            //sql.CreatePlan(p2);
            //sql.CreatePlan(p3);

            // List<FoodModel> foodModels = sql.GetFood_All();

            List<RecipeModel> recipes= sql.GetRecipe_All();

            List<PlanModel> plans = sql.GetPlan_All();

            Console.ReadLine();

        }

        void InsertNutrients(ListView listView, List<string> nutrients)
        {
            for (int i = 1; i < nutrients.Count; i++)
            {
                listView.Items[i].Text = nutrients[i];
            }
        }

        private void InsertOriginalFoods()
        {
            string filePath = @"..\..\Resources\foodlist.xlsx";

            ImportNutrients.ParseXLSX(filePath);

            foreach (FoodModel f in ImportNutrients.originalFoodModels)
            {
                sql.CreateFood(f);
            }
        }
    }
}
