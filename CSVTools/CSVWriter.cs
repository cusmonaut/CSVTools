using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVTools
{
    public static class CSVWriter
    {
        public static void WriteToFile(string filePath, CSV csv)
        {
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                var titleLine = BuildCsvLine(csv.Rows[0], true);
                sr.WriteLine(titleLine);

                foreach (var row in csv.Rows)
                {
                    var line = BuildCsvLine(row);
                    sr.WriteLine(line);
                }

                sr.Close();
            }
        }

        internal static string BuildCsvLine(Dictionary<string, string> row, bool createTitleLine = false)
        {
            var csvRow = new StringBuilder();

            for (var i = 0; i < row.Count; i++)
            {
                string appendEnd = i == row.Count - 1 ? "" : ",";
                string value = createTitleLine ? row.ElementAt(i).Key : row.ElementAt(i).Value;

                csvRow.AppendFormat("{0}{1}", value, appendEnd);
            }

            return csvRow.ToString();
        }
    }
}