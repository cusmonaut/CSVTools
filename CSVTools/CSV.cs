using System.Collections.Generic;

namespace CSVTools
{
    public class CSV
    {
        public IList<Dictionary<string, string>> Rows
        {
            get;
            private set;
        }

        public CSV(IList<Dictionary<string, string>> rowList)
        {
            Rows = rowList as List<Dictionary<string, string>>;
        }

        public void AddRow(Dictionary<string, string> row)
        {
            Rows.Add(row);
        }

        public void DeleteRow(Dictionary<string, string> row)
        {
            Rows.Remove(row);
        }

        public void DeleteRowAt(int index)
        {
            Rows.RemoveAt(index);
        }
    }
}