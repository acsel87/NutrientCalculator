using NC_Library.DataAccess;
using NC_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NC_UI
{
    public partial class NC_CreateDayPlan : Form
    {
        SqlConnector sql = new SqlConnector();

        Dictionary<int, FoodModel> AvailableFood;

        Dictionary<int, RecipeModel> AvailableRecipes;

        public PlanModel Plan { get; set; } = new PlanModel();

        List<FoodModel> planFoodList = new List<FoodModel>();
        List<RecipeModel> planRecipeList = new List<RecipeModel>();

        List<int> foodAmount = new List<int>();

        public bool updateData = false;

        public NC_CreateDayPlan(PlanModel model, Dictionary<int, FoodModel> availableFood, Dictionary<int, RecipeModel> availableRecipes)
        {
            InitializeComponent();

            Plan = model;

            AvailableFood = availableFood;

            AvailableRecipes = availableRecipes;

            InitializeBindings();
        }

        private void RecipeNameTextBox_Enter(object sender, EventArgs e)
        {
            if (planNameTextBox.Text == (string)planNameTextBox.Tag)
            {
                planNameTextBox.Text = "";
            }

            planNameTextBox.ForeColor = Color.Black;
        }

        private void RecipeNameTextBox_Leave(object sender, EventArgs e)
        {
            if (planNameTextBox.Text == "")
            {
                planNameTextBox.Text = (string)planNameTextBox.Tag;
                planNameTextBox.ForeColor = Color.Gray;
            }
        }

        private void InitializeBindings()
        {
            planNameTextBox.Text = Plan.Name;

            if (Plan.Id != 0)
            {
                createPlanButton.Enabled = false;
                savePlanButton.Enabled = true;
            }
            else
            {
                createPlanButton.Enabled = true;
                savePlanButton.Enabled = false;
            }

            planFoodList = Plan.FoodList;
            planRecipeList = Plan.RecipeList;

            for (int i = 0; i < Plan.FoodList.Count; i++)
            {
                foodDataGridView.Rows.Add(Plan.FoodList[i].Name, Plan.FoodAmount[i].ToString());
            }

            for (int i = 0; i < Plan.RecipeList.Count; i++)
            {
                recipeDataGridView.Rows.Add(Plan.RecipeList[i].Name, Plan.RecipeList[i].Amount.ToString());
            }

            addFoodComboBox.DisplayMember = "Name";
            addFoodComboBox.ValueMember = "Id";
            addFoodComboBox.DataSource = new BindingSource(AvailableFood.Values, null);

            addRecipeComboBox.DisplayMember = "Name";
            addRecipeComboBox.ValueMember = "Id";
            addRecipeComboBox.DataSource = new BindingSource(AvailableRecipes.Values, null);
        }

        private bool CheckForm()
        {
            bool isOk = true;

            if (planNameTextBox.Text == (string)planNameTextBox.Tag)
            {
                isOk = false;
                MessageBox.Show("Insert name for plan");
            }
            else if (planNameTextBox.Text.Length < 2)
            {
                isOk = false;
                MessageBox.Show("Plan name must have at least 2 characters");
            }

            foreach (DataGridViewRow r in foodDataGridView.Rows)
            {
                try
                {
                    int.Parse(r.Cells[1].FormattedValue.ToString());
                }
                catch (Exception)
                {
                    isOk = false;
                    MessageBox.Show("All amount values must be integral numbers");
                    break;
                }
            }

            if (foodDataGridView.Rows.Count < 1 && recipeDataGridView.Rows.Count < 1)
            {
                isOk = false;
                MessageBox.Show("You must add at least one line in either the food or recipe list");
            }

            return isOk;
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            if (addFoodComboBox.SelectedItem != null)
            {
                foodDataGridView.Rows.Insert(0, AvailableFood[int.Parse(addFoodComboBox.SelectedValue.ToString())].Name);

                planFoodList.Add(AvailableFood[int.Parse(addFoodComboBox.SelectedValue.ToString())]);

                updateData = true;
            }
        }

        private void RemoveFoodButton_Click(object sender, EventArgs e)
        {
            if (foodDataGridView.CurrentCell != null)
            {
                planFoodList.RemoveAt(foodDataGridView.CurrentCell.RowIndex);

                foodDataGridView.Rows.RemoveAt(foodDataGridView.CurrentCell.RowIndex);

                updateData = true;
            }
        }

        private void AddRecipeButton_Click(object sender, EventArgs e)
        {
            if (addRecipeComboBox.SelectedItem != null)
            {
                recipeDataGridView.Rows.Insert(0, AvailableRecipes[int.Parse(addRecipeComboBox.SelectedValue.ToString())].Name);

                planRecipeList.Add(AvailableRecipes[int.Parse(addRecipeComboBox.SelectedValue.ToString())]);

                updateData = true;
            }
        }

        private void RemoveRecipeButton_Click(object sender, EventArgs e)
        {
            if (recipeDataGridView.CurrentCell != null)
            {
                planRecipeList.RemoveAt(recipeDataGridView.CurrentCell.RowIndex);

                recipeDataGridView.Rows.RemoveAt(recipeDataGridView.CurrentCell.RowIndex);

                updateData = true;
            }
        }

        private void CreatePlanButton_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                {
                    Plan.Name = planNameTextBox.Text;

                    Plan.FoodList = planFoodList;

                    Plan.RecipeList = planRecipeList;

                    foreach (DataGridViewRow r in foodDataGridView.Rows)
                    {
                        foodAmount.Add(int.Parse(r.Cells[1].FormattedValue.ToString()));
                    }

                    Plan.FoodAmount = foodAmount;

                    sql.CreatePlan(Plan);

                    updateData = true;

                    Close();
                }
            }
        }

        private void SavePlanButton_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Plan.Name = planNameTextBox.Text;

                Plan.FoodList = planFoodList;

                Plan.RecipeList = planRecipeList;

                foreach (DataGridViewRow r in foodDataGridView.Rows)
                {
                    foodAmount.Add(int.Parse(r.Cells[1].FormattedValue.ToString()));
                }

                Plan.FoodAmount = foodAmount;

                sql.UpdatePlan(Plan);

                updateData = true;

                Close();
            }
        }

        private void CancelPlanButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
