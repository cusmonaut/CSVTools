using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToolsUT
{
    [TestClass]
    public class CSVWriterUT
    {
        [TestMethod]
        public void CreateRow()
        {
            CSV testCSV = TestHelpers.GenerateTestData(10);
            var row = CSVWriter.BuildCsvLine(testCSV.Rows[0], true);
            Assert.IsTrue(row == "Key0,Keys0");

            row = CSVWriter.BuildCsvLine(testCSV.Rows[0]);
            Assert.IsTrue(row == "Value0,Values0");
        }
    }
}