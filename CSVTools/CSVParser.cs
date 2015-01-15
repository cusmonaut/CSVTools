using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;

namespace CSVTools
{
    public static class CSVParser
    {
        public static CSV ParseCSV(string filePath, bool ignoreBadRows = false)
        {
            var csv = new CSV(new List<Dictionary<string, string>>());

            using (TextFieldParser parser = new TextFieldParser(filePath.ToString()))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string[] colTitles = null;

                if (!parser.EndOfData)
                {
                    colTitles = parser.ReadFields();
                }

                while (!parser.EndOfData)
                {
                    var row = ProcessRow(parser.ReadFields(), colTitles, ignoreBadRows);

                    if (row != null)
                    {
                        csv.AddRow(row);
                    }
                }
            }

            return csv;
        }

        internal static Dictionary<string, string> ProcessRow(string[] row, string[] titles, bool ignoreBadRows)
        {
            var tempDictionary = new Dictionary<string, string>();

            if (row.Length != titles.Length)
            {
                if (!ignoreBadRows)
                {
                    throw new System.ArgumentException("Invalid CSV formating. Number of fields does not match columns");
                }

                return null;
            }

            for (int i = 0; i < titles.Count(); i++)
            {
                tempDictionary.Add(titles[i], row[i]);
            }

            return tempDictionary;
        }
    }
}