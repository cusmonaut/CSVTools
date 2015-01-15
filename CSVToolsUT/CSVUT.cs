using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSVToolsUT
{
    [TestClass]
    public class CSVUT
    {
        private CSV GenerateTestData(int numberOfRows)
        {
            CSV csv = new CSV(new List<Dictionary<string, string>>());

            for (int i = 0; i < numberOfRows; i++)
            {
                var dic = new Dictionary<string, string>();

                dic.Add("Key" + i, "Value" + i);

                csv.AddRow(dic);
            }

            return csv;
        }

        [TestMethod]
        public void DeleteAtIndex()
        {
            var csv = GenerateTestData(3);

            csv.DeleteRowAt(2);

            Assert.AreEqual<int>(2, csv.Rows.Count, "Failed to remove one item from the list");

            csv.DeleteRowAt(0);
            csv.DeleteRowAt(0);
            Assert.AreEqual<int>(0, csv.Rows.Count, "Filed to remove last two rows from the list");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAtNoneEexistingIndex()
        {
            var csv = GenerateTestData(1);

            csv.DeleteRowAt(2);
        }

        [TestMethod]
        public void DeleteRow()
        {
            var csv = GenerateTestData(3);

            var row = csv.Rows[0];

            csv.DeleteRow(row);
            Assert.AreEqual<int>(2, csv.Rows.Count, "Filed to delete row");
            Assert.IsFalse(csv.Rows.Contains(row), "List still contains deleted row!");
        }

        [TestMethod]
        public void DeleteNonExistingRow()
        {
            // Remove does not throw an exception when trying to delete something
            // not in the list so this should pass.
            var csv = GenerateTestData(3);

            var row = csv.Rows[0];

            csv.DeleteRow(row);
            csv.DeleteRow(row);
        }

        [TestMethod]
        public void AddRow()
        {
            var csv = GenerateTestData(0);

            var dic = new Dictionary<string, string>();

            dic.Add("Test", "ing");

            csv.AddRow(dic);
            Assert.AreEqual<int>(1, csv.Rows.Count, "Filed to add row");
        }
    }
}