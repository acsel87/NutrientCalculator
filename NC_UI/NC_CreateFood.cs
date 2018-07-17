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
using NC_Library;

namespace NC_UI
{
    public partial class NC_CreateFood : Form
    {
        SqlConnector sql = new SqlConnector();

        public FoodModel Food { get; set; }

        public bool updateData = false;

        public NC_CreateFood(FoodModel model)
        {
            InitializeComponent();

            Food = model;

            InitializeBindings();            
        }

        private void FoodNameTextBox_Enter(object sender, EventArgs e)
        {
            if (foodNameTextBox.Text == (string)foodNameTextBox.Tag)
            {
                foodNameTextBox.Text = "";                
            }

            foodNameTextBox.ForeColor = Color.Black;
        }

        private void FoodNameTextBox_Leave(object sender, EventArgs e)
        {
            if (foodNameTextBox.Text == "")
            {
                foodNameTextBox.Text = (string)foodNameTextBox.Tag;                
                foodNameTextBox.ForeColor = Color.Gray;
            }
        }

        private void InitializeBindings()
        {
            foodNameTextBox.Text = Food.Name;

            if (Food.Type == null)
            {
                Food.Type = "";
            }

            if (Food.Id != 0)
            {
                createButton.Enabled = false;
                saveButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = true;
                saveButton.Enabled = false;
            }

            //Food = sql.ViewFood(Food); - food infor already in reference

            foreach (string s in GlobalConfig.nutrientList)
            {
                nutrientsDataGridView.Rows.Insert(0, s);
            }

            double[] temp = Food.NutrientList;

            for (int i = 0; i < temp.Length; i++)
            {
                nutrientsDataGridView.Rows[i].Cells[1].Value = temp[i].ToString("0.##");
            }
        }

        private bool CheckFrom()
        {
            bool isOk = true;

            if (foodNameTextBox.Text == (string)foodNameTextBox.Tag)
            {
                isOk = false;
                MessageBox.Show("Insert name for food");
            }
            else if (foodNameTextBox.Text.Length < 2)
            {
                isOk = false;
                MessageBox.Show("Food name must have at least 2 characters");
            }

            foreach (DataGridViewRow r in nutrientsDataGridView.Rows)
            {
                try
                {
                    double.Parse(r.Cells[1].FormattedValue.ToString());
                }
                catch (Exception)
                {
                    isOk = false;
                    MessageBox.Show("All amount values must be numerical");
                    break;
                }
            }

            return isOk;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (CheckFrom())
            {
                Food.Name = foodNameTextBox.Text;

                for (int i = 0; i < GlobalConfig.nutrientList.Length; i++)
                {
                    // TODO - simplify
                    Food.Nutrient_List += $"{ Math.Round(double.Parse(nutrientsDataGridView.Rows[i].Cells[1].FormattedValue.ToString()), 2).ToString("0.##") };";
                }

                Food.Nutrient_List = Food.Nutrient_List.Remove(Food.Nutrient_List.Length - 1);

                sql.CreateFood(Food);

                updateData = true;

                Close();                
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CheckFrom())
            {
                Food.Name = foodNameTextBox.Text;

                Food.Nutrient_List = "";

                for (int i = 0; i < GlobalConfig.nutrientList.Length; i++)
                {
                    // TODO - simplify
                    Food.Nutrient_List += $"{ Math.Round(double.Parse(nutrientsDataGridView.Rows[i].Cells[1].FormattedValue.ToString()), 2).ToString("0.##") };";
                }

                Food.Nutrient_List = Food.Nutrient_List.Remove(Food.Nutrient_List.Length - 1);

                sql.UpdateFood(Food);

                updateData = true;

                Close();                
            }
        }
    }
}
