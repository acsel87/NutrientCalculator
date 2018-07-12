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

namespace NC_UI
{
    public partial class NC_CreateRecipe : Form
    {
        public NC_CreateRecipe(RecipeModel model)
        {
            InitializeComponent();

                       
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            searchFoodPanel.Visible = true;
        }

        private void SearchFoodTextBox_Enter(object sender, EventArgs e)
        {
            if (searchFoodTextBox.Text == (string)searchFoodTextBox.Tag)
            {
                searchFoodTextBox.Text = "";
                searchFoodTextBox.ForeColor = Color.Black;
            }
        }

        private void SearchFoodTextBox_Leave(object sender, EventArgs e)
        {            
            if (searchFoodTextBox.Text == "")
            {
                searchFoodTextBox.Text = (string)searchFoodTextBox.Tag;
                searchFoodTextBox.ForeColor = Color.Gray;
            }
        }
    }
}
