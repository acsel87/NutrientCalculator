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
        public FoodModel Food { get; set; }

        SqlConnector sql = new SqlConnector();

        public NC_CreateFood(FoodModel model)
        {
            InitializeComponent();

            Food = model;

            if (Food.Type == null)
            {
                Food.Type = "";
            }

            InitializeBindings();
            
        }

        private void FoodNameTextBox_Enter(object sender, EventArgs e)
        {
            if (foodNameTextBox.Text == (string)foodNameTextBox.Tag)
            {
                foodNameTextBox.Text = "";
                foodNameTextBox.ForeColor = Color.Black;
            }
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

            Food = sql.ViewFood(Food);

            foreach (string s in GlobalConfig.nutrientList)
            {
                nutrientsDataGridView.Rows.Insert(0, s);
            }

            decimal[] temp = Food.NutrientList;

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
                    decimal.Parse(r.Cells[1].FormattedValue.ToString());
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
                    Food.Nutrient_List += $"{ Math.Round(decimal.Parse(nutrientsDataGridView.Rows[i].Cells[1].FormattedValue.ToString()), 2).ToString("0.##") };";
                }

                Food.Nutrient_List = Food.Nutrient_List.Remove(Food.Nutrient_List.Length - 1);

                sql.CreateFood(Food);               

                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
