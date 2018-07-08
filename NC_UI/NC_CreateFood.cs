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
