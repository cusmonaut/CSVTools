using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;

namespace CSVTools
{
    public static class CSVParser
    {
        public static CSV ParseCSV(string filePath)
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
                    csv.AddRow(ProcessRow(parser.ReadFields(), colTitles));
                }
            }

            return csv;
        }

        internal static Dictionary<string, string> ProcessRow(string[] row, string[] titles)
        {
            if (row.Length != titles.Length)
            {
                throw new System.ArgumentException("Invalid CSV formating. Number of fields does not match columns");
            }

            var tempDictionary = new Dictionary<string, string>();

            for (int i = 0; i < titles.Count(); i++)
            {
                tempDictionary.Add(titles[i], row[i]);
            }

            return tempDictionary;
        }
    }
}