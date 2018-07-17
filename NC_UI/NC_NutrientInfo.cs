using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NC_Library.Models;
using NC_Library;

namespace NC_UI
{
    public partial class NC_NutrientInfo : Form
    {
        private FoodModel Food { get; set; } = new FoodModel();
        private RecipeModel Recipe { get; set; } = new RecipeModel();
        private PlanModel Plan { get; set; } = new PlanModel();

        private Label[] mainLabels = new Label[7];

        public bool updateData = false;

        public NC_NutrientInfo(FoodModel model)
        {
            InitializeComponent();
          
            Food = model;

            if (Food.Type == null)
            {
                Food.Type = "";
            }

            InitializeFood();
        }

        public NC_NutrientInfo(RecipeModel model)
        {
            InitializeComponent();

            Recipe = model;            

            InitializeRecipe();
        }

        public NC_NutrientInfo(PlanModel model)
        {
            InitializeComponent();

            Plan = model;            

            InitializePlan();
        }

        void FoodTest()
        {
            Food.Id = 8799;
            Food.Name = "TestFoofInfo";
            Food.IsCustom = true;

            string[] x = {
            "1280", "107", "100", "75.6", "38", "1000", "25", "8", "40","700", "2100",
            "1500", "11", "0.9", "2.3", "55", "90", "1.2","1.3", "16", "5", "1.3", "120",
            "2.4", "3000", "5", "600", "12", "0.1", "0.1", "0.1", "0"  };

            Food.Nutrient_List = string.Join(";", x);
        }

        private void InitializeFood()
        {
            nameLabel.Text = Food.Name;

            if (!Food.IsCustom)
            {
                addCommonButton.Enabled = false;
                addFavoritesButton.Enabled = false;
            }

            if (Food.Type == GlobalConfig.common)
            {
                addCommonButton.Enabled = false;
            }
            else if (Food.Type == GlobalConfig.favorite)
            {
                addFavoritesButton.Enabled = false;
            }

            InitializeData(Food.NutrientList);
        }        

        private void InitializeRecipe()
        {
            nameLabel.Text = Recipe.Name;

            amountLabel.Text = Recipe.Amount.ToString();

            addCommonButton.Visible = false;
            addFavoritesButton.Visible = false;

            InitializeData(Recipe.NutrientList);
        }

        private void InitializePlan()
        {
            nameLabel.Text = Plan.Name;

            amountLabel.Text = Plan.Amount.ToString();

            addCommonButton.Visible = false;
            addFavoritesButton.Visible = false;

            InitializeData(Plan.NutrientList);
        }

        private void AddCommonButton_Click(object sender, EventArgs e)
        {
            Food.Type = GlobalConfig.common;

            addFavoritesButton.Enabled = true;

            addCommonButton.Enabled = false;

            updateData = true;
        }

        private void AddFavoritesButton_Click(object sender, EventArgs e)
        {
            Food.Type = GlobalConfig.favorite;

            addCommonButton.Enabled = true;

            addFavoritesButton.Enabled = false;

            updateData = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (updateData)
            {
                NC_Library.DataAccess.SqlConnector sql = new NC_Library.DataAccess.SqlConnector();

                sql.UpdateFood(Food);
            }

            Close();           
        }

        private void InitializeData(double[] tempNutrients)
        {
            mainLabels = new Label[] { energyLabel, proteinLabel, carbsLabel, totalFatLabel, fiberLabel, calciumLabel, sugarLabel };

            for (int i = 0; i < mainLabels.Length; i++)
            {
                mainLabels[i].Text = $"{ Math.Round(tempNutrients[i], 2).ToString() } / { GlobalConfig.dailyValues[i] } ";
            }

            for (int i = 0; i < foodListView.Items.Count; i++)
            {
                for (int j = 1; j < foodListView.Items[i].SubItems.Count; j += 2)
                {
                    foodListView.Items[i].SubItems[j].Text = $"{ Math.Round(tempNutrients[i + 10 * (j - 1) / 2 + 7], 2).ToString() } / { GlobalConfig.dailyValues[i + 10 * (j - 1) / 2 + 7] }";
                }
            }
        }
    }
}
