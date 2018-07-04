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
