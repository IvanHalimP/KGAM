using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinik_Gigi_Ana_Medika
{
    public class Num2Words
    {
        Dictionary<int, String> sat = new Dictionary<int, string>();
        Dictionary<int, String> belpura = new Dictionary<int, string>();
        Dictionary<int, String> riju = new Dictionary<int, string>();

        public Num2Words()
        {
            sat.Add(0, "");
            sat.Add(1, "satu ");
            sat.Add(2, "dua ");
            sat.Add(3, "tiga ");
            sat.Add(4, "empat ");
            sat.Add(5, "lima ");
            sat.Add(6, "enam ");
            sat.Add(7, "tujuh ");
            sat.Add(8, "delapan ");
            sat.Add(9, "sembilan ");

            belpura.Add(1, "belas ");
            belpura.Add(2, "puluh ");
            belpura.Add(3, "ratus ");

            riju.Add(1, "ribu ");
            riju.Add(2, "juta ");
        }

        String byNumLength(String numbers)
        {
            if (numbers.Length == 1)
            {
                if (numbers[0] == '0')
                {
                    return "";
                }
                else
                {
                    return sat[int.Parse(numbers)];
                }
            }
            else if (numbers.Length == 2)
            {
                if (numbers[0] == '0')
                {
                    return byNumLength(numbers.Substring(1));
                }
                else if (numbers[0] == '1')
                {
                    if (numbers[1] == '1')
                    {
                        return ("se" + belpura[int.Parse(numbers.Substring(1))]);
                    }
                    else if (numbers[1] == '0')
                    {
                        return ("se" + belpura[numbers.Length]);
                    }
                    else
                    {
                        return (byNumLength(numbers.Substring(numbers.Length - 1)) + belpura[numbers.Length-1]);
                    }
                }
                else
                {
                    return (byNumLength(numbers[0].ToString()) + belpura[numbers.Length] + byNumLength(numbers.Substring(1)));
                }
            }
            else if (numbers.Length == 3)
            {
                if (numbers[0] == '0')
                {
                    return (byNumLength(numbers.Substring(1)));
                }
                else
                {
                    if (numbers[0] == '1')
                    {
                        return ("se" + belpura[numbers.Length] + byNumLength(numbers.Substring(1)));
                    }
                    else
                    {
                        return (byNumLength(numbers[0].ToString()) + belpura[numbers.Length] + byNumLength(numbers.Substring(1)));
                    }
                }
            }
            else
            {
                return "";
            }
        }

        String byArrLength(int splitLen)
        {
            if (splitLen == 1 || splitLen == 2)
            {
                return riju[splitLen];
            }
            else
            {
                return "";
            }
        }

        public String convert(String Amount)
        {
            String inWords = "";
            String[] splitNum = Amount.Split('.');
            for (int i = splitNum.Length - 1; i >= 0; i--)
            {
                inWords += (byNumLength(splitNum[splitNum.Length - 1 - i]));
                if (splitNum[splitNum.Length - 1 - i]!="000")
                {
                    inWords+=byArrLength(i);
                }
            }
            return inWords;
        }
    }
}
