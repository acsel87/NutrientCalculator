using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC_Library.Models;
using NC_Library.DataAccess;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace NC_Library
{
    public static class NC_Logic
    {
        public static void ExportCSV(List<PlanModel> model)
        {
            List<string> result = new List<string>();

            decimal rowAvg = 0M;

            result.Add(",Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Average");
            result.Add("Nutrients / Day Plan");


            for (int i = 2; i < 34; i++)
            {
                result.Add($"{ GlobalConfig.nutrientList[i-2] }");

                for (int j = 0; j < 7; j++)
                {
                    if (i == 2)
                    {
                        result[1] += ($",{ model[j].Name }");
                    }
                    result[i] += $",{ model[j].NutrientList[i - 2].ToString() } / {GlobalConfig.dailyValues[i - 2]}";                   

                    rowAvg += model[j].NutrientList[i - 2];
                }
                result[i] += $",{  Math.Round((rowAvg / 7), 2).ToString() } / {GlobalConfig.dailyValues[i - 2]}";
                rowAvg = 0M;
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                Title = "Save as csv File"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFile.FileName, result);
            }                
        }

        // TODO - Need to capture the whole scrollable list
        public static void ExportJPG(Control control)
        {
            Bitmap image = ScreenShotControl.GetImage(control);

            SaveFileDialog dlg = new SaveFileDialog { DefaultExt = "jpeg", Filter = "Jpeg Files|*.jpeg" };
            
            if (dlg.ShowDialog() == DialogResult.OK) image.Save(dlg.FileName, ImageFormat.Jpeg);
        }
    }
}
