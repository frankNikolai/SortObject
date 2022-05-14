using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortObject.Models.Tests
{
    [TestClass()]
    public class OrderObjectsTests
    {
        [TestMethod()]
        public void SortTestCorrectData()
        {
            // Immutable parameters
            OrderObjects orderObjects = new OrderObjects();

            // checking when upper words
            string actual = "",expected = "КККЗЗЗССС";
            string Input = "КЗСКЗСКЗС", typeSort = "КЗС";
            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);

            // checking when lower words
            actual = ""; expected = "кккзззссс";
            Input = "кзскзскзс"; typeSort = "кзс";
            actual = orderObjects.Sort(Input, typeSort);
            
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SortTestIncorrectData()
        {
            // Immutable parameters
            string actual = "", expected = "";
            OrderObjects orderObjects = new OrderObjects();

            //checked words
            string Input = "Программа", typeSort = "Не программа";

            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);

            //checked spec. symbols
            Input = ";"; typeSort = ";";

            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);

            //checked numbers
            Input = "1"; typeSort = "2";

            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SortTestBorderData()
        {
            // Immutable parameters
            string actual = "", expected = "";
            OrderObjects orderObjects = new OrderObjects();

            //checking when the input type is valid

            string Input = "КЗСКЗСКЗС", typeSort = "123";

            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);

            //checking when the type sort is valid

            Input = "Программа"; typeSort = "СКЗ";

            actual = orderObjects.Sort(Input, typeSort);

            Assert.AreEqual(expected, actual);
        }
    }
}