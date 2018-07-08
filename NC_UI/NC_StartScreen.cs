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
using NC_Library;
using System.Drawing.Imaging;

namespace NC_UI
{
    public partial class NC_StartScreen : Form
    {        
        SqlConnector sql = new SqlConnector();

        Settings userSettings = Settings.Default;

        public List<PlanModel> Week { get; set; } = new List<PlanModel>()
        { new PlanModel(),
        new PlanModel(),
        new PlanModel(),
        new PlanModel(),
        new PlanModel(),
        new PlanModel(),
        new PlanModel()};

        List<PlanModel> availablePlans = new List<PlanModel>();

        Button clickedButton = new Button();

        // Bitmap exportImage; - when jpg export is done 

        public NC_StartScreen()
        {
            InitializeComponent();            

            UpdateWeek(Week);

            // Console.ReadLine();
        }

        void Test()
        {
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
                Name = "2222",
                Amount = 10111,
                FoodList = new List<FoodModel> { f1, f2, f2, f2 }
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
                Id = 1,
                Name = "zzzz",
                Amount = 100121,
                FoodList = new List<FoodModel> { f1, f1, f1 },
                RecipeList = new List<RecipeModel> { r3, r3, r3 }
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

            // sql.UpdateRecipe(r1);
            // sql.UpdatePlan(p1);

            FoodModel testFood = new FoodModel { Id = 8791, Name = "TestFood", Type = "Custom", Nutrient_List = "1,2,3,4,5,6,7,8,9,10" };

            RecipeModel testRecipe = new RecipeModel
            {
                Id = 5,
                Name = "r3",
                Amount = 30,
                FoodList = new List<FoodModel> { testFood, testFood }
            };

            PlanModel testPlan = new PlanModel
            {
                Id = 5,
                Name = "zzzz",
                Amount = 100121,
                FoodList = new List<FoodModel> { testFood },
                RecipeList = new List<RecipeModel> { testRecipe, testRecipe, testRecipe }
            };

            //sql.CreateFood(testFood);
            //sql.CreateRecipe(testRecipe);
            //sql.CreatePlan(testPlan);

            // sql.DeletePlan(testPlan);
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

        private void GetPlans()
        {
            planListBox.Items.Clear();

            availablePlans = sql.GetPlan_All();

            foreach (PlanModel p in availablePlans)
            {
                planListBox.Items.Add(p.Name);
            }
        }

        private void UpdateWeek(List<PlanModel> model)
        {
            userSettings.Save();

            for (int i = 0; i < model.Count; i++)
            {
                model[i].Id = int.Parse(userSettings.WeekValues[i]);
                
                try
                {
                    model[i] = sql.ViewPlan(model[i]);
                }
                catch (Exception)
                {
                    model[i].Name = "   ";
                    model[i].Amount = 0;
                    model[i].NutrientList = new decimal[32];

                    continue;
                }  
            }

            decimal rowAvg = 0M;            

            for (int i = 1; i < weekListView.Items.Count; i++)
            {
                for (int j = 1; j < weekListView.Items[1].SubItems.Count - 1; j++)
                {
                    if (i == 1)
                    {
                        weekListView.Items[0].SubItems[j].Text = $"{ model[j - 1].Name.Substring(0,2) }";
                    }

                    weekListView.Items[i].SubItems[j].Text = $"{ model[j - 1].NutrientList[i - 1].ToString() } / {GlobalConfig.dailyValues[i-1] }";
                    rowAvg += model[j - 1].NutrientList[i - 1];
                }
                weekListView.Items[i].SubItems[8].Text = $"{  Math.Round((rowAvg / 7),2).ToString() } / {GlobalConfig.dailyValues[i-1]}";
                rowAvg = 0M;
            }
        }

        private void AddPlanButton_Click(object sender, EventArgs e)
        {
            GetPlans();

            clickedButton = sender as Button;
            
            weekPlansPanel.BackgroundImage = ScreenShotControl.GetImage(weekPlansPanel);
            weekPlansPanel.Visible = true;            
        }

        private void PlanListBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            userSettings.WeekValues[int.Parse(clickedButton.Tag.ToString())] = availablePlans[planListBox.SelectedIndex].Id.ToString();
            
            UpdateWeek(Week);            

            clickedButton.Visible = false;
            Controls.Find($"removePlanButton{clickedButton.Text}", true).First().Visible = true;
            
            weekPlansPanel.Visible = false;
        }

        private void CancelPlanButton_Click(object sender, EventArgs e)
        {
            
            weekPlansPanel.Visible = false;
        }

        private void RemovePlanButton_Click(object sender, EventArgs e)
        {
            clickedButton = sender as Button;

            userSettings.WeekValues[int.Parse(clickedButton.Tag.ToString())] = "0";

            UpdateWeek(Week);

            clickedButton.Visible = false;
            Controls.Find($"addPlanButton{clickedButton.Text}", true).First().Visible = true;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            exportContextMenuStrip.Show(exportButton, exportButton.Width, 0);            
        }       

        private void TabControl_Click(object sender, EventArgs e)
        {
             weekPlansPanel.Visible = false;
        }        

        private void Csv_Click(object sender, EventArgs e)
        {
            NC_Logic.ExportCSV(Week);    
        }
    }
}
