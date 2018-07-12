using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_Library
{
    public static class GlobalConfig
    {
        public static string common = "Common";
        public static string favorite = "Favorite";

        public static string[] dailyValues = new string[32] {
            "2000", "121", "130", "75.6", "38", "1000", "25", "8", "400","700", "4700",
            "1500", "11", "0.9", "2.3", "55", "90", "1.2","1.3", "16", "5", "1.3", "400",
            "2.4", "3000", "15", "600", "120", "0.1", "0.1", "0.1", "0" };

        public static string[] nutrientList = new string[32] {
            "Energy_(kcal)", "Protein_(g)", "Carbs_(g)", "Total_Fat_(g)",
            "Fiber_(g)", "Calcium_(mg)", "Sugar_(g)", "Iron_(mg)", "Magnesium_(mg)", "Phosphorus_(mg)",
            "Potassium_(mg)", "Sodium_(mg)", "Zinc_(mg)", "Copper_(mg)", "Manganese_(mg)", "Selenium_(µg)",
            "Vitamin_C_(mg)", "Thiamin_(mg)", "Riboflavin_(mg)", "Niacin_(mg)", "Panto_Acid_(mg)",
            "Vitamin_B6_(mg)", "Folate_(µg)", "Vitamin_B12_(µg)", "Vitamin_A_IU", "Vitamin_E_(mg)",
            "Vit_D_IU", "Vitamin_K_(µg)", "Sat_Fat_(g)", "Mono_Fat_(g)", "Poly_Fat_(g)", "Cholesterol_(mg)"};

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static decimal[] AddDecimalArray(this decimal[] d1, decimal[] d2)
        {
            if (d1.Length >= d2.Length)
            {
                for (int i = 0; i < d2.Length; i++)
                {
                    d1[i] += d2[i];
                }

                return d1;
            }
            else
            {
                for (int i = 0; i < d1.Length; i++)
                {
                    d2[i] += d1[i];
                }

                return d2;
            }            
        }
    }
}
