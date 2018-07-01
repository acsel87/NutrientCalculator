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
    public partial class NC_StartScreen : Form
    {
        public NC_StartScreen()
        {
            InitializeComponent();

            string filePath = @"C:\Users\Alex\Desktop\foodlist.xlsx";

            List<string> nutrientList = ImportNutrients.ParseExcel(filePath);

            InsertNutrients(weekListView, nutrientList);
            

        }

        void InsertNutrients(ListView listView, List<string> nutrients)
        {
            for (int i = 1; i < nutrients.Count; i++)
            {
                listView.Items[i].Text = nutrients[i];
            }
        }
    }
}
