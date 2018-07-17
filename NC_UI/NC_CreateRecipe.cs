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
using NC_Library.Models;

namespace NC_UI
{
    public partial class NC_CreateRecipe : Form
    {
        SqlConnector sql = new SqlConnector();

        Dictionary<int, FoodModel> AvailableFood;

        public RecipeModel Recipe { get; set; } = new RecipeModel();

        List<FoodModel> recipeFoodList = new List<FoodModel>();

        public bool updateData = false;

        public NC_CreateRecipe(RecipeModel model, Dictionary<int, FoodModel> availableFood)
        {
            InitializeComponent();

            Recipe = model;            

            AvailableFood = availableFood;

            InitializeBindings();
        }

        private void RecipeNameTextBox_Enter(object sender, EventArgs e)
        {
            if (recipeNameTextBox.Text == (string)recipeNameTextBox.Tag)
            {
                recipeNameTextBox.Text = "";
            }

            recipeNameTextBox.ForeColor = Color.Black;
        }

        private void RecipeNameTextBox_Leave(object sender, EventArgs e)
        {
            if (recipeNameTextBox.Text == "")
            {
                recipeNameTextBox.Text = (string)recipeNameTextBox.Tag;
                recipeNameTextBox.ForeColor = Color.Gray;
            }
        }

        private void InitializeBindings()
        {
            recipeNameTextBox.Text = Recipe.Name;
            
            if (Recipe.Id != 0)
            {
                createRecipeButton.Enabled = false;
                saveRecipeButton.Enabled = true;
            }
            else
            {
                createRecipeButton.Enabled = true;
                saveRecipeButton.Enabled = false;
            }

            recipeFoodList = Recipe.FoodList;

            for (int i = 0; i < Recipe.FoodList.Count; i++)
            {
                foodDataGridView.Rows.Insert(0, Recipe.FoodList[i].Name);

                // TODO - rows start from the bottom
                foodDataGridView.Rows[foodDataGridView.Rows.Count - i].Cells[1].Value = Recipe.FoodAmount[i].ToString();
            }

            addFoodComboBox.DisplayMember = "Name";
            addFoodComboBox.ValueMember = "Id";
            addFoodComboBox.DataSource = new BindingSource(AvailableFood.Values, null);
        }

        private bool CheckFrom()
        {
            bool isOk = true;

            if (recipeNameTextBox.Text == (string)recipeNameTextBox.Tag)
            {
                isOk = false;
                MessageBox.Show("Insert name for food");
            }
            else if (recipeNameTextBox.Text.Length < 2)
            {
                isOk = false;
                MessageBox.Show("Food name must have at least 2 characters");
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
                    MessageBox.Show("All amount values must be numerical");
                    break;
                }
            }

            if (foodDataGridView.Rows.Count < 1)
            {
                isOk = false;
                MessageBox.Show("You must add at least one line");                
            }

            return isOk;
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            if (addFoodComboBox.SelectedItem != null)
            {
                foodDataGridView.Rows.Insert(0,AvailableFood[int.Parse(addFoodComboBox.SelectedValue.ToString())].Name);

                recipeFoodList.Add(AvailableFood[int.Parse(addFoodComboBox.SelectedValue.ToString())]);
            }
        }

        private void RemoveFoodButton_Click(object sender, EventArgs e)
        {
            if (foodDataGridView.CurrentCell != null)
            {
                recipeFoodList.RemoveAt(foodDataGridView.CurrentCell.RowIndex);

                foodDataGridView.Rows.RemoveAt(foodDataGridView.CurrentCell.RowIndex);
            }
        }

        private void CreateRecipeButton_Click(object sender, EventArgs e)
        {
            if (CheckFrom())
            {
                {
                    Recipe.Name = recipeNameTextBox.Text;

                    Recipe.FoodList = recipeFoodList;

                    foreach (DataGridViewRow r in foodDataGridView.Rows)
                    {                        
                        Recipe.FoodAmount.Add(int.Parse(r.Cells[1].FormattedValue.ToString()));
                    }                   

                    sql.CreateRecipe(Recipe);

                    updateData = true;

                    Close();
                }
            }
        }

        private void SaveRecipeButton_Click(object sender, EventArgs e)
        {
            if (CheckFrom())
            {
                Recipe.Name = recipeNameTextBox.Text;

                Recipe.FoodList = recipeFoodList;

                foreach (DataGridViewRow r in foodDataGridView.Rows)
                {
                    Recipe.FoodAmount.Add(int.Parse(r.Cells[1].FormattedValue.ToString()));
                }

                sql.UpdateRecipe(Recipe);

                updateData = true;

                Close();
            }
        }

        private void CancelRecipeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
