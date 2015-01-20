using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSVToolsUT
{
    [TestClass]
    public class CSVParserUT
    {
        [TestMethod]
        public void ProcessValidRow()
        {
            var row = TestHelpers.GenerteTestArray("ROW ", 7);
            var titles = TestHelpers.GenerteTestArray("Title ", 7);

            var dic = CSVParser.ProcessRow(row, titles, true);

            Assert.AreEqual<int>(7, dic.Count);

            dic = CSVParser.ProcessRow(row, titles, false);

            Assert.AreEqual<int>(7, dic.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessRowLongerTitle()
        {
            var row = TestHelpers.GenerteTestArray("ROW ", 7);
            var titles = TestHelpers.GenerteTestArray("Title ", 10);

            var dic = CSVParser.ProcessRow(row, titles, false);
        }

        [TestMethod]
        public void ProcessRowLongerTitleIgnore()
        {
            var row = TestHelpers.GenerteTestArray("ROW ", 7);
            var titles = TestHelpers.GenerteTestArray("Title ", 10);

            var dic = CSVParser.ProcessRow(row, titles, true);

            Assert.IsNull(dic);
        }
    }
}