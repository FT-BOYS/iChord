using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice
{
    class CompareFunc
    {
        public static double CompareString(string str1,string str2)
        {
            double Rate = 0;
            int[,] s = new int[str1.Length + 1, str2.Length + 1];
            String[,] str = new String[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        s[i, j] = 0;
                        str[i, j] = "";
                    }
                    else
                    {
                        if (str1.Substring(i - 1, 1) == str2.Substring(j - 1, 1))
                        {
                            s[i, j] = s[i - 1, j - 1] + 1;
                            str[i, j] = str[i - 1, j - 1] + str1.Substring(i - 1, 1);
                        }
                        else
                        {
                            s[i, j] = s[i - 1, j] > s[i, j - 1] ? s[i - 1, j] : s[i, j - 1];
                            str[i, j] = s[i - 1, j] > s[i, j - 1] ? str[i - 1, j] : str[i, j - 1];
                        }
                    }
                }
            }
            Rate=str[str1.Length, str2.Length].Length*1.0 / str2.Length;
            return Rate;
        } 
    }
}
