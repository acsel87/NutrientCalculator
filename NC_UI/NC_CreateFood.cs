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

namespace NC_UI
{
    public partial class NC_CreateFood : Form
    {
        public NC_CreateFood()
        {
            InitializeComponent();

            string filePath = @"C:\Users\Alex\Desktop\ndb.xlsx";

            List<string> nutrientList = ImportNutrients.ParseExcel(filePath);   

            InsertNutrientsGrid(dataGridView1, nutrientList);            
        }

        void InsertNutrientsGrid( DataGridView grid, List<string> nutrients)
        {
            foreach (string s in nutrients)
            {
                grid.Rows.Add(s);
            }
        }
    }
}
