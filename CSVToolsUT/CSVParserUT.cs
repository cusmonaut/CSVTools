using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSVToolsUT
{
    [TestClass]
    public class CSVParserUT
    {
        private string[] GenerteTestArray(string str, int length)
        {
            string[] array = new string[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = str + i;
            }

            return array;
        }

        [TestMethod]
        public void ProcessValidRow()
        {
            var row = GenerteTestArray("ROW ", 7);
            var titles = GenerteTestArray("Title ", 7);

            var dic = CSVParser.ProcessRow(row, titles, true);

            Assert.AreEqual<int>(7, dic.Count);

            dic = CSVParser.ProcessRow(row, titles, false);

            Assert.AreEqual<int>(7, dic.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessRowLongerTitle()
        {
            var row = GenerteTestArray("ROW ", 7);
            var titles = GenerteTestArray("Title ", 10);

            var dic = CSVParser.ProcessRow(row, titles, false);
        }

        [TestMethod]
        public void ProcessRowLongerTitleIgnore()
        {
            var row = GenerteTestArray("ROW ", 7);
            var titles = GenerteTestArray("Title ", 10);

            var dic = CSVParser.ProcessRow(row, titles, true);

            Assert.IsNull(dic);
        }
    }
}