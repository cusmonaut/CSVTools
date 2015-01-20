using CSVTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVToolsUT
{
    internal static class TestHelpers
    {
        internal static string[] GenerteTestArray(string str, int length)
        {
            string[] array = new string[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = str + i;
            }

            return array;
        }

        internal static CSV GenerateTestData(int numberOfRows)
        {
            CSV csv = new CSV(new List<Dictionary<string, string>>());

            for (int i = 0; i < numberOfRows; i++)
            {
                var dic = new Dictionary<string, string>();

                dic.Add("Key" + i, "Value" + i);
                dic.Add("Keys" + i, "Values" + i);

                csv.AddRow(dic);
            }

            return csv;
        }
    }
}