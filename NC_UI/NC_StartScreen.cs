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
using System.Data.SqlClient;

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

        public Dictionary<int, FoodModel> AvailableFood { get; set; } = new Dictionary<int, FoodModel>();
        Dictionary<int, FoodModel> AvailableCommonFood { get; set; } = new Dictionary<int, FoodModel>();
        Dictionary<int, FoodModel> AvailableFavoriteFood { get; set; } = new Dictionary<int, FoodModel>();
        Dictionary<int, FoodModel> AvailableCustomFood { get; set; } = new Dictionary<int, FoodModel>();
        Dictionary<int, RecipeModel> AvailableRecipes { get; set; } = new Dictionary<int, RecipeModel>();
        Dictionary<int, PlanModel> AvailablePlans { get; set; } = new Dictionary<int, PlanModel>();        

        Button clickedButton = new Button();

        public NC_StartScreen()
        {
            InitializeComponent();

            UpdateData();

            UpdateWeek(Week);
        }

        private void InitializeData()
        {
            AvailableFood = sql.GetFood_All().ToDictionary( x => x.Id , x => x);

            AvailableCommonFood = AvailableFood.Where( p => p.Value.Type == GlobalConfig.common).ToDictionary(p => p.Key, p => p.Value);

            AvailableFavoriteFood = AvailableFood.Where(p => p.Value.Type == GlobalConfig.favorite).ToDictionary(p => p.Key, p => p.Value);

            AvailableCustomFood = AvailableFood.Where(p => p.Value.IsCustom == true).ToDictionary(p => p.Key, p => p.Value);

            AvailableRecipes = sql.GetRecipe_All().ToDictionary(x => x.Id, x => x);

            AvailablePlans = sql.GetPlan_All().ToDictionary(x => x.Id, x => x);

        }

        private void InitializeLists()
        {
            if (AvailableFood.Values.Count != 0)
            {
                foodSearchComboBox.DisplayMember = "Name";
                foodSearchComboBox.ValueMember = "Id";
                foodSearchComboBox.DataSource = new BindingSource(AvailableFood.Values, null);
            }

            if (AvailableCommonFood.Count != 0)
            {
                commonFoodListBox.DisplayMember = "Name";
                commonFoodListBox.ValueMember = "Id";
                commonFoodListBox.DataSource = new BindingSource(AvailableCommonFood.Values, null);
            }
            else
            {
                commonFoodListBox.DataSource = null;                
            }

            if (AvailableFavoriteFood.Count != 0)
            {
                favoriteFoodListBox.DisplayMember = "Name";
                favoriteFoodListBox.ValueMember = "Id";
                favoriteFoodListBox.DataSource = new BindingSource(AvailableFavoriteFood.Values, null);
            }
            else
            {
                favoriteFoodListBox.DataSource = null;                
            }

            if (AvailableCustomFood.Count != 0)
            {
                customFoodListBox.DisplayMember = "Name";
                customFoodListBox.ValueMember = "Id";
                customFoodListBox.DataSource = new BindingSource(AvailableCustomFood.Values, null);
            }
            else
            {
                customFoodListBox.DataSource = null;
            }


            if (AvailableRecipes.Count != 0)
            {
                recipeListBox.DisplayMember = "Name";
                recipeListBox.ValueMember = "Id";
                recipeListBox.DataSource = new BindingSource(AvailableRecipes.Values, null);
            }
            else
            {
                recipeListBox.DataSource = null;
            }

            if (AvailablePlans.Count != 0)
            {
                dayPlanListBox.DisplayMember = "Name";
                dayPlanListBox.ValueMember = "Id";
                dayPlanListBox.DataSource = new BindingSource(AvailablePlans.Values, null);

                planListBox.DisplayMember = "Name";
                planListBox.ValueMember = "Id";
                planListBox.DataSource = new BindingSource(AvailablePlans.Values, null);
            }
            else
            {
                dayPlanListBox.DataSource = null;
                planListBox.DataSource = null;
            }
        }

        private void InsertOriginalFoods()
        {
            string filePath = @"..\..\Resources\foodlist.xlsx";

            ImportNutrients.ParseXLSX(filePath);

            foreach (FoodModel f in ImportNutrients.originalFoodModels)
            {
                f.IsCustom = false;
                sql.CreateFood(f);
            }
        }

        private void UpdateWeek(List<PlanModel> model)
        {
            //for (int i = 0; i < userSettings.WeekValues.Count; i++)
            //{
            //    userSettings.WeekValues[i] = "0";
            //}

            //TODO - update buttons at application start
            MessageBox.Show("update buttons at application start");
            userSettings.Save();

            for (int i = 0; i < model.Count; i++)
            {
                int tempID = int.Parse(userSettings.WeekValues[i]);

                model[i] = new PlanModel();

                if (AvailablePlans.ContainsKey(tempID))
                {
                    model[i] = AvailablePlans[tempID];
                }
                else
                {
                    userSettings.WeekValues[i] = "0";
                    model[i].Id = 0;
                    model[i].Name = "Empty";
                }
            }

            double rowAvg = 0;            

            for (int i = 1; i < weekListView.Items.Count; i++)
            {
                for (int j = 1; j < weekListView.Items[1].SubItems.Count - 1; j++)
                {
                    if (i == 1)
                    {
                        weekListView.Items[0].SubItems[j].Text = $"{ model[j - 1].Name.PadRight(5).Substring(0,5) }";
                    }

                    weekListView.Items[i].SubItems[j].Text = $"{ model[j - 1].NutrientList[i - 1].ToString() } / {GlobalConfig.dailyValues[i-1] }";
                    rowAvg += model[j - 1].NutrientList[i - 1];
                }
                weekListView.Items[i].SubItems[8].Text = $"{  Math.Round((rowAvg / 7),2).ToString() } / {GlobalConfig.dailyValues[i-1]}";
                rowAvg = 0;
            }
        }

        private void AddPlanButton_Click(object sender, EventArgs e)
        {
            clickedButton = sender as Button;
            
            weekPlansPanel.BackgroundImage = ScreenShotControl.GetImage(weekPlansPanel);
            weekPlansPanel.Visible = true;            
        }

        private void PlanListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weekPlansPanel.Visible == true && planListBox.SelectedItem != null)
            {                
                int tempKey = int.Parse(planListBox.SelectedValue.ToString());                

                userSettings.WeekValues[int.Parse(clickedButton.Tag.ToString())] = AvailablePlans[tempKey].Id.ToString();

                UpdateWeek(Week);                

                clickedButton.Visible = false;
                Controls.Find($"removePlanButton{clickedButton.Text}", true).First().Visible = true;

                weekPlansPanel.Visible = false;
            }  
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

        private void Csv_Click(object sender, EventArgs e)
        {
            NC_Logic.ExportCSV(Week);    
        }

        private void FoodListViewButton_Click(object sender, EventArgs e)
        {
            if (foodSearchComboBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailableFood[int.Parse(foodSearchComboBox.SelectedValue.ToString())]);

                if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
                {
                    UpdateData();
                }

                form.Dispose();
            }
        }

        private void ViewCommonFoodButton_Click(object sender, EventArgs e)
        {
            if (commonFoodListBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailableCommonFood[int.Parse(commonFoodListBox.SelectedValue.ToString())]);

                if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
                {
                    UpdateData();
                }

                form.Dispose();
            }
        }

        private void RemoveCommonFoodButton_Click(object sender, EventArgs e)
        {
            if (commonFoodListBox.SelectedItem != null)
            {
                AvailableCommonFood[int.Parse(commonFoodListBox.SelectedValue.ToString())].Type = "";

                sql.UpdateFood(AvailableCommonFood[int.Parse(commonFoodListBox.SelectedValue.ToString())]);

                UpdateData();
            }
        }

        private void ViewFavoriteFoodButton_Click(object sender, EventArgs e)
        {
            if (favoriteFoodListBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailableFavoriteFood[int.Parse(favoriteFoodListBox.SelectedValue.ToString())]);

                if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
                {
                    UpdateData();
                }

                form.Dispose();
            }
        }

        private void RemoveFavoriteFoodButton_Click(object sender, EventArgs e)
        {
            if (favoriteFoodListBox.SelectedItem != null)
            {
                AvailableFavoriteFood[int.Parse(favoriteFoodListBox.SelectedValue.ToString())].Type = "";

                sql.UpdateFood(AvailableFavoriteFood[int.Parse(favoriteFoodListBox.SelectedValue.ToString())]);

                UpdateData();
            }
        }

        private void ViewCustomFoodButton_Click(object sender, EventArgs e)
        {
            if (customFoodListBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailableCustomFood[int.Parse(customFoodListBox.SelectedValue.ToString())]);

                if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
                {
                    UpdateData();
                }

                form.Dispose();
            }
        }

        private void AddCustomFoodButton_Click(object sender, EventArgs e)
        {
            NC_CreateFood form = new NC_CreateFood(new FoodModel { IsCustom = true });

            if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
            {
                UpdateData();
            }

            form.Dispose();
        }

        private void EditCustomFoodButton_Click(object sender, EventArgs e)
        {
            if (customFoodListBox.SelectedItem != null)
            {
                NC_CreateFood form = new NC_CreateFood(AvailableCustomFood[int.Parse(customFoodListBox.SelectedValue.ToString())]);

                if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
                {
                    UpdateData();
                }

                form.Dispose();
            }
        }

        private void RemoveCustomFoodButton_Click(object sender, EventArgs e)
        {
            if (customFoodListBox.SelectedItem != null)
            {
                sql.DeleteFood(AvailableCustomFood[int.Parse(customFoodListBox.SelectedValue.ToString())]);

                UpdateData();
            }
        }

        private void ViewRecipeViewButton_Click(object sender, EventArgs e)
        {
            if (recipeListBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailableRecipes[int.Parse(recipeListBox.SelectedValue.ToString())]);

                form.ShowDialog();
                form.Dispose();
            }
        }

        private void AddRecipeButton(object sender, EventArgs e)
        {
            NC_CreateRecipe form = new NC_CreateRecipe(new RecipeModel(), AvailableFood);

            if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
            {
                UpdateData();
            }

            form.Dispose();
        }

        private void EditRecipeButton_Click(object sender, EventArgs e)
        {
            NC_CreateRecipe form = new NC_CreateRecipe(AvailableRecipes[int.Parse(recipeListBox.SelectedValue.ToString())], AvailableFood);

            if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
            {
                UpdateData();
            }

            form.Dispose();
        }

        private void RemoveRecipeButton_Click(object sender, EventArgs e)
        {
            if (recipeListBox.SelectedItem != null)
            {
                sql.DeleteRecipe(AvailableRecipes[int.Parse(recipeListBox.SelectedValue.ToString())]);

                UpdateData();
            }
        }

        private void ViewPlanButton_Click(object sender, EventArgs e)
        {
            if (dayPlanListBox.SelectedItem != null)
            {
                NC_NutrientInfo form = new NC_NutrientInfo(AvailablePlans[int.Parse(dayPlanListBox.SelectedValue.ToString())]);

                form.ShowDialog();
                form.Dispose();
            }
        }

        private void AddPlanButton_Click_1(object sender, EventArgs e)
        {
            NC_CreateDayPlan form = new NC_CreateDayPlan(new PlanModel(), AvailableFood, AvailableRecipes);

            if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
            {
                UpdateData();
            }

            form.Dispose();
        }

        private void EditPlanButton_Click(object sender, EventArgs e)
        {
            NC_CreateDayPlan form = new NC_CreateDayPlan(AvailablePlans[int.Parse(dayPlanListBox.SelectedValue.ToString())], AvailableFood, AvailableRecipes);

            if (form.ShowDialog(this) != DialogResult.OK && form.updateData)
            {
                UpdateData();
            }

            form.Dispose();
        }

        private void RemovePlanButton_Click_1(object sender, EventArgs e)
        {
            if (dayPlanListBox.SelectedItem != null)
            {
                sql.DeletePlan(AvailablePlans[int.Parse(dayPlanListBox.SelectedValue.ToString())]);

                UpdateData();

                UpdateWeek(Week);
            }           
        }

        private void DayPlanListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayPlanItemsListBox.Items.Clear();

            foreach (RecipeModel r in AvailablePlans[int.Parse(dayPlanListBox.SelectedValue.ToString())].RecipeList)
            {
                dayPlanItemsListBox.Items.Add(r.Name);
            }

            foreach (FoodModel f in AvailablePlans[int.Parse(dayPlanListBox.SelectedValue.ToString())].FoodList)
            {
                dayPlanItemsListBox.Items.Add(f.Name);
            }           
        }

        private void NC_StartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActiveForm.Dispose();
        }

        private void UpdateData()
        {
            InitializeData();  
            InitializeLists();
            foodTab.Refresh();
        }

        private void WeekPlansPanel_Click(object sender, EventArgs e)
        {
            weekPlansPanel.Visible = false;
        }
    }
}
