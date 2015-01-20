using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSVToolsUT
{
    [TestClass]
    public class CSVUT
    {
        [TestMethod]
        public void DeleteAtIndex()
        {
            var csv = TestHelpers.GenerateTestData(3);

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
            var csv = TestHelpers.GenerateTestData(1);

            csv.DeleteRowAt(2);
        }

        [TestMethod]
        public void DeleteRow()
        {
            var csv = TestHelpers.GenerateTestData(3);

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
            var csv = TestHelpers.GenerateTestData(3);

            var row = csv.Rows[0];

            csv.DeleteRow(row);
            csv.DeleteRow(row);
        }

        [TestMethod]
        public void AddRow()
        {
            var csv = TestHelpers.GenerateTestData(0);

            var dic = new Dictionary<string, string>();

            dic.Add("Test", "ing");

            csv.AddRow(dic);
            Assert.AreEqual<int>(1, csv.Rows.Count, "Filed to add row");
        }
    }
}